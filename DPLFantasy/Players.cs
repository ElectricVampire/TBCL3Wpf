using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPLFantasy
{
    public class PlayerInfo
    {
        public int Points { get; set; }
        public string Name { get; set; }

        private bool isGirl;
        public bool? IsGirlPlayer
        {
            get { return isGirl;}
            set
            {
                if (value == null)
                {
                    isGirl = false;
                }
                else
                {
                    isGirl = (bool)value;
                }               
            }
        }

        public string Team_Id { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
