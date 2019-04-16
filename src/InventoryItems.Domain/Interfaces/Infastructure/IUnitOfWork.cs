using System;

namespace InventoryItems.Domain.Interfaces.Infastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Queue(ICommand command);
    }
}
