using UnityEngine;

namespace RenderHeads.Services
{
	public struct LazyService<T> where T: Service
	{
		private LazyService(T service)
		{
			_value = service;
		}


		public void ForceGetService()
		{
			_value = ServiceLocator.GetService<T>();
		}
		
		public bool IsAssigned =>_value != null;

		private T _value;
		public T Value
		{
			get
			{
				if (_value == null)
				{
					_value = ServiceLocator.GetService<T>();
				}
				
				Debug.Assert(_value != null, $"[LazyService<{typeof(T)}>] Could not get service. Either it does not exist in any loaded scene, or it has not been subscribed to the ServiceLocator. This could happen if Value is called before OnEnable or the objet that holds the Service has been disabled");
				
				return _value;
			}
			set
			{
				_value = value;
			}
		}
		
		public static implicit operator T(LazyService<T> lazy)
		{
			return lazy.Value;
		}

		//public static implicit operator LazyService<T>(T service)
		//{
		//	return new LazyService<T>(service);
		//}
		
	}
}

