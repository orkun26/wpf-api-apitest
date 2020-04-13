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
    /// Interaction logic for UrunListele.xaml
    /// </summary>
    public partial class UrunListele : Window
    {
        List<int> seciliUrunlerId;
        public UrunListele()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            seciliUrunlerId = new List<int>();
            TazeDirektEntities db = new TazeDirektEntities();
            //penceredeki datagridi veritabanındaki ürünlerle doldurduk
            dgUrunList.ItemsSource = db.Uruns.ToList();

        }
        private void dgList_Loaded(object sender, RoutedEventArgs e)
        {
            SetDoubleClickEvent();

  
        }
        private void SetDoubleClickEvent()
        {

            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            dgUrunList.RowStyle = rowStyle;
        }
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            //datagrid üzerindeki bir satıra çift tıklandığı zaman, o satırdaki ürünün id sini buradan alıyoruz
            DataGridRow row = sender as DataGridRow;
            int listId = ((Urun)row.DataContext).Id;

            //o id ye ait urun düzenleme sayfasını açıp, bu listeleme sayfasını kapatıyoruz.
            UrunDuzenle w = new UrunDuzenle(listId); //duzenleme sayfasi acilirken id girilmesini zorunlu tuttuğumuz için constructor oluşturduk ve id'yi buradan yolladık
            w.Show();
            this.Close();

            //datagride ait click eventini tekrar kuruyoruz.
            SetDoubleClickEvent();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e) // form tarafından data griddeki satırlara click yapılıdğı zaman bu tetiklenecek
        {
            CheckBox row = sender as CheckBox;// clicklediğimiz satırı burada alıyoruz
            int urunId = ((Urun)row.DataContext).Id;// o satırdaki id verisini çektik
            seciliUrunlerId.Add(urunId);// o id'yi listemize ekledik.

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)// form tarafından data griddeki satırlara unclick yapılıdğı zaman bu tetiklenecek
        {
            CheckBox row = sender as CheckBox;// clicklediğimiz satırı burada alıyoruz
            int urunId = ((Urun)row.DataContext).Id;// o satırdaki id verisini çektik
            seciliUrunlerId.Remove(urunId);// o id'yi listemize ekledik.
        }

        private void lblDelBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TazeDirektEntities db = new TazeDirektEntities(); // veritabanına bağlandık

            foreach (var item in seciliUrunlerId) // seçili urunlerimizin olduğu listede teker teker dolaştık
            {
                Urun urun = db.Uruns.Where(u => u.Id == item).FirstOrDefault();//listedeki id'ye ait ürünü çektik
                db.Uruns.Remove(urun);// bu ürünü listeden kaldırdık

            }

            seciliUrunlerId.Clear(); //artık seçili ürünlerimiz olmadığı için içerdeki bu listeyi sildik
            db.SaveChanges();//değişiklikleri veritabanına kaydettik

            dgUrunList.ItemsSource = db.Uruns.ToList();//datagridviewdaki ürünlerin güncellenmesi için item source'u yeniden güncelledik


        }
    }
}
