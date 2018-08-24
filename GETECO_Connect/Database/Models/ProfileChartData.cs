using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GETECO_Connect.DataBase.Models
{
    public class ProfileChartData
    {
        [PrimaryKey,AutoIncrement]
        public int InternalId { get; set; }
        public int Profile_Id { get; set; }
        public object Category { get; set; }
        public double Value { get; set; }
        public Color BarColor { get; set; }
    }
}
