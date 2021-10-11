using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [Serializable]
    public class Account
    {
        
        private string username;
        private int idClient;
        private string firstname;
        private string lastname;
        private string telephone;
        private string email;
        private string gender;
        private string address;

        public string Username { get => username; set => username = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }

        public Account()
        {

        }
        public Account(string username, int idClient, string firstname, string lastname, string telephone, string email, string gender, string address)
        {
            this.Username = username;
            this.idClient = idClient;
            this.firstname = firstname;
            this.lastname = lastname;
            this.telephone = telephone;
            this.email = email;
            this.address = address;
            this.gender = gender;
        }
        public Account (DataRow row)
        {
            this.username = row["username"].ToString();
            this.idClient = (int)row["idClient"];
            this.firstname = row["firstname"].ToString();
            this.lastname = row["lastname"].ToString();
            this.telephone = row["telephone"].ToString();
            this.email = row["email"].ToString();
            this.address = row["address"].ToString();
            this.gender = row["gender"].ToString();

        }
    }
}
