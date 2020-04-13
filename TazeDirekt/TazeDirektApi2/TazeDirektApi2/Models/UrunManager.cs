using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TazeDirektApi2.Services;
using TazeDirektApi2.Data;

namespace TazeDirektApi2.Models
{
    public class UrunManager
    {
        public Repository<Urun> repository;
        public UrunManager()
        {
            repository = new Repository<Urun>();
        }
    }

}