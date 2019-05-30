using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatSignalRWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Label_Forgot_account_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Label_Sign_Up_NowMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Label_Gorgot_Account_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelGorgotAccount.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF81D6FD");
        }

        private void Label_Gorgot_Account_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelGorgotAccount.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF00AEFF");
        }

        private void Label_Sign_Up_Now_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelSignUpNow.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFBCFBA4");
        }

        private void Label_Sign_Up_Now_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelSignUpNow.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF46FF00");
        }
    }
}
