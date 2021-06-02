using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCatsTask
{
    public static class Factory
    {
        static int myRandom;
        static public int GuyNumber { get; set; }
        static Factory()
        {

        }
        // Returns the right object type
        public static Punter GetAPunter(string Type)
        {
            if (Type == "Joe")
            {
                Punter xP = new Joe();
                return xP;
            }
            else if (Type == "Al")
            {
                Punter xP = new Al();
                return xP;
            }
            else
            {
                Punter xP = new Bob();
                return xP;
            }
        }

        // Sets the random winning cat.
        public static int SetTheGuyNumber()
        {
            Random myR = new Random(Guid.NewGuid().GetHashCode());
            return myRandom = myR.Next(1, 5);
        }
    }
}
