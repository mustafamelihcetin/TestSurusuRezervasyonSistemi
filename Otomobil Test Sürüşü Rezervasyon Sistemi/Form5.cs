using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otomobil_Test_Sürüşü_Rezervasyon_Sistemi
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data source=MelihPc;Initial Catalog=testsurusuVB;Integrated Security=SSPI");











        private void button2_Click(object sender, EventArgs e)
        {
            string drm;
            try
            {
                
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız!");

                }
                else {
                    baglanti.Open();
                    string giris = "insert into araclar(aracismi)values(@aracismi)";
                    SqlCommand kmtgiris = new SqlCommand(giris, baglanti);
                    kmtgiris.Parameters.AddWithValue("@aracismi", textBox3.Text);
                    SqlDataReader bilgigetir = kmtgiris.ExecuteReader();
                    drm = "yok";
                    while (bilgigetir.Read())
                    {
                        if (bilgigetir.GetString(1) == textBox3.Text) {
                            MessageBox.Show("Bu kayıt zaten var!");
                            drm = "var";
                            break;
                            baglanti.Close();
                        }
                    }




                   // kmtgiris.ExecuteNonQuery();
                    baglanti.Close();
                    DialogResult secenek = MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti!");

                    if (secenek == DialogResult.OK)
                    {

                        this.Hide();
                    }
                }

                
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi!", hata.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                button1.Enabled = false;
            }

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string giris = "delete from araclar where aracismi='"+textBox1.Text+"'";
                SqlCommand kmtgiris = new SqlCommand(giris, baglanti);
                kmtgiris.ExecuteNonQuery();
                baglanti.Close();
                DialogResult secenek = MessageBox.Show("Kayıt başarıyla silindi!");

                if (secenek == DialogResult.OK)
                {

                    this.Hide();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi!", hata.Message);
            }
        }
    }
}
