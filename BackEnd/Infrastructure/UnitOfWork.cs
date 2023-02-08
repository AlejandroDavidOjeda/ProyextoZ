using Domain;
using Domain.Entities;
using Infrastructure.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure
{
    public class UnitOfWork
    {
        private readonly AplicationDbContext dbContext;
        private IRepository<Categoria> categoriaRepository;

        public UnitOfWork(AplicationDbContext context) 
        { 
            dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<Categoria> CategoriaRepository => this.categoriaRepository ??= new Repository<Categoria>(this.dbContext);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            using (TransactionScope transactionScope = CrearTransaccion())
            {
                await this.dbContext.SaveChangesAsync(cancellationToken);
                transactionScope.Complete();
            }
        }

        private static TransactionScope CrearTransaccion()
        {
            return new TransactionScope(TransactionScopeOption.Required,
                                        new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted, Timeout = TimeSpan.FromMinutes(30) },
                                        TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}
