using System;
using System.Diagnostics;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class ByteArrayAsVarBinary : IPropertyConvention
    {
        public bool Accept(IPropertyInstance propertyMapping)
        {
            return propertyMapping.Type == typeof (byte[]);
        }

        public void Apply(IPropertyInstance propertyMapping)
        {
            try
            {
                if (propertyMapping.Type == typeof(byte[]))
                {
                    propertyMapping.Length(int.MaxValue);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}

