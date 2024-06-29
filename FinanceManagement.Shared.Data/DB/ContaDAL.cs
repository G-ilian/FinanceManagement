using Finance_console;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Shared.Data.DB
{
    public class ContaDAL
    {
        private readonly FinanceContext context;

        public ContaDAL(FinanceContext context)
        {
            this.context = context;
        }

        public IEnumerable<Conta> Read()
        {

            var list = new List<Conta>();

            try
            {
                list = context.Conta.ToList();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }

            return list;
        }

        public void Create(Conta conta)
        {
            try
            {
                context.Conta.Add(conta);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }
        }

        public void Update(Conta conta)
        {
            try
            {
                context.Update(conta);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }
        }

        public void Delete(Conta conta)
        {
            try
            {
                context.Remove(conta);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }
        }

        public Conta? ReadyByName(String nome){
            return context.Conta.FirstOrDefault(c => c.nome == nome);
        }


    }


}
