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
    /// Interaction logic for Contacts_View.xaml
    /// </summary>
    public partial class Contacts_View : Window
    {
        public Contacts_View()
        {
            InitializeComponent();
            
        }

        private void BoutonShow_Click(object sender, RoutedEventArgs e)
        {
            Show_Contacs_View fenetre_contact_view = new Show_Contacs_View();
            fenetre_contact_view.Show();
            this.Close();

        }

        private void BoutonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add_Contact_View fenetreAjouterContact = new Add_Contact_View();
            fenetreAjouterContact.Show();
            this.Close();
        }

        private void BoutonDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete_Contacts_View deleteContact = new Delete_Contacts_View();
            deleteContact.Show();
            this.Close();
        }

        private void BoutonEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit_Contact_View fenetre_edit_contact = new Edit_Contact_View();
            fenetre_edit_contact.Show();
            this.Close();
        }

        private void BoutonSearch_Click(object sender, RoutedEventArgs e)
        {
            Research_Contact_View rechercheContact = new Research_Contact_View();
            rechercheContact.Show();
            this.Close();
        }

        private void BoutonSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fenetreLogin = new MainWindow();
            fenetreLogin.Show();
            this.Close();
        }
    }
}
