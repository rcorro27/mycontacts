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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BoutonLogin_Click(object sender, RoutedEventArgs e)
        {

            BLL.BLL bll = new BLL.BLL(iD.Text);
            if(bll.login(password.Text) == true)
            {
                Contacts_View fenetreContact = new Contacts_View();
                fenetreContact.Show();
                this.Close();

            }
            else
            {
                messageLogin.Content = "Incorrect ID or password";
            }
            


        }

        private void Incription_Click(object sender, RoutedEventArgs e)
        {
            Register_View fenetreRegister = new Register_View();
            fenetreRegister.Show();
            this.Close();
        }
    }
}
