
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
    public class NextDayAirPackage:AirPackage
    {//precondition: none
        //postcondition: The Next Day Air Package is created with the specified values for
        //                origin address and destination address, length, width, height, weight, and express fee. 
        public NextDayAirPackage(Address originAddress, Address destAddress, double length, double height, 
            double width, double weight, decimal expressFee):base(originAddress, destAddress, length, width, height, weight)
        {
           
        }

        public decimal ExpressFee
        {
            //precondition: none
            //postcondition: express fee has been returned
            get;
        }

        public override decimal CalcCost()
        {
            //precondition: none
            //postcondition: The next day air package's calculated cost has been returned
            const decimal dim_rate = .40M;
            const decimal weight_rate = .30M;
            decimal lengthDec = Convert.ToDecimal(Length);
            decimal heightDec = Convert.ToDecimal(Height);
            decimal widthDec = Convert.ToDecimal(Width);
            decimal weightDec = Convert.ToDecimal(Weight);
            decimal weightCost = .25M * (weightDec);
            decimal sizeCost = .25M * (lengthDec + widthDec + heightDec);

            decimal baseCost = dim_rate *(lengthDec+widthDec+ heightDec) + weight_rate * (weightDec) + ExpressFee;
            if (IsHeavy() == true)
                return baseCost + weightCost;
            if (IsLarge() == true)
                return baseCost + sizeCost;
            if (IsLarge() == true && IsHeavy() == true)
                return baseCost + weightCost + sizeCost;
            else
                return baseCost;
        }
        // Precondition:  None
        // Postcondition: A String with the next day Air Package's data has been returned
        public override string ToString()
        {
            return "Next Day Air Package" + Environment.NewLine + base.ToString();
        }
    }
}
