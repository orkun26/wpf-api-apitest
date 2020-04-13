using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TazeDirektWpf.Data;

namespace TazeDirektWpf
{
    /// <summary>
    /// Interaction logic for UrunDuzenle.xaml
    /// </summary>
    public partial class UrunDuzenle : Window
    {
        public int UrunId;
        public UrunDuzenle(int id)
        {
            InitializeComponent();
            UrunId = id;
            TazeDirektEntities db = new TazeDirektEntities();

            dd_kategori.ItemsSource = db.Kategoris.ToList();
            dd_kategori.DisplayMemberPath = "Adi";
          

            dd_tedarikci.ItemsSource = db.Tedarikcis.ToList();
            dd_tedarikci.DisplayMemberPath = "Adi";
            


            //sayfa açıldığı zaman idye ait urun textlere dolduruluyor
            Urun u = db.Uruns.Where(x => x.Id == UrunId).FirstOrDefault();
            txt_ad.Text = u.Adi;
            txt_aciklama.Text = u.Aciklama;
            txt_fiyat.Text = u.Fiyat.ToString();
            cb_analizli.IsChecked = u.AnalizliMi;
            cb_organik.IsChecked = u.OrganikMi;
            cb_sekersiz.IsChecked = u.SekersizMi;
            cb_yerli.IsChecked = u.YerliUretimMi;
            dd_kategori.SelectedValue = u.Kategori;
            dd_tedarikci.SelectedValue = u.Tedarikci;
            txt_resim.Text = u.ResimYolu;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void btn_kaydet_Click(object sender, RoutedEventArgs e)
        {
            TazeDirektEntities db = new TazeDirektEntities();
            Urun u = new Urun();
            u.Id = UrunId;
            u.Adi = txt_ad.Text;
            u.Aciklama = txt_aciklama.Text;
            int fiyat;
            if (int.TryParse(txt_fiyat.Text, out fiyat))//fiyat kutusundaki değeri int değere dönüştürüp fiyat değişkenine atmaya çalışıyoruz. eğer gerçekten sayısal bir veri yazılmışsa bu değeri veritabanına kaydedebileceği için bir alttaki satıra inmesine izin veriyor
                u.Fiyat = fiyat;
            u.AnalizliMi = cb_analizli.IsChecked;
            u.OrganikMi = cb_organik.IsChecked;
            u.SekersizMi = cb_sekersiz.IsChecked;
            u.YerliUretimMi = cb_yerli.IsChecked;
            u.TedarikciId = ((Tedarikci)dd_tedarikci.SelectedItem).Id;
            u.KategoriId = ((Kategori)dd_kategori.SelectedItem).Id;
            if (txt_resim.Text.Length > 0)
                u.ResimYolu = txt_resim.Text;
            else
                u.ResimYolu = "images/urunler/urunFoto.jpg";

            //eğer ekleme kodu olsaydı sadece db.Urun.Add(u); yazacaktık.
            //ama güncelleme işlemi yaptığımız için, farklı olarak aşağıdaki iki satırı yazıyoruz
            db.Uruns.Attach(u);
            db.Entry(u).State = EntityState.Modified;

            db.SaveChanges();


            //kaydetme işlemi gerçekleştikten sonra urun listele sayfasını açıp, bu sayfayı kapatıyoruz.
            UrunListele ud = new UrunListele();
            ud.Show();
            this.Close();
        }
    }
}
