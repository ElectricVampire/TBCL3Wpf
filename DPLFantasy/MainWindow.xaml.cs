using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DPLFantasy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> teams = null;
        DataSupplier dataSupplier = new DataSupplier();

        static readonly object syncLock = new object();

        ObservableCollection<PlayerInfo> dreamDataGridView = new ObservableCollection<PlayerInfo>();
        public ObservableCollection<PlayerInfo> DreamDataGridView
        {
            get { return dreamDataGridView; }
        }

        public readonly DependencyProperty DreamTeamPlayersDataProp = DependencyProperty.Register("DreamTeamPlayersDataView", typeof(List<DreamTeamPlayer>), typeof(Window), new UIPropertyMetadata(default(List<DreamTeamPlayer>)));
        public List<DreamTeamPlayer> DreamTeamPlayersDataView
        {
            get { return (List<DreamTeamPlayer>)this.GetValue(DreamTeamPlayersDataProp); }
            set { this.SetValue(DreamTeamPlayersDataProp, value); }
        }

        public readonly DependencyProperty DreamTeamsByDateProp = DependencyProperty.Register("DreamTeamsByDate", typeof(List<string>), typeof(Window), new UIPropertyMetadata(default(List<string>)));
        public List<string> DreamTeamsByDate
        {
            get { return (List<string>)this.GetValue(DreamTeamsByDateProp); }
            set { this.SetValue(DreamTeamsByDateProp, value); }
        }

        public readonly DependencyProperty TotalScoredPointsProp = DependencyProperty.Register("TotalScoredPoints", typeof(string), typeof(Window), new UIPropertyMetadata("0"));
        public string TotalScoredPoints
        {
            get { return (string)this.GetValue(TotalScoredPointsProp); }
            set { this.SetValue(TotalScoredPointsProp, value); }
        }

        public readonly DependencyProperty FirstDataGridViewProp = DependencyProperty.Register("FirstDataGridView", typeof(List<PlayerInfo>), typeof(Window), new UIPropertyMetadata(default(List<PlayerInfo>)));
        public List<PlayerInfo> FirstDataGridView
        {
            get { return (List<PlayerInfo>)this.GetValue(FirstDataGridViewProp); }
            set { this.SetValue(FirstDataGridViewProp, value); }
        }

        public readonly DependencyProperty SecondDataGridViewProp = DependencyProperty.Register("SecondDataGridView", typeof(List<PlayerInfo>), typeof(Window), new UIPropertyMetadata(default(List<PlayerInfo>)));
        public List<PlayerInfo> SecondDataGridView
        {
            get { return (List<PlayerInfo>)this.GetValue(SecondDataGridViewProp); }
            set { this.SetValue(SecondDataGridViewProp, value); }
        }

        public readonly DependencyProperty ThirdDataGridViewProp = DependencyProperty.Register("ThirdDataGridView", typeof(List<PlayerInfo>), typeof(Window), new UIPropertyMetadata(default(List<PlayerInfo>)));
        public List<PlayerInfo> ThirdDataGridView
        {
            get { return (List<PlayerInfo>)this.GetValue(ThirdDataGridViewProp); }
            set { this.SetValue(ThirdDataGridViewProp, value); }
        }

        public readonly DependencyProperty SelectedPlayerProp = DependencyProperty.Register("SelectedPlayer", typeof(PlayerInfo), typeof(Window), new UIPropertyMetadata(default(PlayerInfo)));
        public PlayerInfo SelectedPlayer
        {
            get { return (PlayerInfo)this.GetValue(SelectedPlayerProp); }
            set { this.SetValue(SelectedPlayerProp, value); }
        }

        public readonly DependencyProperty TotalPointsProp = DependencyProperty.Register("TotalPoints", typeof(string), typeof(Window), new UIPropertyMetadata("0"));
        public string TotalPoints
        {
            get { return (string)this.GetValue(TotalPointsProp); }
            set { this.SetValue(TotalPointsProp, value); }
        }

        public readonly DependencyProperty TotalSelectedPlayersProp = DependencyProperty.Register("TotalSelectedPlayers", typeof(string), typeof(Window), new UIPropertyMetadata("0"));
        public string TotalSelectedPlayers
        {
            get { return (string)this.GetValue(TotalSelectedPlayersProp); }
            set { this.SetValue(TotalSelectedPlayersProp, value); }
        }


        public MainWindow()
        {
            InitializeComponent();
            try
            {
                cbFirstTeam.ItemsSource = cbSecondTeam.ItemsSource = cbThirdTeam.ItemsSource = teams = dataSupplier.GetTeams().ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            this.DataContext = this;
        }

        private void cbFirstTeam_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (teams.Contains(cbFirstTeam.Text.Trim()))
            {
                FirstDataGridView = dataSupplier.GetTeamInfoByNameAndValue(cbFirstTeam.Text);
            }
        }

        private void cbSecondTeam_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (teams.Contains(cbSecondTeam.Text))
            {
                SecondDataGridView = dataSupplier.GetTeamInfoByNameAndValue(cbSecondTeam.Text);
            }
        }

        private void cbThirdTeam_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (teams.Contains(cbThirdTeam.Text))
            {
                ThirdDataGridView = dataSupplier.GetTeamInfoByNameAndValue(cbThirdTeam.Text);
            }
        }

        private void dgPlayerSelected_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var updateResult = UpdateDreamTeam((PlayerInfo)SelectedPlayer);
            if (!(bool)updateResult.Item1)
            {
                MessageBox.Show(updateResult.Item2);
            }
        }



        private void dgDreamTeamRemovePlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            dreamDataGridView.Remove(SelectedPlayer);
            TotalPoints = dreamDataGridView.Sum(x => x.Points).ToString();
            TotalSelectedPlayers = dreamDataGridView.Count.ToString();
        }

        private void button_Click_Submit(object sender, RoutedEventArgs e)
        {
            SubmitData();
        }

        private void SubmitData()
        {
            if (dreamDataGridView.Count != 0)
            {
                if (dreamDataGridView.Count == 10)
                {
                    if (!string.IsNullOrEmpty(cbCaptainName.Text) && dreamDataGridView.Any(x => x.Name.Equals(cbCaptainName.Text.Trim())))
                    {
                        if (!string.IsNullOrEmpty(cbViseCaptainName.Text) && dreamDataGridView.Any(x => x.Name.Equals(cbViseCaptainName.Text.Trim())))
                        {
                            if (!string.IsNullOrEmpty(txtDreamTeam.Text))
                            {
                                try
                                {
                                    // Save data to database
                                    lock (syncLock)
                                    {
                                        dataSupplier.UpdateDreamTeamInDb(txtDreamTeam.Text, cbCaptainName.Text, cbViseCaptainName.Text, dreamDataGridView.ToList());
                                    }
                                    MessageBox.Show("Your Information is saved.");
                                    ClearWindow();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Error while saving data in Database : \n Message: " + ex.Message + "\nAlso read inner exception :" + ex.InnerException);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Don't you wanna name your team?");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Either vise captain is not selected or selected vise captain do not exits in dream team");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Either captain is not selected or selected captain do not exits in dream team");
                    }

                }
                else
                {

                    MessageBox.Show("Dream Team should have 10 players");
                }
            }
            else
            {
                MessageBox.Show("There is no player in your dream team.\nPlease select some players from above three team by double clicking on names");
            }
        }

        private Tuple<bool, string> UpdateDreamTeam(PlayerInfo selectedPlayer)
        {
            bool valid = true;
            string reason = string.Empty;
            lock (syncLock)
            {
                if (dreamDataGridView != null && selectedPlayer != null)
                {
                    if ((dreamDataGridView.Sum(value => value.Points) + selectedPlayer.Points) <= 100)
                    {
                        if (dreamDataGridView.Any(x => (bool)x.IsGirlPlayer) || dreamDataGridView.Count < 9)
                        {
                            if (dreamDataGridView.Count < 10)
                            {
                                if (!dreamDataGridView.Contains(selectedPlayer))
                                {
                                    dreamDataGridView.Add(selectedPlayer);
                                    TotalPoints = dreamDataGridView.Sum(x => x.Points).ToString();
                                    TotalSelectedPlayers = dreamDataGridView.Count.ToString();
                                }
                            }
                            else
                            {
                                valid = false;
                                reason = "You can't have more than 10 players in your team";
                            }
                        }
                        else
                        {
                            valid = false;
                            reason = "You should select at least one female player in your team";
                        }
                    }
                    else
                    {
                        valid = false;
                        reason = "You have exceed 100 credit points";
                    }
                }
                else
                {
                    valid = false;
                    reason = "No Players to add in Dream Team";
                }
            }

            return Tuple.Create(valid, reason);
        }
        private void ClearWindow()
        {
            cbFirstTeam.Text = string.Empty;
            cbSecondTeam.Text = string.Empty;
            cbThirdTeam.Text = string.Empty;
            cbCaptainName.Text = string.Empty;
            cbViseCaptainName.Text = string.Empty;

            FirstDataGridView.Clear();
            SecondDataGridView.Clear();
            ThirdDataGridView.Clear();
            dreamDataGridView.Clear();

            txtDreamTeam.Text = string.Empty;
            TotalPoints = string.Empty;
            TotalSelectedPlayers = string.Empty;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime selectedDate = dpDreamTeamPlayerData.SelectedDate.Value.Date;
                if (selectedDate < DateTime.Now.Date)
                {
                    List<string> dreamTeamsForCb = dataSupplier.GetDreamTeamsByDate(selectedDate);
                    if (dreamTeamsForCb != null)
                    {
                        DreamTeamsByDate = dreamTeamsForCb;
                    }

                }
                else if (selectedDate == DateTime.Now.Date)
                {
                    MessageBox.Show("Sorry, I can't show other dream teams before results");
                }
                else if (selectedDate > DateTime.Now.Date)
                {
                    MessageBox.Show("Tumko match hone se phle hi result chaiye!!!\nYou can only see results after match is completed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbTeamNames_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpDreamTeamPlayerData.SelectedDate.HasValue)
                {
                    DreamTeamPlayersDataView = dataSupplier.GetDreamTeamData(dpDreamTeamPlayerData.SelectedDate.Value.Date, cbTeamNames.SelectedItem.ToString().Trim());
                    TotalScoredPoints = DreamTeamPlayersDataView.Sum(x => x.totalPoints).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


}
