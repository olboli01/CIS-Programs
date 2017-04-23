// Program 3
// CIS 200
// Fall 2016
// Due: 11/15/2016
// By: C2327 

// File: Prog2Form.cs
// This class creates the main GUI for Program 3. It provides a
// File menu with About and Exit, Open & save. Also an Insert menu with Address and
// Letter items and edit menu, and a Report menu with List Addresses and List Parcels
// items.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {

        private UserParcelView upv; // The UserParcelView

        

        private BinaryFormatter formatter = new BinaryFormatter();// object for serializing recordsSerializables in binary format
        private FileStream output = null; // stream to write to file 

        private BinaryFormatter reader = new BinaryFormatter();//object for deserialzing recordserializable in binary format
        private FileStream input = null; //stream to read from file

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test addresses are
        //                added to the list of addresses
        public Prog2Form()
        {
            InitializeComponent();

            upv = new UserParcelView();


            //// Test Data - Magic Numbers OK
            //upv.AddAddress("John Smith", "123 Any St.", "Apt. 45",
            //    "Louisville", "KY", 40202); // Test Address 1
            //upv.AddAddress("Jane Doe", "987 Main St.", "",
            //    "Beverly Hills", "CA", 90210); // Test Address 2
            //upv.AddAddress("James Kirk", "654 Roddenberry Way", "Suite 321",
            //    "El Paso", "TX", 79901); // Test Address 3
            //upv.AddAddress("John Crichton", "678 Pau Place", "Apt. 7",
            //    "Portland", "ME", 04101); // Test Address 4
            //upv.AddAddress("John Doe", "111 Market St.", "",
            //    "Jeffersonville", "IN", 47130); // Test Address 5
            //upv.AddAddress("Jane Smith", "55 Hollywood Blvd.", "Apt. 9",
            //    "Los Angeles", "CA", 90212); // Test Address 6
            //upv.AddAddress("Captain Robert Crunch", "21 Cereal Rd.", "Room 987",
            //    "Bethesda", "MD", 20810); // Test Address 7
            //upv.AddAddress("Vlad Dracula", "6543 Vampire Way", "Apt. 1",
            //    "Bloodsucker City", "TN", 37210); // Test Address 8

            //upv.AddLetter(upv.AddressAt(0), upv.AddressAt(1), 3.95M);                     // Letter test object
            //upv.AddLetter(upv.AddressAt(2), upv.AddressAt(3), 4.25M);                     // Letter test object
            //upv.AddGroundPackage(upv.AddressAt(4), upv.AddressAt(5), 14, 10, 5, 12.5);    // Ground test object
            //upv.AddGroundPackage(upv.AddressAt(6), upv.AddressAt(7), 8.5, 9.5, 6.5, 2.5); // Ground test object
            //upv.AddNextDayAirPackage(upv.AddressAt(0), upv.AddressAt(2), 25, 15, 15,      // Next Day test object
            //    85, 7.50M);
            //upv.AddNextDayAirPackage(upv.AddressAt(2), upv.AddressAt(4), 9.5, 6.0, 5.5,   // Next Day test object
            //    5.25, 5.25M);
            //upv.AddNextDayAirPackage(upv.AddressAt(1), upv.AddressAt(6), 10.5, 6.5, 9.5,  // Next Day test object
            //    15.5, 5.00M);
            //upv.AddTwoDayAirPackage(upv.AddressAt(4), upv.AddressAt(6), 46.5, 39.5, 28.0, // Two Day test object
            //    80.5, TwoDayAirPackage.Delivery.Saver);
            //upv.AddTwoDayAirPackage(upv.AddressAt(7), upv.AddressAt(0), 15.0, 9.5, 6.5,   // Two Day test object
            //    75.5, TwoDayAirPackage.Delivery.Early);
            //upv.AddTwoDayAirPackage(upv.AddressAt(5), upv.AddressAt(3), 12.0, 12.0, 6.0,  // Two Day test object
            //    5.5, TwoDayAirPackage.Delivery.Saver);
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Program 3{NL}By: C2327 {NL}CIS 200{NL}Fall 2016",
                "About Program 3");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result

            if (result == DialogResult.OK) // Only add if OK
            {
                try
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        int.Parse(addressForm.ZipText)); // Use form's properties to create address
                }
                catch (FormatException) // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return;
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                try
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        decimal.Parse(letterForm.FixedCostText)); // Letter to be inserted
                }
                catch (FormatException) // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Parcels:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }




        //Precondition: File > Open activated 
        //Postcondition: Read and deserialize file user selected and load into the form 
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;// name of file to save data
            UserParcelView open;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();//retrieve result 
                fileName = fileChooser.FileName; //get specified name  
            }
            //ensure user clicked OK
            if (result == DialogResult.OK)
            
            {
                //Show error is user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("invalid File Name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        //Create filestream to get read access to file
                        input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                    
                        open = (UserParcelView)reader.Deserialize(input);//read the data and parse as a upv type.
                        upv = open;
                    }
                    //handle exception when there are no records serializables in the file
                    catch (IOException)
                    {
                        MessageBox.Show("Error reading from file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SerializationException)
                    {
                                                //notify user if no RecordSerializables in file
                        MessageBox.Show("No more records in file", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    
                }
            }
        }

        //Precondition: File > Save activated
        //Postcondition: selected file can be saved 
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create and show dialog box enabling user to save the file 
            
            DialogResult result;
            string fileName; //name of file to save data

            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; //let user create file

                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;//get specified file name 
            }

            //Ensure user clicked OK
            if (result == DialogResult.OK)
            {
                //show error if specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid file name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    //save the file via filestream if user specified valid file
                    try
                    {
                        //open file with write access
                        output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                        formatter.Serialize(output, upv);
                    }
                    //handle exception if there is a problem opening the file
                    catch (IOException)
                    {

                        //notify user if file could not be opened 
                        MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SerializationException)
                    {
                        MessageBox.Show("Error Reading From File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }


        ////Precondition: Edit > Address activated.
        ////Postcondtion: Address that has been selected to edit is displayed
        private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<Address> addressList;//List of Addresses
            addressList = upv.AddressList;
            DialogResult result;

            editForm editAddressForm = new editForm(addressList);//transfer list of addresses
            result = editAddressForm.ShowDialog();

            if (result == DialogResult.OK)//user selects ok
            {

                AddressForm editAddress = new AddressForm();
                
                int index; //variable to hold selectedAddress index value
                index = editAddressForm.SelectedAddress;
                Address a = addressList[index];

                //gets values to populate form 
                editAddress.AddressName = a.Name;
                editAddress.Address1 = a.Address1;
                editAddress.Address2 = a.Address2;
                editAddress.City = a.City;
                editAddress.State = a.State;
                editAddress.ZipText = a.Zip.ToString();
                DialogResult result3 = editAddress.ShowDialog();

                if (result3 == DialogResult.OK)
                {
                    //populates form after validation 
                    editAddress.AddressName = a.Name;
                    editAddress.Address1 = a.Address1;
                    editAddress.Address2 = a.Address2;
                    editAddress.City = a.City;
                    editAddress.State = a.State;
                    editAddress.ZipText = a.Zip.ToString();
                }



          }
       }
              
    }


  }
    
   
