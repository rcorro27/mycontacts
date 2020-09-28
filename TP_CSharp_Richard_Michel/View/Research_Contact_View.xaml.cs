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
    /// Interaction logic for Research_Contact_View.xaml
    /// </summary>
    public partial class Research_Contact_View : Window
    {
        public Research_Contact_View()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BoutonRechercher_Click(object sender, RoutedEventArgs e)
        {
            BLL.BLL BLL_RESEARCH_CONTACT = new BLL.BLL();

            List<string[]> mesContact_trouver = BLL_RESEARCH_CONTACT.searchContact(phoneARechercher.Text);

            if (mesContact_trouver != null && mesContact_trouver.Count > 0)
            {
                string firstNames = "";
                string secondNames = "";
                string emails = "";
                string phones = "";
                string ages = "";
                int nbrContactFound = 0;

                foreach (string[] maListContact in mesContact_trouver)
                {
                   

                        firstNames += maListContact[0] + "\n";
                        secondNames += maListContact[1] + "\n";
                        emails += maListContact[2] + "\n";
                        phones += maListContact[3] + "\n";
                        ages += maListContact[4] + "\n";

                    nbrContactFound++;
                }
                listFirstNameFound.Text = firstNames;
                listSecondNameFound.Text = secondNames;
                listEmailFound.Text = emails;
                listPhoneFound.Text = phones;
                listAgeFound.Text = ages;
                messageRecherche.Text = nbrContactFound + " contact(s) found";

            }
            else
            {
                listFirstNameFound.Text = "";
                listSecondNameFound.Text = "";
                listEmailFound.Text = "";
                listPhoneFound.Text = "";
                listAgeFound.Text = "";
                messageRecherche.Text = "No contact found";
            }

        }
    }
}
