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
    /// Interaction logic for Register_View.xaml
    /// </summary>
    public partial class Register_View : Window
    {
        public Register_View()
        {
            InitializeComponent();
        }

        private void BoutonRegister_Click(object sender, RoutedEventArgs e)
        {
             
            BLL.BLL Bll_registrer = new BLL.BLL(RegisterID.Text);
            Bll_registrer.registrerUtilisateur(RegisterFirtsName.Text, RegisterSecondName.Text, RegisterEmail.Text, RegisterID.Text, RegisterPassword.Text);
            RegisterFirtsName.Text = "";
            RegisterSecondName.Text = "";
            RegisterEmail.Text = "";
            RegisterID.Text = "";
            RegisterPassword.Text = "";

            //Reaffichage de la fenetre de login pour permettre a l'utilisateur de se connecter a son compte
            this.Hide();
            MainWindow login = new MainWindow();
            login.Show();
        }

        private void SignOutForRegister_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fenetreLogin = new MainWindow();
            fenetreLogin.Show();
            this.Close();
        }
    }
}
