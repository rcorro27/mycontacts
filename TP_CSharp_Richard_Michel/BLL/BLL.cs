using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL
    {
        public string Id;
        private DAL.DAL dal = new DAL.DAL("login.txt");

        enum TypeTri { AGE, FIRST_NAME}

        public BLL()
        {

        }

        public BLL(String ID)
        {
            Id = ID;
        }

        public bool login(string password)
        {
            bool estTrouve = false;

            string[] tabLogin = dal.LireLogin(Id, password);

            foreach (string mesLogin in tabLogin)
            {
                string[] infoTemp = mesLogin.Split(',');

                if (infoTemp[3].CompareTo(Id) == 0 && infoTemp[4].CompareTo(password) == 0)
                {
                    estTrouve = true;
                }
            }

            return estTrouve;
        }

        public void registrerUtilisateur(string prenom, string nom, string email, string iD, string password)
        {
            dal.EcrireLogin(prenom, nom, email, iD, password);
        }

        public void AddNewContact(string prenom, string nom, string email, string phone, string age)
        {
            dal.AddContact(prenom, nom, email, phone, age);
        }

        public string[] afficheConatct(int typeTri)
        {

            return tri(dal.RecupeContact(), typeTri);

        }

        public bool deleteContact(String phone)
        {
            bool estTrouve = false;

            String[] contactList = dal.RecupeContact();
            int i = 0;
            while (i < contactList.Length)
            {
                string[] splitable = contactList[i].Split(',');

                if (splitable[3].CompareTo(phone) == 0)
                {
                    estTrouve = true;
                    dal.deleteLine(i);
                    i = contactList.Length;
                }

                i++;

            }

            return estTrouve;
        }

        public bool editContact(string firstName, string lastName, string email, string phone, string age)
        {

            bool estTrouve = false;

            String[] contactList = dal.RecupeContact();
            int i = 0;

            while (i < contactList.Length)
            {
                string[] splitable = contactList[i].Split(',');

                if (splitable[0].CompareTo(firstName) == 0 || splitable[1].CompareTo(lastName) == 0 || splitable[2].CompareTo(email) == 0 || splitable[3].CompareTo(phone) == 0)
                {
                    estTrouve = true;
                    dal.editContact(firstName, lastName, email, phone, age, i);
                    i = contactList.Length;
                }

                i++;

            }




            return estTrouve;

        }

        public List<string[]> searchContact(string phone)
        {

            List<string[]> mesContactTrouver = new List<string[]>();

            String[] contactList = dal.RecupeContact();
            for (int i = 0; i < contactList.Length; i++)
            {
                string[] splitable = contactList[i].Split(',');

                if (splitable[3].CompareTo(phone) == 0)
                {
                    mesContactTrouver.Add(splitable);
                }

            }

            return mesContactTrouver;
        }

        public string[] tri(string[] mesContact, int typeTri)
        {
            if (mesContact != null && mesContact.Length > 0) { 
                switch (typeTri)
                {
                    case 0: // Tri par age
                        int age_de_i = 0;
                        string[] FirstSplitableWord;

                        int age_de_j = 0;
                        string[] SecondSplitableWord;

                        for (int i = 0; i < mesContact.Length; i++)
                        {
                            FirstSplitableWord = mesContact[i].Split(',');
                            try
                            {
                                age_de_i = int.Parse(FirstSplitableWord[4]);
                                for (int j = (i + 1); j < mesContact.Length; j++)
                                {
                                    SecondSplitableWord = mesContact[j].Split(',');
                                    age_de_j = int.Parse(SecondSplitableWord[4]);

                                    if (age_de_j < age_de_i)
                                    {
                                        string tempContact = mesContact[i];
                                        mesContact[i] = mesContact[j];
                                        mesContact[j] = tempContact;

                                    }

                                }
                            }catch(Exception ex)
                            {

                            }
                        }



                        break;


                    case 1: // Tri par FirstName

                        string FirstName_de_i = "";
                        string[] splitableWord_de_i;

                        string FirstName_de_j = "";
                        string[] splitableWord_de_j;

                        for (int i = 0; i < mesContact.Length; i++)
                        {
                            splitableWord_de_i = mesContact[i].Split(',');
                            FirstName_de_i = splitableWord_de_i[0];
                            for (int j = (i + 1); j < mesContact.Length; j++)
                            {
                                splitableWord_de_j = mesContact[j].Split(',');
                                FirstName_de_j = splitableWord_de_j[0];

                                if (FirstName_de_j.CompareTo(FirstName_de_i) < 0)
                                {
                                    string tempContact = mesContact[i];
                                    mesContact[i] = mesContact[j];
                                    mesContact[j] = tempContact;

                                }

                            }
                        }

                        break;



                }
        }

            return mesContact;
        }



    }
}
