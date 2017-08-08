using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//WHAT THE CALCULATOR SHOULD DO.
/// <summary>
/// 1. Onclick button show the button clicked value in the textbox
/// 2. Let our Operators the +, -, *, and / take the value in the textbox and store them whenever
/// any of these buttons are clicked.
/// 3. Let the Equalto button do the calculation by accepting the first value user clicked 
/// which has been stored in the operator block and displace the total result on textbox.
/// 
/// </summary>
namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtInput.Enabled = false; // so that user cant type inside the txtbox
        }
        //variables to hold operands
      
        private double valHolder1;
        private double valHolder2;
        //private bool AddButtonCliked = true;
       //private bool MinusButtonCliked = true;
        //Varible to hold temporary values
        //True if "." is use else false;
        private bool hasOn = false;
        private bool hasDecimal = false;
        private bool inputStatus = true;
        bool result = false;
        private void Buttonfigureone_Click(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            
            if (hasOn == true)
            {
                hasOn = true;
                txtInput.Enabled = true;
                txtInput.ReadOnly = true; //read only mode of textbox
                txtInput.RightToLeft = RightToLeft.Yes;
               
            } 
           
           

        }

      
        private void CmdButtonDecimal_Click(object sender, EventArgs e)
        {
            if (hasOn)
            {
                clearZeroOnClicked();

                if (inputStatus)
                {
                    if (!hasDecimal)
                    {
                        if (txtInput.Text.Length != 0)
                        {
                            if (txtInput.Text != "0")
                            {
                                txtInput.Text += CmdButtonDecimal.Text;
                                //Toggle the flag to true (only 1 decimal per calculation)
                                //hasDecimal = true;

                            }

                        }
                        else
                        {
                            //Since the length isnt > 1
                            //make the text 0.
                            txtInput.Text = "0.";
                            //hasDecimal = true;
                        }
                    }

                }
            }
        }

        //Declare a variable that will check which button has been clicked by user.
        bool plusButtonClicked = false;
        bool minusButtonClicked = false;

        private void cmdButtonAdd_Click(object sender, EventArgs e)
        {
          
                if (hasOn )
                {

                    //Make sure out input box has a value
                    if (txtInput.Text.Length != 0)

                    {
                    
                        valHolder1 += double.Parse(txtInput.Text);
                        // same as valHolder1 =valHolder1 + double.Parse(txtInput.Text);
                        txtInput.Clear();
                    plusButtonClicked = true;
                    minusButtonClicked = false;
                    DividedButtonClicked = false;
                    timesButtonClicked = false;
                    }

                }

            }

        private void cmdButtonSubtr_Click(object sender, EventArgs e)
        {

            if (hasOn)
            {
                

                    //Make sure the input box has a value
                    if (txtInput.Text.Length != 0)
                    {
                    plusButtonClicked = false;
                    minusButtonClicked = true;
                    DividedButtonClicked = false;
                    timesButtonClicked = false;
                    valHolder1 += double.Parse(txtInput.Text);
                        txtInput.Clear();
                    

                }
            }
        }
        private void cmdButtonOff_Click(object sender, EventArgs e)
        {

            // Check if the Calculator is on
            if (hasOn)
            {


                //Make sure the input box has a value
                if ((txtInput.Text.Length != 0)||(txtInput.Text.Length == 0))
                {
                    // Then off the Calculator and clear it.
                    hasOn = false;
                    txtInput.Clear();
                    txtInput.Enabled = false;
                }
            }
        }
        private bool equalButtonClicked = false;
        private void CmdButtonEqualto_Click(object sender, EventArgs e)
        {
            equalButtonClicked = true;
            if (plusButtonClicked == true)
            {
               result = true;
                //Doing the addition by adding 
                plusButtonClicked = true;
                minusButtonClicked = false;
                DividedButtonClicked = false;
                timesButtonClicked = false;
                valHolder2 = valHolder1 + double.Parse(txtInput.Text);
               
                
            }
            else if (minusButtonClicked == true)
            {

                plusButtonClicked = false;
                minusButtonClicked = true;
                DividedButtonClicked = false;
                timesButtonClicked = false;
                valHolder2 = valHolder1 - double.Parse(txtInput.Text);
               
            }
            else if (timesButtonClicked == true)

            {
                plusButtonClicked = false;
                minusButtonClicked = false;
                DividedButtonClicked = false;
                timesButtonClicked = true;
                valHolder2 = valHolder1 * double.Parse(txtInput.Text);
               
            }
            else if (DividedButtonClicked == true)
            {
                plusButtonClicked = false;
                minusButtonClicked = false;
                DividedButtonClicked = true;
                timesButtonClicked = false;
                valHolder2 = valHolder1 / double.Parse(txtInput.Text);
                
            }


           txtInput.Text = valHolder2.ToString();
           
            valHolder1 = 0;
            
        }


        //When we on this calc. 0 shows on the textbox so now we 
        // Declare a variable that will be use to store the 0 when the ON button is  clicked.
        //So that it will not be added to any number user clicked.
        //The valHolder4 will do its assignment inside each button or we write a constructor for it.
        // Take a look at the constructor named clearZeroOnClicked(). It does the rest of the work.
        double valHolder3;
        double valHolder4;
        private void cmdButtonOn_Click(object sender, EventArgs e)
        {
            if (!hasOn)
            {
                


                hasOn = true;
                txtInput.Enabled = true;
                txtInput.Text = "0";
                   
                    // just take off the zero and store it in valHolder3
                    //we dont want the 0 to be at the front of any number user clicked
                    // So we dont need the zero , than to prove that the calculator has on by showing whenever the ON 
                    //button is clicked.
                    valHolder3 += double.Parse(txtInput.Text);
                    //txtInput.Clear();
                }
            }
        
        private void cmdButtonDel_Click(object sender, EventArgs e)
        {
            if (hasOn)
            {
                if (txtInput.Text.Length != 0)
                {
                    txtInput.Clear();
                    
                }
            }
        }

        private void cmdButtonAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (hasOn)
            {


                //Make sure out input box has a value
                if (txtInput.Text.Length != 0)

                {





                    valHolder1 += double.Parse(txtInput.Text);
                    //valHolder1 = double.Parse(txtInput.Text);
                    txtInput.Clear();



                }

            }
        }
        bool timesButtonClicked = false;
        bool DividedButtonClicked = false;
        private void cmdButtonMultip_Click(object sender, EventArgs e)
        {
            if (hasOn)
            {
                if (txtInput.Text.Length != 0)

                {
                    plusButtonClicked = false;
                    minusButtonClicked = false;
                    DividedButtonClicked = false;
                    timesButtonClicked = true;
                    valHolder1 += double.Parse(txtInput.Text);
                    txtInput.Clear();
                    
                }
            }
        }

        private void cmdButtonDivision_Click(object sender, EventArgs e)
        {
            if (hasOn)
            {
                if (txtInput.Text.Length != 0)
                {
                    plusButtonClicked = false;
                    minusButtonClicked = false;
                    DividedButtonClicked = true;
                    timesButtonClicked = false;
                    valHolder1 += double.Parse(txtInput.Text);
                    txtInput.Clear();
                    
                }
            }
        }
        private void clearZeroOnClicked()
        {
            if (hasOn)
            {
                if (txtInput.Text == "0")
                {
                    valHolder4 = valHolder3 + double.Parse(txtInput.Text);
                    txtInput.Clear();
                }
            }
        }
        // bool squareButtonClicked;
        private bool clearSquareR = false;
        private void cmdBtnSquarer_Click(object sender, EventArgs e)
        {
            if (hasOn)
            {

                //Make sure out input box has a value
                if (txtInput.Text.Length != 0)

                {

                    valHolder1 += double.Parse(txtInput.Text);
                    txtInput.Clear();
                    double total = valHolder1 * valHolder1;
                    //valHolder1 = double.Parse(txtInput.Text);
                    
                    txtInput.Text = total.ToString();
                    valHolder1 = 0;
                    clearSquareR = true;

                }

            }
        }
        
        private void myButton(object sender, EventArgs e)
        {
            if (hasOn)
            {
                Button MyButton = sender as Button;
                clearZeroOnClicked();
                if ((equalButtonClicked)||(clearSquareR))
                {
                    txtInput.Clear();
                    equalButtonClicked = false;
                    clearSquareR = false;
                }
                txtInput.Text += MyButton.Text;
            }
        }
    }
}
