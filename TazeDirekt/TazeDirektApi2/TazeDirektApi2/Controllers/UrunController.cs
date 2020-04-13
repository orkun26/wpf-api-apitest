using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TazeDirektApi2.Models;
using TazeDirektApi2.Data;
using System.Xml;

namespace TazeDirektApi2.Controllers
{
    public class UrunController : ApiController
    {
        UrunManager manager = new UrunManager();
        public IEnumerable<object> Get()
        {
            var list = manager.repository.GetAll().Select(x => new { Id = x.Id, Adi = x.Adi, AnalizliMi = x.AnalizliMi, OrganikMi = x.OrganikMi, YerliUretimMi = x.YerliUretimMi, SekersizMi = x.SekersizMi, Aciklama = x.Aciklama, Fiyat = x.Fiyat, KategoriAdi = x.Kategori.Adi, TedarikciAdi = x.Tedarikci.Adi });
            return list;
        }

        public object Get(int id)
        {
            var urun = manager.repository.GetById(id);
            UrunDTO dto = new UrunDTO();
            dto.Id = urun.Id;
            dto.Aciklama = urun.Aciklama;
            dto.Adi = urun.Adi;
            dto.Fiyat = urun.Fiyat;
            dto.KategoriAdi = urun.Kategori.Adi;
            dto.TedarikciAdi = urun.Tedarikci.Adi;
            dto.AnalizliMi = urun.AnalizliMi;
            dto.OrganikMi = urun.OrganikMi;
            dto.SekersizMi = urun.SekersizMi;
            dto.YerliUretimMi = urun.YerliUretimMi;

            return dto;
        }

        public void Post(string ad, int tedarikciId, int kategoriId, decimal fiyat, bool analizliMi, bool organikMi, bool yerliMi, bool sekersizMi, string aciklama)
        {
            Urun u = new Urun();
            u.Adi = ad;
            u.TedarikciId = tedarikciId;
            u.KategoriId = kategoriId;
            u.Fiyat = fiyat;
            u.AnalizliMi = analizliMi;
            u.OrganikMi = organikMi;
            u.YerliUretimMi = yerliMi;
            u.SekersizMi = sekersizMi;
            u.Aciklama = aciklama;

            manager.repository.Insert(u);
        }


        public void Put(int id, string ad, int tedarikciId, int kategoriId, decimal fiyat, bool analizliMi, bool organikMi, bool yerliMi, bool sekersizMi, string aciklama)
        {
            Urun u = new Urun();
            u.Id = id;
            u.Adi = ad;
            u.TedarikciId = tedarikciId;
            u.KategoriId = kategoriId;
            u.Fiyat = fiyat;
            u.AnalizliMi = analizliMi;
            u.OrganikMi = organikMi;
            u.YerliUretimMi = yerliMi;
            u.SekersizMi = sekersizMi;
            u.Aciklama = aciklama;

            manager.repository.Update(u);
        }



        public void Delete(int id)
        {
            manager.repository.Delete(id);
        }
    }
}
