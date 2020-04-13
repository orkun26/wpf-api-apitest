using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TazeDirektApi2.Models
{
    public class UrunDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public Nullable<bool> AnalizliMi { get; set; }
        public Nullable<bool> OrganikMi { get; set; }
        public Nullable<bool> YerliUretimMi { get; set; }
        public Nullable<bool> SekersizMi { get; set; }
        public string Aciklama { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public string KategoriAdi { get; set; }
        public string TedarikciAdi { get; set; }

    }


    public class KategoriDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }

    }


    public class TedarikciDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
    }
}