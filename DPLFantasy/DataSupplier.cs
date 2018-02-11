using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPLFantasy
{
    class DataSupplier
    {
        internal List<PlayerInfo> GetTeamInfoByNameAndValue(string teamName)
        {
            return GetPlayerNameAndValue(teamName);
        }

        internal List<string> GetDreamTeamsByDate(DateTime date)
        {
            List<string> dreamTeams = null;
            try
            {
                using (TBCL3FantasyLeagueEntities context = new TBCL3FantasyLeagueEntities())
                {
                    try
                    {
                        if (context.Database.Exists())
                        {
                            dreamTeams = (from dreamTeam in context.DreamTeams                                        
                                          where dreamTeam.DateSubmitted.CompareTo(date) == 0
                                          select new { TeamName = dreamTeam.TeamName, TotalScoredPoints = dreamTeam.TotalScoredPoints}).OrderByDescending(x => x.TotalScoredPoints).Select(x => x.TeamName).ToList();
                        }
                        else
                        {
                            throw new ApplicationException("Connectivity issues with database.Contact Admin");
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dreamTeams;
        }

        internal List<DreamTeamPlayer> GetDreamTeamData(DateTime date, string teamName)
        {
            List<DreamTeamPlayer> dreamTeams = null;
            string dreamTeamId = string.Format("{0}_{1}", teamName, date.Date.ToString("yyyy-MM-dd"));
            try
            {
                using (TBCL3FantasyLeagueEntities context = new TBCL3FantasyLeagueEntities())
                {
                    try
                    {
                        if (context.Database.Exists())
                        {
                            dreamTeams = (from t in context.DreamTeamPlayers where t.DreamTeamId.Equals(dreamTeamId) select t).ToList();
                        }
                        else
                        {
                            throw new ApplicationException("Connectivity issues with database.Contact Admin");
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dreamTeams;
        }

        private List<PlayerInfo> GetPlayerNameAndValue(string teamName)
        {
            List<PlayerInfo> playerInfo = null;
            try
            {
                using (TBCL3FantasyLeagueEntities table = new TBCL3FantasyLeagueEntities())
                {
                    try
                    {
                        if (table.Database.Exists())
                        {
                            playerInfo = (from t in table.Players where t.Team_Id.Equals(teamName) select new PlayerInfo() { Points = t.Points, Name = t.Name, IsGirlPlayer = t.IsGirlPlayer, Team_Id = t.Team_Id }).ToList();
                        }
                        else
                        {
                            throw new ApplicationException("Connectivity issues with database.Contact Admin");
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return playerInfo;
        }

        internal IEnumerable<string> GetTeams()
        {
            return GetTeamsFromDb();
        }

        private IEnumerable<string> GetTeamsFromDb()
        {
            try
            {
                using (TBCL3FantasyLeagueEntities context = new TBCL3FantasyLeagueEntities())
                {
                    try
                    {
                        if (context.Database.Exists())
                        {
                            return (from t in context.Players select t.Team_Id.Trim()).Distinct().ToList();
                        }
                        else
                        {
                            throw new ApplicationException("Connectivity issues with database.Contact Admin");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        internal void UpdateDreamTeamInDb(string dreamTeamName, string captainName, string viceCaptainName, List<PlayerInfo> team)
        {
            string dreamTeamId = dreamTeamName + "_" + DateTime.Now.ToString("yyyy-MM-dd");
            UpdateDreamTeam(dreamTeamName, captainName, viceCaptainName, dreamTeamId);
            try
            {
                UpdateDreamTeamPlayers(dreamTeamId, team);
            }
            catch (Exception ex)
            {

                DeleteCurrentTeamRecord(dreamTeamId);
                throw ex;
            }
        }

        private void DeleteCurrentTeamRecord(string dreamTeamId)
        {
            try
            {
                using (TBCL3FantasyLeagueEntities context = new TBCL3FantasyLeagueEntities())
                {
                    try
                    {
                        if (context.Database.Exists())
                        {
                            DreamTeam dreamTeam = new DreamTeam() { DreamTeamId = dreamTeamId };
                            context.DreamTeams.Attach(dreamTeam);
                            context.DreamTeams.Remove(dreamTeam);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new ApplicationException("Connectivity issues with database.Contact Admin");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Connectivity issues with database.Contact Admin. \n Details: " + ex.Message);
            }
        }

        private void UpdateDreamTeam(string dreamTeamName, string captainName, string viceCaptainName, string dreamTeamId)
        {
            DreamTeam dreamTeamObj = new DreamTeam()
            {
                TeamName = dreamTeamName,
                Captain = captainName,
                ViceCaptain = viceCaptainName,
                DateSubmitted = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                DreamTeamId = dreamTeamId,
                MoneyPaid = false
            };

            try
            {
                using (TBCL3FantasyLeagueEntities context = new TBCL3FantasyLeagueEntities())
                {
                    try
                    {
                        if (context.Database.Exists())
                        {
                            context.DreamTeams.Add(dreamTeamObj);
                            context.SaveChanges();
                        }
                        else
                        {
                            new ApplicationException("Connectivity issues with database.Contact Admin");
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            new ApplicationException("Someone already reserved the team name today.Choose different team name");
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Connectivity issues with database.Contact Admin. \n Details: " + ex.Message);
            }
        }

        private void UpdateDreamTeamPlayers(string dreamTeamId, List<PlayerInfo> players)
        {
            try
            {
                using (TBCL3FantasyLeagueEntities context = new TBCL3FantasyLeagueEntities())
                {
                    try
                    {
                        if (context.Database.Exists())
                        {
                            foreach (var item in players)
                            {
                                context.DreamTeamPlayers.Add(new DreamTeamPlayer()
                                {
                                    Name = item.Name,
                                    Team_id = item.Team_Id,
                                    Points = item.Points,
                                    IsGirlplayer = item.IsGirlPlayer,
                                    runsScored = 0,
                                    noOfFours = 0,
                                    noOfSixes = 0,
                                    noOfwickets = 0,
                                    maidenOver = 0,
                                    noOfCatches = 0,
                                    stumping = 0,
                                    runoutThrow = 0,
                                    runoutCatch = 0,
                                    duck = 0,
                                    bonusOnRunsScore = 0,
                                    bonusOnWickets = 0,
                                    totalPoints = 0,
                                    DreamTeamId = dreamTeamId
                                });
                            }
                            context.SaveChanges();
                        }
                        else
                        {
                            new ApplicationException("Connectivity issues with database.Contact Admin");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Connectivity issues with database.Contact Admin. \n Details: " + ex.Message);
            }
        }
    }
}
