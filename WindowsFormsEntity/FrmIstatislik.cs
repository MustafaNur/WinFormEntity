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
    public partial class FrmIstatislik : Form
    {
        public FrmIstatislik()
        {
            InitializeComponent();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmIstatislik_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            lblMusteriSayisi.Text = db.Musteriler.Count().ToString();
            lblKategoriSayisi.Text = db.Kategori.Count().ToString();
            lblUrunSayisi.Text = db.Urunler.Count().ToString();
            //x her bir öğeği temsil eder. "x.kategori==1" ise kategori özelliklerin değeri bire işet olanlar
            lblBeyazEsyaSayisi.Text = db.Urunler.Count(x=>x.Kategori==1).ToString();
            lblToplamStok.Text = db.Urunler.Sum(x=>x.Stok).ToString();
            lblBgnSatis.Text = db.Satislar.Count(x=>x.Tarih==bugun).ToString();
            lblBgnKasaTutar.Text = db.Satislar.Sum(x => x.Fiyat).ToString();

            enYusksekFiyat.Text = (from x in db.Urunler orderby x.Fiyat descending select x.UrunAd).FirstOrDefault();

            EnFazlaUrunKategori.Text = (from x in db.Urunler orderby x.Stok descending select x.UrunAd).FirstOrDefault();
        }
    }
}
