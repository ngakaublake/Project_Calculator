using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;
        
        void btnCommon_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            if (LblResult.Text == "0"|| isOperatorClicked)
            {
                isOperatorClicked = false;
                LblResult.Text = button.Text;
            }
            else
            {
                LblResult.Text += button.Text;
            }
            LblEquation.Text += button.Text;
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "0";
            LblEquation.Text = "";
        }

        private void btnX_Clicked(object sender, EventArgs e)
        {
            string number = LblResult.Text;
            if(number!="0")
            {
                number = number.Remove(number.Length - 1, 1);
                if(string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";

                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }

        public void btnCommonOperation_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(LblResult.Text);
            LblEquation.Text += button.Text;
        }

        private async void btnPerc_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number =LblResult.Text;
                if(number!="0")
                {
                    decimal percentValue=Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    LblResult.Text = result;
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error",ex.Message,"Ok");
            }
        }

        private void btnEqual_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(LblResult.Text);
                string finalResult = Calculate(firstNumber, secondNumber).ToString("0.##");
                LblResult.Text = finalResult;
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        public decimal Calculate(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            if (operatorName == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operatorName == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (operatorName == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (operatorName == "/")
            {
                result= firstNumber / secondNumber;
            }
            return result;
        }
    }
}
