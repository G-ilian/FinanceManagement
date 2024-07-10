using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Shared.Data.DB
{
    public class DAL<T> where T : class
    {
        private readonly FinanceContext context;

        public DAL(FinanceContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public IEnumerable<T> Read() 
        {
            var list = new List<T>();

            try
            {
                list = context.Set<T>().ToList();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            return list;
        }

        public void Update(T entity)
        {
            try
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public T? ReadBy(Func<T,bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }
    }
}
