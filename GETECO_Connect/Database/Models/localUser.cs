using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.DataBase.Models
{
    public class localUser
    {
        [PrimaryKey]
        public int InternalId { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Session { get; set; }
        public string Zusatzinfo { get; set; }
    }
}
