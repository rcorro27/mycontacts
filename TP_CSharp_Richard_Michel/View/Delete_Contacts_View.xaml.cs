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
    /// Interaction logic for Delete_Contacts_View.xaml
    /// </summary>
    public partial class Delete_Contacts_View : Window
    {
        public Delete_Contacts_View()
        {
            InitializeComponent();
        }

        private void BoutonEffacer_Click(object sender, RoutedEventArgs e)
        {
            BLL.BLL BLL_DELETE_CONTACT = new BLL.BLL();

            if (BLL_DELETE_CONTACT.deleteContact(phoneAeffacer.Text))
            {
                messageDelete.Text = "Contact deleted";
                phoneAeffacer.Text = "";
            }
            else
            {
                messageDelete.Text = "No contact found";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contacts_View menu = new Contacts_View();
            menu.Show();
            this.Close();
        }
    }
}
