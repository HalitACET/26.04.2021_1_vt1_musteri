using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _26._04._2021_1_vt1
{
    class Vt
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6CRR4TF\SQLEXPRESS;Initial Catalog=BeyazEsyaDB;Integrated Security=True");


        public void ac()
        {
            baglanti.Open();
        }
        public void kapat()
        {
            baglanti.Close();
        }
    }
}
