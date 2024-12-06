using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;
namespace Platformer.Infrastructure.Locator
{
    public class ServicesLocator
    {
        #region Variables

        private static ServicesLocator _instance;

        private readonly Dictionary<Type, IService> _services = new();

        #endregion

        #region Properties

        public static ServicesLocator Instance => _instance ??= new ServicesLocator();

        #endregion

        #region Public methods

        public T Get<T>() where T : class, IService
        {
            Assert.IsTrue(_services.ContainsKey(typeof(T)), $"Service '{typeof(T).Name}' not registered.");
            return _services[typeof(T)] as T;
        }

        public void Register<T>(T service) where T : class, IService
        {
            Assert.IsFalse(_services.ContainsKey(typeof(T)),
                $"Can't register service '{typeof(T).Name}' because it's already registered.");

            _services.Add(typeof(T), service);
        }

        public T RegisterMono<T>() where T : MonoBehaviour, IService
        {
            Type type = typeof(T);

            Assert.IsFalse(_services.ContainsKey(type),
                $"Can't register service '{type.Name}' because it's already registered.");

            GameObject go = new(type.Name);
            Object.DontDestroyOnLoad(go);
            T component = go.AddComponent<T>();
            _services.Add(type, component);
            return component;
        }

        public void UnRegister<T>() where T : IService
        {
            _services.Remove(typeof(T));
        }

        #endregion
    }
}