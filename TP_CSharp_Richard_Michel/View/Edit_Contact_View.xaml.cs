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
    /// Interaction logic for Edit_Contact_View.xaml
    /// </summary>
    public partial class Edit_Contact_View : Window
    {
        public Edit_Contact_View()
        {
            InitializeComponent();
        }

        private void BoutonEditContact_Click(object sender, RoutedEventArgs e)
        {
            BLL.BLL BLL_EDIT_CONTACT = new BLL.BLL();
            if(BLL_EDIT_CONTACT.editContact(editContactFirtsName.Text, editContactSecondName.Text, editContactEmail.Text, editContactPhone.Text, editContactAge.Text))
            {
                editContactFirtsName.Text = "";
                editContactSecondName.Text = "";
                editContactEmail.Text = "";
                editContactPhone.Text = "";
                editContactAge.Text = "";
                messageEditContact.Content = "Contact edited";
            }
            else
            {
                messageEditContact.Content = "Contact not found";
            }
        }

        private void BackToMenuEditContact_Click(object sender, RoutedEventArgs e)
        {
            Contacts_View menu = new Contacts_View();
            menu.Show();
            this.Close();
        }

        private void SignOutEditContact_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fenetreLogin = new MainWindow();
            fenetreLogin.Show();
            this.Close();
        }
    }
}
