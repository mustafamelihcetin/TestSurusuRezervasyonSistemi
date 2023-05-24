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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data source=.;Initial Catalog=testsurusuVB;Integrated Security=SSPI;");



    private void Form3_Load(object sender, EventArgs e)
        {
            baglanti.Open();                    
    Form2 frm = new Form2();
      string deger = frm.dataGridView1.CurrentRow.Cells["adi"].Value.ToString();
      textBox1.Text = deger;
            baglanti.Close();
        }
    }
}
