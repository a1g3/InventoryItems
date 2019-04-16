using InventoryItems.Domain.Enums;
using InventoryItems.Domain.Interfaces.Infastructure;

namespace InventoryItems.Data.Infastructure
{
    public class EntityCommand<TEntity> : ICommand
    {
        public CommandType EntityCommandType { get; private set; }
        public TEntity Entity { get; private set; }
        public EntityCommand(CommandType commandType, TEntity entity)
        {
            EntityCommandType = commandType;
            Entity = entity;
        }
    }
}
