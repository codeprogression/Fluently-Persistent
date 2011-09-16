using System;
using System.Data;
using NHibernate;
using StructureMap;

namespace CP.FluentlyPersistent.Web.Persistence
{
    public interface ITransactionBoundary
    {
        Lazy<ISession> CurrentSession { get; }
        bool HasOpenTransaction { get; }
        void Begin();
        void Commit();
        void RollBack();
        void Dispose();
    }

    public class TransactionBoundary : ITransactionBoundary
    {
        readonly ISessionFactory _sessionFactory;
        readonly IInterceptor _interceptor;
        ITransaction _transaction;
        private bool _begun;
        private bool _disposed;
        private bool _rolledBack;

        public TransactionBoundary(ISessionFactory sessionFactory, IInterceptor interceptor)
        {
            _sessionFactory = sessionFactory;
            _interceptor = interceptor ?? new EmptyInterceptor();
        }

        public bool HasOpenTransaction
        {
            get { return _begun; }
        }

        public void Begin()
        {
            CheckIsDisposed();

            CurrentSession = CreateSession();

        }

        Lazy<ISession> CreateSession()
        {
             return new Lazy<ISession>(() =>
             {
                 var session = _sessionFactory.OpenSession(_interceptor);
                    session.FlushMode = FlushMode.Commit;
                    BeginNewTransaction(session);
                    _begun = true;
                 return session;
             });
        }

        public void Commit()
        {
            CheckIsDisposed();
            CheckHasBegun();

            if (_transaction.IsActive && !_rolledBack)
            {
                _transaction.Commit();
            }
        }

        public void RollBack()
        {
            if (_transaction != null && _transaction.IsActive)
            {
            CheckIsDisposed();
            CheckHasBegun();

                _transaction.Rollback();
                _rolledBack = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }

        public Lazy<ISession> CurrentSession { get; private set; }

        private void BeginNewTransaction(ISession session)
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            _transaction = session.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_begun || _disposed)
                return;

            if (disposing)
            {
                _transaction.Dispose();
                CurrentSession.Value.Dispose();
            }

            _disposed = true;
        }

        private void CheckHasBegun()
        {
            if (!_begun)
                throw new InvalidOperationException("Must call Begin() on the unit of work before committing");
        }

        private void CheckIsDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
        }
    }
    
}