using System.Web.Mvc;
using RolForServer.Controllers.Auth;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using Unity.Lifetime;
using System;
using System.Runtime.Remoting.Messaging;

namespace RolForServer {
	public class UnityConfig {
		public static void RegisterComponents() {
			var container = new UnityContainer();

			container.RegisterType<IAuthenticationService, FormsAuthenticationService>(
				new PerCallContextLifeTimeManager(),
				new InjectionConstructor());

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
	
	class PerCallContextLifeTimeManager : LifetimeManager {
		private string _key = $"PerCallContextLifeTimeManager_{Guid.NewGuid()}";

		public override object GetValue() {
			return CallContext.GetData(_key);
		}

		public override void SetValue(object newValue) {
			CallContext.SetData(_key, newValue);
		}

		public override void RemoveValue() {
			CallContext.FreeNamedDataSlot(_key);
		}
	}
}