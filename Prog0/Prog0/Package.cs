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
    public abstract class Package : Parcel
    {
        private double _length;
        private double _height;
        private double _width;
        private double _weight;
        //Precondition: none
        //Postcondition: Package is Created with specified values
        public Package(Address originAddress, Address destAddress, double length, double height, double width, double weight)
            : base(originAddress, destAddress)
        {
            Length = length;
            Height = height;
            Width = width;
            Weight = weight;
        }// end constructor

        public double Length
        {
            get
            {//precondition: none
                //postcondition: the package's length has been returned
                return _length;

            }
            // precondition: none
            //postcondition: the package's length has been set if data is valid
            set
            {
                if (value >= 0)//validation
                    _length = value;
                else
                    throw new ArgumentOutOfRangeException("Length must be >= 0");

            }
        }


        public double Height
        {//precondition: none
         //postcondition: the package's Height has been returned
            get
            {
                return _height;
            }
            // precondition: none
            //postcondition: the package's height has been set if data is valid
            set
            {
                if (value >= 0)//validation
                    _height = value;
                else throw new ArgumentOutOfRangeException("Height must be >= 0");
            }

        }

        public double Width
        {//precondition: none
         //postcondition: the package's width has been returned
            get
            {
                return _width;
            }
            // precondition: none
            //postcondition: the package's width has been set if data is valid
            set
            {
                if (value >= 0)//validation
                    _width = value;
                else
                    throw new ArgumentOutOfRangeException("Width must be >= 0");
            }
        }

        public double Weight
        {//precondition: none
         //postcondition: the package's weight has been returned
            get
            {
                return _weight;
            }
            // precondition: none
            //postcondition: the package's weight has been set if data is valid
            set
            {
                if (value >= 0)//validation
                    _weight = value;
                else
                    throw new ArgumentOutOfRangeException("Weight must be >= 0");
            }

        }
        // Precondition:  None
        // Postcondition: A String with the package's data has been returned
        public override String ToString()
        {
            return string.Format("Length:{0}{4}Height:{2}{4}{5}", Length, Width, Height, Weight, Environment.NewLine, base.ToString());

        }
    }
}

