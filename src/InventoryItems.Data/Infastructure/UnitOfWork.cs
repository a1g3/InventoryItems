using InventoryItems.Domain.Enums;
using InventoryItems.Domain.Interfaces.Infastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace InventoryItems.Data.Infastructure {
    public class UnitOfWork : IUnitOfWork {
        private Queue<ICommand> _commands { get; } = new Queue<ICommand>();
        private InventoryContext Database { get; set; }

        public UnitOfWork() { }
        public UnitOfWork(InventoryContext observatoryContext) { Database = observatoryContext; }

        public void Queue(ICommand command) => _commands.Enqueue(command);

        public void Dispose() {
            if (Database == null) Database = new InventoryContext();
            while (_commands.Count > 0) {
                ICommand command = _commands.Dequeue();
                if (command is EntityCommand<object> website) CommandHandler<object>.Handle(null, website);
                else throw new NotImplementedException();
            }

            Database.SaveChanges();
            _commands.Clear();
        }
    }

    static class CommandHandler<TEntity> where TEntity : class {
        public static void Handle(DbSet<TEntity> dbSet, EntityCommand<TEntity> entityCommand) {
            switch (entityCommand.EntityCommandType) {
                case CommandType.CREATE:
                    Create(dbSet, entityCommand.Entity);
                    break;
                case CommandType.UPDATE:
                    Update(dbSet, entityCommand.Entity);
                    break;
                case CommandType.DELETE:
                    Delete(dbSet, entityCommand.Entity);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void Create(DbSet<TEntity> dbSet, TEntity entity) => dbSet.Add(entity);
        private static void Update(DbSet<TEntity> dbSet, TEntity entity) => dbSet.Update(entity);
        private static void Delete(DbSet<TEntity> dbSet, TEntity entity) => dbSet.Remove(entity);
    }
}
