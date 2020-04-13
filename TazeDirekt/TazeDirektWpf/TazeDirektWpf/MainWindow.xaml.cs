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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TazeDirektWpf.Data;

namespace TazeDirektWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> sliderList = new List<string>(new string[] { "/images/slider/bal.jpg", "/images/slider/boza.jpg", "/images/slider/cay.jpg", "/images/slider/et.jpg" });
        DispatcherTimer timer;
        int sayac = 0;
        int sliderIndex = 0;
        int sliderImageSure = 3;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetTimer();

            TazeDirektEntities db = new TazeDirektEntities();
            IC_urunlerim.ItemsSource = db.Uruns.ToList();
        }
        public void SetTimer()
        {

            //slider içindeki resimlerin saniyede 1 değişmesi için gerekli timer ayarları
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            sayac++;

            if (sayac % sliderImageSure == 0)
            {
                sliderIndex = (sliderIndex + 1) % sliderList.Count;
                slider.Source = new BitmapImage(new Uri(sliderList[sliderIndex], UriKind.Relative));
            }
        }

        private void btn_ekle_Click(object sender, RoutedEventArgs e)
        {

            //Yeni ürün sayfasından oluşturuyoruz, ve onu gösteriyoruz.
            YeniUrun yu = new YeniUrun();
            yu.Show();
        }

        private void btn_duzenle_Click(object sender, RoutedEventArgs e)
        {
            UrunListele ud = new UrunListele();
            ud.Show();
        }
    private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // logoya tıklandığı zaman, itemControl içindeki (repeaterdaki) ürünlere veritabanından istediğimiz verileri çekiyoruz.
            //bu metot için bütün verileri çekiyoruz, aşağıdaki metotlar için kategorisine göre ürünleri çekiyorruz.
            TazeDirektEntities db = new TazeDirektEntities();
            IC_urunlerim.ItemsSource = db.Uruns.ToList();
        }

        private void lbl_menu_sebzemeyve_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TazeDirektEntities db = new TazeDirektEntities();
            IC_urunlerim.ItemsSource = db.Uruns.Where(x => x.KategoriId == 1).ToList();
        }

        private void lbl_menu_et_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TazeDirektEntities db = new TazeDirektEntities();
            IC_urunlerim.ItemsSource = db.Uruns.Where(x => x.KategoriId == 2).ToList();
        }

        private void lbl_menu_sut_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TazeDirektEntities db = new TazeDirektEntities();
            IC_urunlerim.ItemsSource = db.Uruns.Where(x => x.KategoriId == 3).ToList();
        }

        private void lbl_menu_kahvaltilik_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TazeDirektEntities db = new TazeDirektEntities();
            IC_urunlerim.ItemsSource = db.Uruns.Where(x => x.KategoriId == 4).ToList();
        }

        private void lbl_menu_temel_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TazeDirektEntities db = new TazeDirektEntities();
            IC_urunlerim.ItemsSource = db.Uruns.Where(x => x.KategoriId == 5).ToList();
        }

        private void lbl_menu_atistirmalik_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TazeDirektEntities db = new TazeDirektEntities();
            IC_urunlerim.ItemsSource = db.Uruns.Where(x => x.KategoriId == 6).ToList();
        }



        //aşağıdaki metotlar animasyon için. mouse üstüne gelince ve üstünden gibinde rengin değişmesini sağlıyoruz.
        private void lbl_menu_sebzemeyve_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelEnter(lbl_menu_sebzemeyve);

        }

        private void lbl_menu_sebzemeyve_MouseLeave(object sender, MouseEventArgs e)
        {

            LabelLeave(lbl_menu_sebzemeyve);
        }
    
        private void lbl_menu_et_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelEnter(lbl_menu_et);
        }

        private void lbl_menu_et_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelLeave(lbl_menu_et);

        }

        private void lbl_menu_sut_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelEnter(lbl_menu_sut);

        }

        private void lbl_menu_sut_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelLeave(lbl_menu_sut);

        }

        private void lbl_menu_kahvaltilik_MouseEnter(object sender, MouseEventArgs e)
        {

            LabelEnter(lbl_menu_kahvaltilik);

        }

        private void lbl_menu_kahvaltilik_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelLeave(lbl_menu_kahvaltilik);
        }

        private void lbl_menu_temel_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelEnter(lbl_menu_temel);


        }

        private void lbl_menu_temel_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelLeave(lbl_menu_temel);
        }

        private void lbl_menu_atistirmalik_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelEnter(lbl_menu_atistirmalik);

        }

        private void lbl_menu_atistirmalik_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelLeave(lbl_menu_atistirmalik);

        }

        private void LabelEnter(Label lbl)
        {
            lbl.Background = new BrushConverter().ConvertFromString("#a2d95b") as SolidColorBrush;
            lbl.BorderBrush = new BrushConverter().ConvertFromString("#447800") as SolidColorBrush;
            lbl.Foreground = new BrushConverter().ConvertFromString("Azure") as SolidColorBrush;
        }
        private void LabelLeave(Label lbl)
        {
            lbl.Background = new BrushConverter().ConvertFromString("Azure") as SolidColorBrush;
            lbl.BorderBrush = new BrushConverter().ConvertFromString("LightGray") as SolidColorBrush;
            lbl.Foreground = new BrushConverter().ConvertFromString("Gray") as SolidColorBrush;
        }


      

    }
}
