using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace DAL
{
    public class DAL
    {
        public string Path { get; set; }

        static public string LoginId { get; set; }
        public string LoginPassword { get; set; }
        public DAL(string path)
        {
            Path = path;
        }
        public string[] LireLogin(string Id, string password)
        {
             LoginId = Id;
            string[] tabLogin;
            if (File.Exists("login.txt"))
            {
                 tabLogin = File.ReadAllLines(Path);
            }
            else
            {
                File.AppendText("login.txt");
                 tabLogin = File.ReadAllLines(Path);
            }
            return tabLogin;
        }

        public void EcrireLogin(string prenom, string nom, string email, string iD, string password)
        {
            LoginId = iD;
            string infoConcat = prenom.Trim() + "," + nom.Trim() + "," + email.Trim() + "," + iD.Trim() + "," + password.Trim() + "\n";
            File.AppendAllText(Path, infoConcat);
            string filePath = iD + "." + "txt";
            if (!File.Exists(filePath))
            {
                File.AppendAllText(filePath, "");
            }
        }

        public void AddContact(string prenom, string nom, string email, string phone, string age)
        {
            string addConcat = prenom.Trim() + "," + nom.Trim() + "," + email.Trim() + "," + phone.Trim() + "," + age.Trim() + "\n";
            string filePath = LoginId + ".txt";
            File.AppendAllText(filePath, addConcat);
        }

        public string[] RecupeContact()
        {
            String[] fileContent = null;
            string filePath = LoginId + ".txt";

            try
            {
                fileContent = File.ReadAllLines(filePath);

            }catch(Exception ex)
            {
             
            }

            return fileContent;
        }

        public void deleteLine(int i)
        {
            string filePath = LoginId + ".txt";
            List<string> newContactsList = new List<string>();

            string[] myContacts = RecupeContact();

            for(int j = 0; j < myContacts.Length; j++)
            {
                if (j != i)
                {
                    newContactsList.Add(myContacts[j]);
                }
            }

            File.Delete(filePath);

            foreach(String str in newContactsList)
            {
                string temp = str + "\n";
                File.AppendAllText(filePath, temp);
                
            }
            
        }

        public void editContact(string firstName, string lastName, string email, string phone, string age, int i)
        {
            string filePath = LoginId + ".txt";
            string newConcat = "";
            List<string> newContactsList = new List<string>();


            string[] myContacts = RecupeContact();

            for (int j = 0; j < myContacts.Length; j++)
            {
                String[] oldData = myContacts[j].Split(',');
                if (j != i)
                {
                    newContactsList.Add(myContacts[j]);
                }
                else
                {
                    if(firstName.Trim().CompareTo("") != 0)
                    {
                        newConcat += firstName.Trim();
                    }
                    else
                    {
                        newConcat += oldData[0];
                    }

                    if (lastName.Trim().CompareTo("") != 0)
                    {
                        newConcat += "," + lastName.Trim();
                    }
                    else
                    {
                        newConcat += "," + oldData[1];
                    }

                    if (email.Trim().CompareTo("") != 0)
                    {
                        newConcat += "," + email.Trim();
                    }
                    else
                    {
                        newConcat += "," + oldData[2];
                    }

                    if (phone.Trim().CompareTo("") != 0)
                    {
                        newConcat += "," + phone.Trim();
                    }
                    else
                    {
                        newConcat += "," + oldData[3];
                    }

                    if (age.Trim().CompareTo("") != 0)
                    {
                        newConcat += "," + age.Trim();
                    }
                    else
                    {
                        newConcat += "," + oldData[4];
                    }

                    newContactsList.Add(newConcat);
                }
            }

           

            File.Delete(filePath);

            foreach (String str in newContactsList)
            {
                string temp = str + "\n";
                File.AppendAllText(filePath, temp);

            }



        }



    }


}
