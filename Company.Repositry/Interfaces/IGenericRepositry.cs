using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositry.Interfaces
{
    public interface IGenericRepositry<T> where T : BaseEntity
    {
        T GetBYId(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
