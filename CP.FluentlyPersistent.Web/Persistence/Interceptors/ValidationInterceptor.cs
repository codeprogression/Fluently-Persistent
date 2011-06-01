using System;
using NHibernate;

namespace CP.Settlers.Web.Infrastructure.Persistence
{
/*
    public class ValidationInterceptor : AuditInterceptor
    {
        readonly ObjectValidator _validator;

        public ValidationInterceptor(ObjectValidator validator)
        {
            _validator = validator;
        }

        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            _validator.Validate(entity);
            return base.OnSave(entity, id, state, propertyNames, types);
        }
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            _validator.Validate(entity);
            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }
    }

    public class AuditInterceptor : EmptyInterceptor
    {

     public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            if (entity is BaseEntity)
            {
                for (int i = 0; i < state.Length; i++)
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
            }

            return base.OnSave(entity, id, state, propertyNames, types);
        }

        IPrincipal CurrentUser { get { return Container.GetInstance<IPrincipal>(); } }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            if (entity is BaseEntity)
            {
                for (int i = 0; i < propertyNames.Length; i++)
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

            return false;
        }
    }
*/
}