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

namespace View
{
    /// <summary>
    /// Interaction logic for Add_Contact_View.xaml
    /// </summary>
    public partial class Add_Contact_View : Window
    {
        public Add_Contact_View()
        {
            InitializeComponent();
        }

        private void BoutonNewContact_Click(object sender, RoutedEventArgs e)
        {

            BLL.BLL BLL_AddContact = new BLL.BLL();
            if (NewContactFirtsName.Text.Trim().CompareTo("") != 0 || NewContactSecondName.Text.Trim().CompareTo("") != 0 || NewContactEmail.Text.Trim().CompareTo("") != 0 || NewContactPhone.Text.Trim().CompareTo("") != 0 || NewContactAge.Text.Trim().CompareTo("") != 0) { 
                BLL_AddContact.AddNewContact(NewContactFirtsName.Text, NewContactSecondName.Text, NewContactEmail.Text, NewContactPhone.Text, NewContactAge.Text);
            NewContactFirtsName.Text = "";
            NewContactSecondName.Text = "";
            NewContactEmail.Text = "";
            NewContactPhone.Text = "";
            NewContactAge.Text = "";
            addContactMessage.Content = "Contact insert";
            }
            else
            {
                addContactMessage.Content = "Insert new contact informations";
            }
        }

        private void SignOutNewContact_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fenetreLogin = new MainWindow();
            fenetreLogin.Show();
            this.Close();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            Contacts_View menu = new Contacts_View();
            menu.Show();
            this.Close();
        }
    }
}
