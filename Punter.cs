using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCatsTask
{
    public abstract class Punter
    {
        public int Amount; // Amount of bid
        public bool Busted;
        public int Cash = 50; // Initial amount of money
        public int Dog; // Index of chosen bet cat
        public int myBet;
        public string myLabel;
        public string myRadioButton;
        public string name;
        public bool winningDog = false; // If you have the winner cat

        public override bool Equals(Object obj) // Overriding Equals method to allow the unit testing part to check for equality
        {
            if (obj is Punter)
            {
                var that = obj as Punter;
                return this.Amount == that.Amount && this.Cash == that.Cash;
            }

            return false;
        }
    }
}
