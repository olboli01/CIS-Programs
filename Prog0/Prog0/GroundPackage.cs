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
    class GroundPackage:Package
    {// Precondition:  None
     // Postcondition: The ground package is created with the specified values for
     //                origin address, destination address, length, height, width, weight.
        public GroundPackage(Address originAddress, Address destAddress, double length, double height, double width, double weight)
            : base(originAddress, destAddress, length, height, width, weight)
        {
            
        }
        
        public int ZoneDistance
        {// Precondition:  None
         // Postcondition: The ground package's zone distance has been returned
            get
            {
                const int divide = 10000;
                return Math.Abs(OriginAddress.Zip /divide - DestinationAddress.Zip / divide);

            }
        }

        //precondition: none
        //postcondition: The package's calculated cost has been returned
        public override decimal CalcCost()
        {
            const decimal dim_rate = .20M;// rate based on dimension of package
            const decimal weight_rate = .05M;//rate based on weight of package
            decimal lengthDec = Convert.ToDecimal(Length);
            decimal heightDec = Convert.ToDecimal(Height);
            decimal widthDec = Convert.ToDecimal(Width);
            decimal weightDec = Convert.ToDecimal(Weight);
            decimal calculatedCost = (dim_rate * (lengthDec + widthDec + heightDec) + weight_rate * (ZoneDistance + 1) * weightDec);

            return calculatedCost;
        }

        // Precondition:  None
        // Postcondition: A String with the ground package's data has been returned
        public override string ToString()
        {
            return string.Format("Ground Package: {2}{1}{2}Zone Distance: {0}{2}{2}Calculated Cost: {3}", ZoneDistance, base.ToString(), Environment.NewLine, CalcCost());
        }
    }
}
