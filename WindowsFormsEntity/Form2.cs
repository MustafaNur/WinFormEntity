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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Kategori.ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Ad";
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {

            //dataGridView1.DataSource = db.Urunler.ToList();
            var urunler = from x in db.Urunler
                          select new
                          {
                              x.UrunID,
                              x.UrunAd,
                              x.Stok,
                              x.Fiyat,
                              x.Kategori1.Ad
                          };
            dataGridView1.DataSource = urunler.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urunler t = new Urunler();
            t.UrunAd = txtAd.Text;
            t.Stok = short.Parse(txtStok.Text);
            t.Fiyat = decimal.Parse(txtFiyat.Text);
            t.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            db.Urunler.Add(t);
            db.SaveChanges();
            MessageBox.Show("işlem başarılı");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                int id = int.Parse(txtID.Text);
                var x = db.Urunler.Find(id);
                db.Urunler.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Ürün başarılı bir şekilde silindi", "Silme işlmei", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("UPS bir şeyler ters gitti");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var x = db.Urunler.Find(id);
            x.UrunAd = txtAd.Text;
            x.Stok = short.Parse(txtStok.Text);
            x.Fiyat = decimal.Parse(txtFiyat.Text);
            x.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Bilgiler güncellendi");
        }
    }
}
