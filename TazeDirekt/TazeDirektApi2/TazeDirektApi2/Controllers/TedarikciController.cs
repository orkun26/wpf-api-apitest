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
    public class TedarikciController : ApiController
    {
        TedarikciManager manager = new TedarikciManager();
        public IEnumerable<object> Get()
        {
            var tedarikciler = manager.repository.GetAll().Select(x => new { Id = x.Id, Adi = x.Adi, Aciklama = x.Aciklama });

            return tedarikciler; 
        }

        public object Get(int id)
        {
            var tedarikci = manager.repository.GetById(id);

            //entitiy frameworkun oluşturduğu nesne çok karmaşık olduğu için sistem otomatik olarak json'a döndürürken problem yaşadığı için, ara bir dto(data transfer object) nesnesi oluşturarak json a döndürüyoruz
            TedarikciDTO dto = new TedarikciDTO();
            dto.Aciklama = tedarikci.Aciklama;
            dto.Adi = tedarikci.Adi;
            dto.Id = tedarikci.Id;
            return dto;
        }

        public void Post(string tedarikciAdi, string aciklama)
        {
            Tedarikci t = new Tedarikci();
            t.Adi = tedarikciAdi;
            t.Aciklama = aciklama;

            manager.repository.Insert(t);

        }

        public void Put(int id, string tedarikciAdi, string aciklama)
        {
            Tedarikci t = new Tedarikci();
            t.Id = id;
            t.Adi = tedarikciAdi;
            t.Aciklama = aciklama;

            manager.repository.Update(t);

        }


        public void Delete(int id)
        {
            manager.repository.Delete(id);
        }


    }
}
