using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Server.DAO;

namespace Server
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        { 
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO()
        {

        }
        public bool Register(string username, string password, string email)
        {
            string query = "USP_InsertAccount @username , @password , @email";
            int result = DataProvider.Instance.ExecuteNonQuery(query,new object[] { username , password , email });
            return result > 0;
        }
        public bool CheckAccount(string username)
        {
            string query = "USP_GetInfo @username ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            if (data.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        public Account GetAccountByUserName(string username)        
        {
            string query = "USP_GetInfo @username ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool Login(string username , string password)
        {
            string query = "usp_login @username , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }
        public List<Account> LoadUserRoom(int idRoom)
        {
            List<Account> AccountList = new List<Account>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetRoomUser @idRoom", new object[] { idRoom });
            foreach (DataRow item in data.Rows)
            {
                Account room = new Account(item);
                AccountList.Add(room);
            }
            return AccountList;
        }
        public void PassChange(string password , string username)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_PassChange @password , @username", new object[] { password, username });
        }
        public void UpdateAccount(string user, string fn , string ln , string telephone , string email , string address )
        {
            DataProvider.Instance.ExecuteNonQuery("USP_UpdateAccount @username , @firstname , @lastname , @telephone , @email , @address ", new object[] { user, fn,ln,telephone,email,address });
        }
    }
}
