using System;

namespace InventoryItems.Data.Infastructure {
    public class DatabaseFactory : IDatabaseFactory {
        public bool mDisposed { get; set; }
        private Lazy<InventoryContext> mContext { get; }

        public DatabaseFactory() {
            mContext = new Lazy<InventoryContext>();
        }

        public DatabaseFactory(InventoryContext context) {
            this.mContext = new Lazy<InventoryContext>(() => context);
        }

        public InventoryContext GetContext() {
            return mContext.Value;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (mDisposed) {
                if (disposing)
                    if (mContext.IsValueCreated)
                        mContext.Value.Dispose();
                mDisposed = true;
            }
        }

        ~DatabaseFactory() {
            Dispose(false);
        }
    }
}
