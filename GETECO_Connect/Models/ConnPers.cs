using System;
using System.Collections.Generic;

namespace GETECO_Connect.Models
{
    public class ConnPers
    {
		public List<Data>  User { get; set; }
    }
	public class Data{
		public int id { get; set; }
		public int profil_id { get; set; }
	}
}
