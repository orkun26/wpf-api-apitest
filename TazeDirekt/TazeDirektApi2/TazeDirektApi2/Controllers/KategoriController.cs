using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TazeDirektApi2.Models;
using TazeDirektApi2.Data;

namespace TazeDirektApi2.Controllers
{
    public class KategoriController : ApiController
    {
        KategoriManager manager = new KategoriManager();

        public IEnumerable<object> Get()
        {
      
            var liste = manager.repository.GetAll().Select(k => new { Id = k.Id, Adi = k.Adi });
             return liste;
        }

        // GET api/values/5
        public object Get(int id)
        {

            var kat = manager.repository.GetById(id);

            KategoriDTO katDTO = new KategoriDTO();
            katDTO.Id = kat.Id;
            katDTO.Adi = kat.Adi;

            return katDTO;
        }

        // POST api/values
        public void Post(string kategoriAdi)
        {
            Kategori k = new Kategori();
            k.Adi = kategoriAdi;

            manager.repository.Insert(k);
        }

        public void Put(int id, string kategoriAdi)
        {
            Kategori k = new Kategori();
            k.Id = id;
            k.Adi = kategoriAdi;

            manager.repository.Update(k);
        }



        // DELETE api/values/5
        public void Delete(int id)
        {
            manager.repository.Delete(id);

        }
    }
}
