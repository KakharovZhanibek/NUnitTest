using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    public interface ICityRepo<T> where T : class
    {
        IEnumerable<T> getAll();
        T Create(T item);
        T Edit(T item);
        void Delete(int? id);
        T getById(int? id);
        IEnumerable<T> getCitiesByFirstLetters(string v);
    }
}
