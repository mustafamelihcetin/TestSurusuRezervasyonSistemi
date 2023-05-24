using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Otomobil_Test_Sürüşü_Rezervasyon_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Width=250;
        }
        void ButonaBasildi()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=MelihPc;Initial Catalog=testsurusuVB;Integrated Security=SSPI");
            try
            {
                baglanti.Open();
                string giris = "SELECT * FROM kullanicilarTB WHERE kadiVT=@ad AND sifreVT=@sifre";
                SqlCommand kmtgiris = new SqlCommand(giris, baglanti);
                kmtgiris.Parameters.AddWithValue("@ad", textBox1.Text);
                kmtgiris.Parameters.AddWithValue("@sifre", textBox2.Text);
                SqlDataReader dr = kmtgiris.ExecuteReader();
                if (dr.Read())
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                    
                    baglanti.Close();

                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("Hatalı giriş yaptınız!Lütfen tekrar deneyiniz.");
                    baglanti.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }       
        private void girisBTN_Click_1(object sender, EventArgs e)
        {
            ButonaBasildi();

        }
        private void cikisBTN_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else if (checkBox1.Checked == false)
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
