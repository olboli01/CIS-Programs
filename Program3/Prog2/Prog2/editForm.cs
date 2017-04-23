using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    
    public partial class editForm : Form
    {
        private List<Address> addressList;
        const int MIN_ADDRESSES = 1;

        public editForm(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
        }

       
        public int SelectedAddress
        {  //Precondition: user selects address from addressComboBox
           //Postcondition: selected index is returned 
            get
            {
                return AddressComboBox.SelectedIndex;
            }
            //Precondtion: verify selction is valid
            //Postcondition: set index 
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    AddressComboBox.SelectedIndex = value;
                else
                throw new ArgumentOutOfRangeException("Index not valid");
            }
        }

        //Precondtion: none
        //Postcondition: items added to combo box on form load 
        private void editForm_Load(object sender, EventArgs e)
        {


            if (addressList.Count < MIN_ADDRESSES) // 
            {
                MessageBox.Show("Need " + MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                this.DialogResult = DialogResult.Abort; // 
            }
            else
            {
                foreach (Address a in addressList)
                {
                    AddressComboBox.Items.Add(a.Name);
                }
            }
        }

        //Precondition: none
        //Postcondidtion: OK button clicked and validated 
        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;

        }

        //Precondition: none
        //Postcondition: cancel button clicked and form closes 
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //Precondition: none
        //Postcondition: validate form
        private void AddressComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (AddressComboBox.SelectedIndex == -1)//none selected
            {
                e.Cancel = true;
                errorProvider1.SetError(AddressComboBox, "Please select an address to edit.");//Displays error 
            }
        }

        //Precondition: error provider present 
        //Postcondition: cleared error
        private void AddressComboBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(AddressComboBox, ""); //Clears error 
        }
    }
}
