using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETECO_Connect.DataBase.Models
{
    public class Rating
    {
        [PrimaryKey,AutoIncrement]
        public int InternalId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
        
    }
    
}
