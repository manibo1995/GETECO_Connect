using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.DataBase.Models
{
    public class Owner
    {

        [PrimaryKey]
        public int InternalId
        {
            get;
            set;
        }
        public int Id
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }


        public string Vorname
        {
            get;
            set;
        }

 
        public string Name
        {
            get;
            set;
        }


        public int Id_Person
        {
            get;
            set;
        }


        public int Is_Master
        {
            get;
            set;
        }

     
        public int Is_User
        {
            get;
            set;
        }


        public string Picture
        {
            get;
            set;
        }

    
        public string Session
        {
            get;
            set;
        }
        public int ownId
        {
            get;
            set;
        }
    }
}
