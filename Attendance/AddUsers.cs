﻿using System;
using System.Windows.Forms;

namespace Attendance
{
    public partial class AddUsers : Form
    {

        public AddUsers()
        {
            InitializeComponent();
        }
        
        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateInformation();
            AddServiceUser(isValid);
        }
        bool ValidateInformation()
        {
            bool isValid = true;
            errorProvider1.Clear();
            
            if (SOSCareNumber.Text == "" )          { errorProvider1.SetError(SOSCareNumber, "Please set SOS Care Number."           ); isValid = false; }
            if (FirstName.Text	   == "" )          { errorProvider1.SetError(FirstName,	 "Please set First name."		         ); isValid = false; }
            if (LastName.Text	   == "" )		    { errorProvider1.SetError(LastName,	     "Please set Last name."		         ); isValid = false; }
            if (DOB.Value		   == DateTime.Now) { errorProvider1.SetError(DOB,		     "Please set Date of Birth."	         ); isValid = false; }
            if (DOB.Value		   >= DateTime.Now) { errorProvider1.SetError(DOB,		     "Date of Birth cannoy be a future date."); isValid = false; }
            if (Address.Text	   == "" )		    { errorProvider1.SetError(Address,	     "Please set Address."				     ); isValid = false; }
            if (PostCode.Text      == "" )		    { errorProvider1.SetError(PostCode,	     "Please set Post Code."				 ); isValid = false; }
            if (ProgramOfCare.Text == "" )          { errorProvider1.SetError(ProgramOfCare, "Please set Program of Care."		     ); isValid = false; }
            if (Transport.Text     == "" )          { errorProvider1.SetError(Transport,	 "Please set method of Transport."	     ); isValid = false; }
            
            if (!Monday.Checked    &&
                !Tuesday.Checked	 &&
                !Wednesday.Checked &&
                !Thursday.Checked	 &&
                !Friday.Checked)
            {
                if (!Monday.Checked   ) { errorProvider1.SetError(Monday,	 "Please select one or more days of attendance."); }
                if (!Tuesday.Checked  ) { errorProvider1.SetError(Tuesday,	 "Please select one or more days of attendance."); }
                if (!Wednesday.Checked) { errorProvider1.SetError(Wednesday, "Please select one or more days of attendance."); }
                if (!Thursday.Checked ) { errorProvider1.SetError(Thursday,	 "Please select one or more days of attendance."); }
                if (!Friday.Checked	  ) { errorProvider1.SetError(Friday,	 "Please select one or more days of attendance."); }
                
                isValid = false;
            }
            
            return isValid;
        }
        void AddServiceUser(bool isValid)
        {
            if (isValid)
            {
                try
            	{
                    Data.AddUser(
                        SOSCareNumber.Text,
                        FirstName.Text,
                        LastName.Text,
                        DOB.Value,
                        Address.Text,
                        PostCode.Text,
                        ProgramOfCare.Text,
                        Transport.Text,
            
                        Monday.Checked,
                        Tuesday.Checked,
                        Wednesday.Checked,
                        Thursday.Checked,
                        Friday.Checked
                        );
            	    Clear();
            	}
            	catch (Exception ex)
            	{
            	    MessageBox.Show("Adding Service User Failed. Error : " + ex.Message);
            	}
            }
        }
        void Clear()
        {
        		SOSCareNumber.Text = "";
        		FirstName.Text     = "";
        		LastName.Text      = "";
        		DOB.Value          = DateTime.Now;
        		Address.Text       = "";
        		PostCode.Text      = "";
        		ProgramOfCare.Text = "";
        		Transport.Text     = "";
        
        		Monday.Checked      = false;
        		Tuesday.Checked     = false;
        		Wednesday.Checked   = false;
        		Thursday.Checked    = false;
        		Friday.Checked      = false;
        }
        private void MainMenu_Click(object sender, EventArgs e)
        {
        		MainMenu frm = new MainMenu();
        		frm.Show();
        		this.Hide();
        }

        private void AddUsers_Load(object sender, EventArgs e)
        {
            DOB.Value = DateTime.Now;
        }

        private void ReadOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
