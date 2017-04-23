// Program 1A
// CIS 200-01
// Fall 2016
// Due: 10/11/16
// Grading ID: C2327
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
   public abstract class AirPackage : Package
    {
        const double Heavy = 75;
        const double Large = 100;
        // Precondition:  None
        // Postcondition: The Air Package is created with the specified values for
        //                origin address and destination address, length, width, height and weight. 
        public AirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
              : base(originAddress, destAddress, length, width, height, weight)
        {
           
        }
        //precondition: none
        //postcondition: evaluates whether the package is heavy or not heavy and returns the value. 
        public bool IsHeavy()
        {
            bool heavy = true;
            bool notHeavy = false;


            if (Weight >= Heavy)
                return heavy;
            else
                return notHeavy;
        }
        //precondition: none
        //postcondition: evaluates whether the package is large or not large and returns the value. 
        public bool IsLarge()
        {
            bool large = true;
            bool notLarge = false;
            if ((Length + Width + Height) >= Large)
                return large;
            else
                return notLarge;
        }
        // Precondition:  None
        // Postcondition: A String with the Air Package's data has been returned
        public override string ToString()
        {
            return "Large Package:" + IsLarge().ToString() + Environment.NewLine + "Heavy Package" + IsHeavy().ToString() + Environment.NewLine + base.ToString();
        }
    }
}
