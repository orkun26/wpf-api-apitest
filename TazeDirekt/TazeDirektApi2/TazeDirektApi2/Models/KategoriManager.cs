using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TazeDirektApi2.Services;
using TazeDirektApi2.Data;


namespace TazeDirektApi2.Models
{

    public class KategoriManager
    {
        public Repository<Kategori> repository;
        public KategoriManager()
        {
            repository = new Repository<Kategori>();
        }
    }


}