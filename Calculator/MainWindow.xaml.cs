using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calciwbtn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string firstnumber = "";
        string secondnumber = "";
        string oper = " ";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_click(object sender, RoutedEventArgs e)
        {
            Button btnumber = (Button)sender;
            if(oper == " ")
            {
                firstnumber = firstnumber + btnumber.Content.ToString();
                rslt.Text = firstnumber;
            }
            else
            {
                secondnumber = secondnumber + btnumber.Content.ToString();
                rslt.Text = secondnumber;
            }
        }

        private void Oper_Click(object sender, RoutedEventArgs e)
        {
            Button btoper = (Button)sender;
            oper =btoper.Content.ToString();
        }
        private void btneq_Click(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt16(firstnumber);
            int num2 = Convert.ToInt16(secondnumber);
            if (oper == "*")
            {
                int rl = num * num2;
                rslt.Text = Convert.ToString(rl);
            }
            else if (oper == "+")
            {
                int rl = num + num2;
                rslt.Text = Convert.ToString(rl);
            }
            else if(oper == "-")
            {
                int rl = num - num2;
                rslt.Text = Convert.ToString(rl);
            }
            else
            {
                int rl = num / num2;
                rslt.Text = Convert.ToString(rl);
            }
        }

        private void btnclr_Click(object sender, RoutedEventArgs e)
        {
            firstnumber = "";
            secondnumber = "";
            oper = " ";
            rslt.Text = "";
        }
    }
}