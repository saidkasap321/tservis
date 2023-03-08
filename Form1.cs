using Npgsql;
using System;
using QRCoder;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TServis1
{
  
    public partial class Form1 : Form
    {
        private NpgsqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }
        // PG connectionSI
     



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            // FORM 1 DEN FORM 2 YE VERİ CEKTİGİMİZ  KODLAR

            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();
            f2.no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f2.ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f2.soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f2.tel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f2.firma.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            f2.uruntext.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f2.markatext.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            f2.sistemtext.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            f2.garantitext.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            f2.eskiseri.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            f2.yeniseri.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            f2.tutar1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            f2.servis.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f2.kper.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            f2.iper.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            f2.tper.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            f2.aksesuar.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            f2.sifre.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            f2.aciklamatext.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            f2.sonuctext.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            f2.bilgitext.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            f2.ktarih.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            f2.tno.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            f2.otur.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            f2.teslimtarih.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();
            //f2.textBox1.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
        }

        private void lis_Click(object sender, EventArgs e)
        {
           //FORM1  ANA EKRANA VERİ CEKTİGİMİZ  KODLAR

                string sorgu = "SELECT * FROM tdestek WHERE durum NOT LIKE 'TESLİM EDİLDİ%' and durum NOT LIKE 'GARANTİDEPO%' and ad NOT LIKE 'ŞİRKET%' and durum NOT LIKE 'GARANTİ FİRMA%' order by no desc limit 50 ";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
           

        }

        public void yenileKyt ()
        {
            //FORM1  ANA EKRANA VERİ CEKTİGİMİZ  KODLAR

            string sorgu = "select * from tdestek order by no desc limit 50 ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            //YENİ KAYIT EKRAN KODU
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();
            string query = ("localhost/aa/sorgulama.php?tel=" + f2.tel.Text + "&tno =" + f2.tno.Text + "");
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(query, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(1);
            f2.qrcode.Image = qrCodeImage;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                IConfigurationRoot configuration = builder.Build();

                connection = new NpgsqlConnection($"Server={configuration["ConnectionSettings:Host"]};" +
                    $"Port={configuration["ConnectionSettings:Port"]};" +
                    $"Database={configuration["ConnectionSettings:Database"]};" +
                    $"User Id={configuration["ConnectionSettings:Username"]};" +
                    $"Password={configuration["ConnectionSettings:Password"]};");
            }
          catch (Exception)
            {
                MessageBox.Show("DATABASE AYARLI DEGİL LÜTFEN ÖNCE AYARLARI YAPIN");
                Form9 f9 = new Form9();
                f9.Owner = this;
                f9.Show();
            }


        }

        private void gARANTİDEPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Owner = this;
            f5.Show();
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void kATAGORİVEPERSONELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Owner = this;
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void tel_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // telefon kayıt arama buton kodu
            connection.Open();
            NpgsqlDataAdapter sg = new NpgsqlDataAdapter("select * from tdestek where tel like '%" + tel.Text + "%'", connection);
            DataSet sx = new DataSet();
            sg.Fill(sx);
            dataGridView1.DataSource = sx.Tables[0];
            connection.Close();
        }

        private void adara_Click(object sender, EventArgs e)
        {
            // isim kayıt arama buton kodu
            connection.Open();
            NpgsqlDataAdapter sg = new NpgsqlDataAdapter("select * from tdestek where ad like '%" + ad.Text + "%'", connection);
            DataSet sx = new DataSet();
            sg.Fill(sx);
            dataGridView1.DataSource = sx.Tables[0];
            connection.Close();
        }

        private void soyadara_Click(object sender, EventArgs e)
        {
            // soy isim kayıt arama buton kodu
            connection.Open();
            NpgsqlDataAdapter sg = new NpgsqlDataAdapter("select * from tdestek where soyad like '%" + soyad.Text + "%'", connection);
            DataSet sx = new DataSet();
            sg.Fill(sx);
            dataGridView1.DataSource = sx.Tables[0];
            connection.Close();
        }

        private void servara_Click(object sender, EventArgs e)
        {
            // soy isim kayıt arama buton kodu
            connection.Open();
            NpgsqlDataAdapter sg = new NpgsqlDataAdapter("select * from tdestek where no like '%" + servno.Text + "%'", connection);
            DataSet sx = new DataSet();
            sg.Fill(sx);
            dataGridView1.DataSource = sx.Tables[0];
            connection.Close();
        }

        private void ad_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void ad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ad_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                ad.Text = ad.Text.ToUpper();
                connection.Open();
                NpgsqlDataAdapter sg = new NpgsqlDataAdapter("select * from tdestek where ad like '%" + ad.Text + "%' order by no desc limit 50", connection);
                DataSet sx = new DataSet();
                sg.Fill(sx);
                dataGridView1.DataSource = sx.Tables[0];
                connection.Close();
            }
        }

        private void soyad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                soyad.Text = soyad.Text.ToUpper();
                connection.Open();
                NpgsqlDataAdapter sg = new NpgsqlDataAdapter("select * from tdestek where soyad like '%" + soyad.Text + "%' order by no desc limit 50 ", connection);
                DataSet sx = new DataSet();
                sg.Fill(sx);
                dataGridView1.DataSource = sx.Tables[0];
                connection.Close();
            }
        }

        private void tel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                connection.Open();
                NpgsqlDataAdapter sg = new NpgsqlDataAdapter("select * from tdestek where tel like '%" + tel.Text + "%' order by no desc limit 50", connection);
                DataSet sx = new DataSet();
                sg.Fill(sx);
                dataGridView1.DataSource = sx.Tables[0];
                connection.Close();
            }
        }

        private void servno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                servno.Text = servno.Text.ToUpper();
                connection.Open();
                NpgsqlDataAdapter sg = new NpgsqlDataAdapter("select * from tdestek where no like '%" + servno.Text + "%' order by no desc limit 50 ", connection);
                DataSet sx = new DataSet();
                sg.Fill(sx);
                dataGridView1.DataSource = sx.Tables[0];
                connection.Close();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string sorgu = "select * from tdestek order by no desc ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void dATABASEAYARLARIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Owner = this;
            f9.Show();
        }
    }
}
