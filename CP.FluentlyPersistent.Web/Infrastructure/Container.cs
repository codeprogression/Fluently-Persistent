using System;
using System.Collections;
using System.Collections.Generic;
using StructureMap;

namespace CP.FluentlyPersistent.Web.Infrastructure
{
    public class Container
    {
        private static IContainer _container;

        public static IContainer Initialize()
        {
            _container = new StructureMap.Container(
                x =>
                    {
                        x.Scan(s =>
                            {
                                s.LookForRegistries();
                                s.AssembliesFromApplicationBaseDirectory();
                                s.WithDefaultConventions();
                            });
                    }
            

    );
            
            return _container;
        }
        private static IContainer Self { get { return _container; } }

        public static T GetInstance<T>()
        {
            return (T)Self.GetInstance(typeof(T));
        }

        public static object GetInstance(Type instanceType)
        {
            return Self.GetInstance(instanceType);
        }

        public static T GetNamedInstance<T>(string name)
        {
            return (T)GetNamedInstance(typeof(T), name);
        }

        public static object GetNamedInstance(Type instanceType, string name)
        {
            return Self.GetInstance(instanceType, name);
        }

        public static IList<T> GetAllInstances<T>()
        {
            return Self.GetAllInstances<T>();
        }

        public static IList GetAllInstances(Type instanceType)
        {
            return Self.GetAllInstances(instanceType);
        }
    }
}