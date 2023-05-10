using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bijuteri_stok_takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void listele()
        {
            SQLiteConnection baglanti =
                new SQLiteConnection("Data Source=C:\\bijuteri.db;version=3");
            baglanti.Open();
            SQLiteDataAdapter da =
                new SQLiteDataAdapter("SELECT * FROM bijuteri_stok", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "bijuteri_stok");
            dataGridView1.DataSource = ds.Tables["bijuteri_stok"];
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
           }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglanti =
                    new SQLiteConnection("Data Source=C:\\bijuteri.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText =
                "INSERT INTO bijuteri_stok VALUES('" + textBox1.Text + "','" +
                textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "' )";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglanti = new SQLiteConnection("Data Source=C:\\bijuteri.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText =
                "DELETE FROM bijuteri_stok WHERE TC='" + textBox4.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglanti = new SQLiteConnection("Data Source=C:\\bijuteri.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;

            komut.CommandText =
                "UPDATE bijuteri_stok SET Tarih='" + textBox1.Text + "', Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "' ,Ürünler = '" + comboBox1.Text + "' " +
                "WHERE TC='" + textBox4.Text + "'";


            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }
    }
}
