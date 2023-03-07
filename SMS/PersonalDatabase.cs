using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Final.Project.C
{
     public class PersonalDatabase
    {
        public int id = 1;
        public string Column1 { get; set; } 
        public string Column2 { get; set; }
        PersonalDatabase() { }
       public PersonalDatabase(string c1, string c2)
        {
            int myID = this.id + 1;
            this.id++;
            Column1 = c1;
            Column2 = c2;
        }   
    }
}
