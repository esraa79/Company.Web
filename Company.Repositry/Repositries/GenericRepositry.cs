using Company.Data.Context;
using Company.Data.Models;
using Company.Repositry.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositry.Repositries
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenericRepositry(CompanyDbContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        { 
            _context.Set<T>().Add(entity); 
            _context.SaveChanges();
        }

        public void Delete(T entity)
         => _context.Set<T>().Remove(entity);

        public IEnumerable<T> GetAll()        
           => _context.Set<T>().ToList();
           
        

        public T GetBYId(int id)
         => _context.Set<T>().Find(id);

        public void Update(T entity)
         => _context.Set<T>().Update(entity);
    }
}
