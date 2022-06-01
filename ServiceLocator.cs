using UnityEngine;
using System.Collections.Generic;

namespace RenderHeads.Services
{
    public static class ServiceLocator
    {
        private static List<Service> _services = new List<Service>();
        
        public static T GetService<T>() where T: Service
        {
            foreach (Service service in _services)
            {
                if (typeof(T) == service.GetType())
                {
                    return (T) service;
                }
            }
            return default;
        }

        public static void AddService<T>(T service) where T : Service
        {
            foreach (Service existing in _services)
            {
                if (typeof(T) == existing.GetType())
                {
                    Debug.LogError($"[ServiceLocator] Cannot register multiple services of the same type: {typeof(T)}. Not registering duplicate.");
                    return;
                }
            }
            _services.Add(service);
        }
        
        public static void RemoveService(Service service)
        {
            for ( int i =0; i < _services.Count; i++)
            {
                Service existing = _services[i];
                if ( service.GetType() == existing.GetType())
                {
                    _services.RemoveAt(i);
                }
            }
        }
        
        public static void RemoveService<T>() where T : Service
        {
            for ( int i =0; i < _services.Count; i++)
            {
                Service existing = _services[i];
                if (typeof(T) == existing.GetType())
                {
                    _services.RemoveAt(i);
                }
            }
        }
    }
}