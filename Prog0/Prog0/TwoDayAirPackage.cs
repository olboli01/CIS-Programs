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
    public class TwoDayAirPackage : AirPackage
    {// Precondition:  None
        // Postcondition: The Two Day Air Package is created with the specified values for
        //                origin address and destination address, length, width, height, weight, and delivery type.
        public enum Delivery { Early, Saver};//enum to specify early or saver delivery 
        public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double height, double width, double weight, Delivery type)
            : base(originAddress, destAddress, length, width, height, weight)
        {

        }

        public Delivery DeliveryType
        {// Precondition:  None
         // Postcondition: returns the DeliveryType
            get;
            // Precondition:  None
            // Postcondition: sets the DeliveryType
            set;
        }

        public override decimal CalcCost()
        {
            //precondition: none
            //postcondition: The Two day air package's calculated cost has been returned
            const decimal disc_rate = .90M;
            const decimal dim_rate = .25M;
            const decimal weight_rate = .25M;
            decimal lengthDec = Convert.ToDecimal(Length);
            decimal heightDec = Convert.ToDecimal(Height);
            decimal widthDec = Convert.ToDecimal(Width);
            decimal weightDec = Convert.ToDecimal(Weight);
            decimal baseCost = dim_rate * (lengthDec + widthDec + heightDec) + weight_rate * (weightDec);

            if (DeliveryType == Delivery.Saver)
                return baseCost * disc_rate;
            else
                return baseCost;
        }
        // Precondition:  None
        // Postcondition: A String with the next day Air Package's data has been returned
        public override string ToString()
        {
            return "Two day air package" + Environment.NewLine + "Delivery type:" + DeliveryType.ToString() + 
                Environment.NewLine + "Package cost:" + CalcCost().ToString() + Environment.NewLine + base.ToString();
        }
    }
}
