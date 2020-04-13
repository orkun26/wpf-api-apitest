using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeDirektApi2.Models;

namespace TazeDirektApi2.Services
{
    public interface IRepository<T> where T : class

    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);


    }
}
