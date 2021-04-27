using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _26._04._2021_1_vt1
{
    class MusteriCrud
    {
        Vt bgl = new Vt();
        public int Musterikaydet(Musteri musteri)
        {
            bgl.ac();
            SqlCommand komut = new SqlCommand("Insert into TblMusteri values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti);
            komut.Parameters.AddWithValue("@p1",musteri.Ad);
            komut.Parameters.AddWithValue("@p2",musteri.Soyad);
            komut.Parameters.AddWithValue("@p3",musteri.Cinsiyet1);
            komut.Parameters.AddWithValue("@p4",musteri.Dyer1);
            komut.Parameters.AddWithValue("@p5",Convert.ToDateTime( musteri.Dtar1));
            komut.ExecuteNonQuery();

            SqlCommand komut3 = new SqlCommand("Select MAX(Kod) From TblMusteri",bgl.baglanti);
            int ks =Convert.ToInt16(komut3.ExecuteScalar());

            SqlCommand komut2 = new SqlCommand("Insert into TblAdres values(@p1,@p2,@p3,@p4)",bgl.baglanti);
            komut2.Parameters.AddWithValue("@p1",musteri.Il1);
            komut2.Parameters.AddWithValue("@p2",musteri.Ilce1);
            komut2.Parameters.AddWithValue("@p3",musteri.Semt);
            komut2.Parameters.AddWithValue("@p4",ks);
            komut2.ExecuteNonQuery();
            bgl.kapat();

            return 1;
        }

    }
}
