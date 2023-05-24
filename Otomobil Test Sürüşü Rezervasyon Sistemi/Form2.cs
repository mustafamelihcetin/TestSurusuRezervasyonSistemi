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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=MelihPc;Initial Catalog=testsurusuVB;Integrated Security=SSPI;");
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select * from kayitlar where telefon='" + textBox1.Text + "'",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select * from kayitlar",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();


            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select * from kayitlar", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult cevap = new DialogResult();
            cevap = MessageBox.Show("Silinecek olan kaydın telefon numarasına tıklayıp siliniz. Silme işlemini onaylıyor musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)

                try
                {

                    baglanti.Open();
                    SqlCommand kmt = new SqlCommand("DELETE  FROM kayitlar where telefon='" + dataGridView1.CurrentRow.Cells["telefon"].Value.ToString() + "'", baglanti);
                    kmt.ExecuteNonQuery();
                    
                    
                    baglanti.Close();
                }
                catch
                {
                    MessageBox.Show("Bir İşlem Seçin");
                }

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            Form3 frm = new Form3();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
        }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void tabPage2_Click(object sender, EventArgs e)
    {

    }

    private void button8_Click(object sender, EventArgs e)
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

    private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
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
