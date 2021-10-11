using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Server.DTO;

namespace Server.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;

        public static RoomDAO Instance
        {
            get { if (instance == null) instance = new RoomDAO(); return RoomDAO.instance; }
            private set { RoomDAO.instance = value; }   
        }
        private RoomDAO() { }
        //public List<Room>  LoadRoomList()
        //{
        //    List<Room> RoomList = new List<Room>();
        //    DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetRoomList");
        //    foreach (DataRow item in data.Rows)
        //    {
        //        Room room = new Room(item);
        //        RoomList.Add(room);
        //    }
        //    return RoomList;
        //}
        public bool CheckExistUser(string username, int idRoom)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("USP_CheckExistsUser @idRoom , @username", new object[] { idRoom, username });
            return (!(result.Rows.Count > 0));
            
        }
        public List<Room> LoadRoomClientList(string username)
        {
            List<Room> RoomList = new List<Room>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetClientRoom @username", new object[] { username });
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                RoomList.Add(room);
            }
            return RoomList;
        }
        public bool CheckRoom(int idRoom)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_CheckRoom @idRoom", new object[] { idRoom });
            if (data.Rows.Count > 0) return true;
            return false; 
        }
        public List<Room> GetRoom(int idRoom)
        {
            List<Room> RoomList = new List<Room>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_CheckRoom @idRoom", new object[] { idRoom });
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                RoomList.Add(room);
            }
            return RoomList;
        }
        public bool UpdateJoin(int idRoom, string username)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_UpdateJoin @idRoom , @username", new object[] { idRoom , username });
            if (result > 0) return true;
            else return false;
        }
        public void CreateRoom(string roomName)
        {
           DataProvider.Instance.ExecuteNonQuery("USP_CreateRoom  @roomName",new object[] { roomName });
        }
        public int GetIdRoom(string roomName)
        {
          
            object data = DataProvider.Instance.ExecuteScalar("USP_GetIdRoom @idRoom", new object[] { roomName });
            return (int)data;
        }
        public void UpdateName(string roomName)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_UpdateName  @roomName", new object[] { roomName });
        }

        public void OutRoom(string username, int idRoom)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_OutRoom @username , @idRoom", new object[] { username, idRoom });
        }
    }
}
