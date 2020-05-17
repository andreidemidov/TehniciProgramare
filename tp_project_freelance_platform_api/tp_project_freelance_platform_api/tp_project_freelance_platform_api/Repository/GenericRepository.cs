using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Repository.Interfaces;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;

namespace tp_project_freelance_platform_api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FreeLancePlatformContext _context;
        private DbSet<T> table = null;

        public GenericRepository(FreeLancePlatformContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
