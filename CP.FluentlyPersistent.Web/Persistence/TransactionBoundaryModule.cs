using System;
using System.Diagnostics;
using System.Web;
using CP.FluentlyPersistent.Web.Bootstrap;

namespace CP.FluentlyPersistent.Web.Persistence
{
    public class TransactionBoundaryModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        static void BeginRequest(object sender, EventArgs e)
        {
                var instance = Container.GetInstance<ITransactionBoundary>();
                instance.Begin();
        }

        static void EndRequest(object sender, EventArgs e)
        {
                var instance = Container.GetInstance<ITransactionBoundary>();
                try
                {
                    instance.Commit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Error Committing Transaction: '{0}', StackTrace:{1}", ex.Message,
                                                  ex.StackTrace));
                    instance.RollBack();
                    throw;
                }
                finally
                {
                    instance.Dispose();
                }
        }

        public void Dispose() { }
    }

}
