﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TypeResolver
    {
        public Type Type { get; set; }

        public object Instance { get; set; }

        public string UniqueIdentifier { get; set; }
    }
    public static class Container
    {

        private static readonly IList<TypeResolver> Services = new List<TypeResolver>();

        /// <summary>
        /// Registers the specified service with the given contract key.
        /// </summary>
        /// <typeparam name="T">The service contract.</typeparam>
        /// <param name="instance">The service instance value.</param>
        public static void AddSingleton<T>(object instance)
        {
            AddSingleton(typeof(T), instance, null);
        }

        /// <summary>
        /// Registers the specified service with the given contract key.
        /// </summary>
        /// <typeparam name="T">The service contract.</typeparam>
        /// <param name="instance">The service instance value.</param>
        public static void AddSingleton<T>(object instance, string uniqueIdentifier)
        {
            AddSingleton(typeof(T), instance, uniqueIdentifier);
        }

        /// <summary>
        /// Registers the specified service with the given contract key.
        /// </summary>
        /// <param name="type">The service contract.</param>
        /// <param name="instance">The service instance.</param>
        public static void AddSingleton(Type type, object instance, string uniqueIdentifier)
        {
            lock (Services)
            {
                Services.Add(new TypeResolver() { Type = type, Instance = instance, UniqueIdentifier = uniqueIdentifier });
            }
        }

        /// <summary>
        /// Returns a service that match the given contract.
        /// </summary>
        /// <typeparam name="T">The service contract.</typeparam>
        /// <returns>The service instance.</returns>
        public static T Resolve<T>()
        {
            lock (Services)
            {
                return (T)Services.FirstOrDefault(s => s.Type == typeof(T)).Instance;
            }
        }

        public static T Resolve<T>(string uniqueidentifier)
        {
            lock (Services)
            {
                return (T)Services.FirstOrDefault(s => s.Type == typeof(T) && s.UniqueIdentifier == uniqueidentifier).Instance;
            }
        }
    }
}
