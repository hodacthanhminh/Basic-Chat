using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    [Serializable]
    public class Room
    {
        public Room()
        {
        }
        public Room(int id, string name)
        {
            this.ID = id;
            this.Name = name;
                
        }
        public Room(DataRow row)
        {
            this.ID = (int)row["idRoom"];
            this.Name = row["roomName"].ToString();
        }
        private string name;
        public string Name { get => name; set => name = value; }
        private int iD;
        public int ID { get => iD; set => iD = value; }



    }
}
