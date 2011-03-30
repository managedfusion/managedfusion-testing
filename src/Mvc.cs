using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using System.Collections.Specialized;

namespace ManagedFusion.Testing
{
	public static class Mvc
	{
		public static ControllerBase SetControllerContext(this ControllerBase controller)
		{
			var httpContext = Http.MockHttpContext();
			var controllerContext = new ControllerContext(httpContext, new RouteData(), controller);
			controller.ControllerContext = controllerContext;

			return controller;
		}

		public static ControllerBase SetValueProvider(this ControllerBase controller, IDictionary<string, string> values = null)
		{
			if (values == null)
				values = new Dictionary<string, string>();

			var collection = new NameValueCollection();
			foreach (var v in values)
				collection.Add(v.Key, v.Value);

			controller.ValueProvider = new NameValueCollectionValueProvider(collection, null);

			return controller;
		}
	}
}
