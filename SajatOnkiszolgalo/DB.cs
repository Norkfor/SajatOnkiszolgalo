using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SajatOnkiszolgalo
{
    public class DB
    {
        string server = "leventepc.ddns.net";
        string user = "norkfor";
        string database = "termekek";
        string pwd = "termekek";

        MySqlConnection conn;

        public DB()
        {
            string kapcs = $"server={server};user={user};password={pwd};database={database}";

            conn = new MySqlConnection(kapcs);
        }

        public MySqlConnection Conn { get => conn; set => conn = value; }
    }
}
