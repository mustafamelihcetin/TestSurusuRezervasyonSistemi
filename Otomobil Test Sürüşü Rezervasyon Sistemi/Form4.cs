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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=MelihPc;Initial Catalog=testsurusuVB;Integrated Security=SSPI;");

        void butona_basildi()
        {
            try
            {
                baglanti.Open();
                string giris = "insert into kayitlar(ad,soyad,dtarihi,eposta,telefon,aracisim,sehir,bayi)values(@ad,@soyad,@dtarihi,@eposta,@telefon,@aracisim,@sehir,@bayi)";
                SqlCommand kmtgiris = new SqlCommand(giris, baglanti);
                kmtgiris.Parameters.AddWithValue("@ad", textBox1.Text);
                kmtgiris.Parameters.AddWithValue("@soyad", textBox2.Text);
                kmtgiris.Parameters.AddWithValue("@dtarihi", dateTimePicker1.Text);
                kmtgiris.Parameters.AddWithValue("@eposta", textBox3.Text);
                kmtgiris.Parameters.AddWithValue("@telefon", textBox5.Text + textBox4.Text);
                kmtgiris.Parameters.AddWithValue("@aracisim", comboBox3.Text);
                kmtgiris.Parameters.AddWithValue("@sehir", comboBox2.Text);
                kmtgiris.Parameters.AddWithValue("@bayi", comboBox4.Text);

                kmtgiris.ExecuteNonQuery();
                baglanti.Close();
                DialogResult secenek = MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti!");

                if(secenek==DialogResult.OK)
                {

                    this.Hide();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi!", hata.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            butona_basildi();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlDataAdapter verial = new SqlDataAdapter("Select * from iller",baglanti);
            DataSet dset = new DataSet();
            verial.Fill(dset);
            foreach(DataRow dr in dset.Tables[0].Rows)
            {
                comboBox2.Items.Add(dr["name"].ToString());
            }
            SqlDataAdapter verial1 = new SqlDataAdapter("Select * from araclar",baglanti);
            DataSet dset1 = new DataSet();
            verial1.Fill(dset1);
            foreach(DataRow dr in dset1.Tables[0].Rows)
            {
                comboBox3.Items.Add(dr["aracismi"].ToString());
            }


            
        }

    

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.TextLength == 3)
            {
                textBox4.Focus();
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.bayilerTableAdapter.FillBy(this.testsurusuVBDataSet.bayiler);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox4.Enabled = true;
            comboBox4.SelectedItem = null;
            SqlDataAdapter verial1 = new SqlDataAdapter("Select * from bayiler where bayiler like '" + comboBox2.Text + "%'", baglanti);
            DataSet dset1 = new DataSet();
            verial1.Fill(dset1);
            foreach (DataRow dr in dset1.Tables[0].Rows)
            {
                comboBox4.Items.Add(dr["bayiler"].ToString());
            }
        }
    }
}
