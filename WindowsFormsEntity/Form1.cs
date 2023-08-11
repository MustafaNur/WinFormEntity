using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEntity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Modelde yer alan sınıflara ulaşmak için gereken ana sınıf
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = db.Musteriler.ToList();
            //var türünde degisken tanımla sayısal, metinsel, true false şeklinde hepsini kapsar
            /*
             * from den dan anlamına geliyor 'x' geçici değişken 
             */
            var degerler = from x in db.Musteriler
                           select new
                           {
                               x.MusteriID,
                               x.MusteriAd,
                               x.MusteriSoyad,
                               x.Sehir
                           };
            dataGridView1.DataSource= degerler.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Musteriler t = new Musteriler();
            t.MusteriAd = txtAd.Text;
            t.MusteriSoyad = txtSoyad.Text;
            t.Sehir = txtSehir.Text;
            db.Musteriler.Add(t);
            db.SaveChanges();
            MessageBox.Show("YEni Müşteri Kaydı yapıldı");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var x = db.Musteriler.Find(id);
            db.Musteriler.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Müşteri bilgileri silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var x = db.Musteriler.Find(id);
            x.MusteriAd = txtAd.Text;
            x.MusteriSoyad = txtSoyad.Text;
            x.Sehir = txtSehir.Text;
            db.SaveChanges();
            MessageBox.Show("Müşteri bilgisi güncellendi");
        }
    }
}
