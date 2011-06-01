using System;
using System.Security.Principal;
using NHibernate;

namespace CP.FluentlyPersistent.Core.Persistence.Interceptors
{
    public class DefaultInterceptor : EmptyInterceptor
    {

        IPrincipal CurrentUser { get { return /*Container.GetInstance<IPrincipal>()?? */ new GenericPrincipal(new GenericIdentity("Anonymous"), new string[0]); } }

        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            {
                for (var i = 0; i < state.Length; i++)
                {
                    switch (propertyNames[i])
                    {
                        case "CreatedOn":
                            state[i] = state[i] ?? DateTime.UtcNow;
                            break;
                        case "CreatedBy":
                            state[i] = state[i] ?? CurrentUser.Identity.Name;
                            break;
                        case "ModifiedOn":
                            state[i] = DateTime.UtcNow;
                            break;
                        case "ModifiedBy":
                            state[i] = CurrentUser.Identity.Name;
                            break;
                    }
                }

                return base.OnSave(entity, id, state, propertyNames, types);
            }
        }
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            for (var i = 0; i < propertyNames.Length; i++)
            {
                switch (propertyNames[i])
                {
                    case "CreatedOn":
                        currentState[i] = currentState[i] ?? DateTime.UtcNow;
                        break;
                    case "CreatedBy":
                        currentState[i] = currentState[i] ?? CurrentUser.Identity.Name;
                        break;
                    case "ModifiedOn":
                        currentState[i] = DateTime.UtcNow;
                        break;
                    case "ModifiedBy":
                        currentState[i] = CurrentUser.Identity.Name;
                        break;
                }
            }
            return true;
        }
    }
}