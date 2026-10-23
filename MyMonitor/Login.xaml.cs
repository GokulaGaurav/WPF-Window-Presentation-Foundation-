using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Path = System.IO.Path;

namespace MyMonitor
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string mainAppData;
        public Login()
        {
            InitializeComponent();
            mainAppData = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            mainAppData = Path.Combine(mainAppData, "MyMonitor");
            if (!Directory.Exists(mainAppData))
            {
                Directory.CreateDirectory(mainAppData);
            }
        }

        private void btnlog_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtuser.Text))
            {
                string filename=Path.Combine(mainAppData, txtuser.Text+ ".txt");
                if (File.Exists(filename))
                {
                    string content=File.ReadAllText(filename);
                    string[] splitcont = content.Split("|");
                    if (splitcont[0]==txtuser.Text && splitcont[1] == pwpass.Password)
                    {
                        MessageBox.Show("Login Successfull!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username and Password");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username and Password");
                }
            }
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {

            erruser.Text = ErrorDisply(txtreguser.Text, "please enter the username");
            errpass.Text = ErrorDisply(pwregpass.Password, "Please Enter the Password");
            errage.Text = ErrorDisply(txtage.Text, "Please Enter the age");
            erremail.Text = ErrorDisply(txtemail.Text, "Please Enter the Email Address");


            if (isValue(txtage.Text) == true)
            {
                int age = Convert.ToInt16(txtage.Text);

                if (age > 18 == false)
                {
                    errage.Text = "Age Should be More than 18!";
                }
                else
                {
                    errage.Text = "";
                }
            }

            // Email validation
            if (isValue(txtemail.Text) == true)
            {
                if (txtemail.Text.Contains("@") == true &&
                    txtemail.Text.Contains(".") == true)
                {
                    erremail.Text = "";
                }
                else
                {
                    erremail.Text = "Please Enter the valid Email Address!";
                }
            }

            if (erruser.Text != "" || errpass.Text != "" || errage.Text != "" || erremail.Text != "")
            {
                MessageBox.Show("Please fill out the required fields!");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtreguser.Text))
                {
                    string filename = Path.Combine(mainAppData, txtreguser.Text + ".txt");
                    if (File.Exists(filename))
                    {
                        MessageBox.Show("Username already exists!");
                    }
                    else
                    {
                        string content = txtreguser.Text + "|" + pwregpass.Password + "|" + txtage.Text + "|" + txtemail.Text;
                        File.WriteAllText(filename, content);
                        MessageBox.Show("Registeration Successful!");
                    }

                }
            }

            
        }

        private bool isValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string ErrorDisply(string value, string errormessage)
        {
            if (isValue(value) == false)
            {
                return errormessage;
            }
            else
            {
                return "";
            }
        }

    }

}