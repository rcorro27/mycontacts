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
    /// Interaction logic for Show_Contacs_View.xaml
    /// </summary>
    public partial class Show_Contacs_View : Window
    {
        public Show_Contacs_View()
        {
            InitializeComponent();
            populate(10);
        }

        public void populate(int type_tri)
        {
            ListFirstName.Text = "";
            ListLastName.Text = "";
            ListEmail.Text = "";
            ListPhone.Text = "";
            ListAge.Text = "";

            BLL.BLL BLL_affiche_contact = new BLL.BLL();

            String[] mesContacts = BLL_affiche_contact.afficheConatct(type_tri); // si l'on ne donne pas en parametre soit 0 pour le tir par age soit 1 pour le tri par firstName, alors n'importe quelle valeur int renverra le tableau de contact par defaut(renvoie le tableau pris en parametre sans aucun traitement la dessus)
            string FirstNames = "";
            string LastNames = "";
            string emails = "";
            string phones = "";
            string ages = "";
            int nbcntFnd = 0;
            if (mesContacts != null && mesContacts.Length > 0)
            {

                foreach (String contacts in mesContacts)
                {
                    string[] splitableString = contacts.Split(',');
                    string FirstName = splitableString[0];
                    FirstNames += FirstName + "\n";
                    string LastName = splitableString[1];
                    LastNames += LastName + "\n";
                    string email = splitableString[2];
                    emails += email + "\n";
                    string numTelephone = splitableString[3];
                    phones += numTelephone + "\n";
                    string age = splitableString[4];
                    ages += age + "\n";
                    nbcntFnd++;

                }


                ListFirstName.Text = FirstNames;
                ListLastName.Text = LastNames;
                ListEmail.Text = emails;
                ListPhone.Text = phones;
                ListAge.Text = ages;

                    nbContactFound.Content = nbcntFnd + " contact(s) found";


            }
            else
            {
                nbContactFound.Content = "No Contacts. Insert new contacts";
            }

        }

        private void ContactsAfficher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            Contacts_View menu = new Contacts_View();
            menu.Show();
            this.Close();
        }

        private void SignOutForShowContacts_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fenetreLogin = new MainWindow();
            fenetreLogin.Show();
            this.Close();
        }

        private void BoutonTriAge_Checked(object sender, RoutedEventArgs e)
        {
            populate(0);
        }

        private void BoutonTriNom_Checked(object sender, RoutedEventArgs e)
        {
            populate(1);
        }
    }
}
