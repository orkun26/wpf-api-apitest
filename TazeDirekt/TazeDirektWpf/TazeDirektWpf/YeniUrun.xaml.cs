using System;
using System.Collections.Generic;
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
    /// Interaction logic for YeniUrun.xaml
    /// </summary>
    public partial class YeniUrun : Window
    {
        public YeniUrun()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //sayfa yüklendiği zaman kategori ve tedarikci açılır kutularının içindeki verilerin veritabanından doldurulmasını sağladık
            TazeDirektEntities db = new TazeDirektEntities();

            dd_kategori.ItemsSource = db.Kategoris.ToList();
            dd_kategori.DisplayMemberPath = "Adi";

            dd_tedarikci.ItemsSource = db.Tedarikcis.ToList();
            dd_tedarikci.DisplayMemberPath = "Adi";


        }
        private void btn_kaydet_Click(object sender, RoutedEventArgs e)
        {
            TazeDirektEntities db = new TazeDirektEntities();
            Urun u = new Urun();

            u.Adi = txt_ad.Text;
            u.Aciklama = txt_aciklama.Text;
            int fiyat;
            if (int.TryParse(txt_fiyat.Text, out fiyat))//fiyat kutusundaki değeri int değere dönüştürüp fiyat değişkenine atmaya çalışıyoruz. eğer gerçekten sayısal bir veri yazılmışsa bu değeri veritabanına kaydedebileceği için bir alttaki satıra inmesine izin veriyor
                u.Fiyat = fiyat;
            u.AnalizliMi = cb_analizli.IsChecked;
            u.OrganikMi = cb_organik.IsChecked;
            u.SekersizMi = cb_sekersiz.IsChecked;
            u.YerliUretimMi = cb_yerli.IsChecked;
            if (dd_tedarikci.SelectedItem != null)
                u.TedarikciId = ((Tedarikci)dd_tedarikci.SelectedItem).Id;
            if (dd_kategori.SelectedItem != null)
                u.KategoriId = ((Kategori)dd_kategori.SelectedItem).Id;
            if (txt_resim.Text.Length > 0)
                u.ResimYolu = "images/urunler" + txt_resim.Text;
            else
                u.ResimYolu = "images/urunler/yeniurun.jpg";

            db.Uruns.Add(u);

            db.SaveChanges();

            this.Close();

        }
    }
}
