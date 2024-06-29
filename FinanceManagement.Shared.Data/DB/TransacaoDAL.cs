using Finance_console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Shared.Data.DB
{
    public  class TransacaoDAL
    {
        private readonly FinanceContext context;

        public TransacaoDAL(FinanceContext context)
        {
            this.context = context;
        }
        public void Create(Transacao transacao)
        {
            try
            {
                context.Transacao.Add(transacao);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }
        }

        public IEnumerable<Transacao> Read()
        {
            var list = new List<Transacao>();

            try
            {
                list = context.Transacao.ToList();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }

            return list;
        }

        public void Update(Transacao transacao)
        {
            try
            {
                context.Transacao.Update(transacao);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }
        }

        public void Delete(Transacao transacao)
        {
            try
            {
                context.Transacao.Remove(transacao);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }
        }






    }
}
