﻿using System;
using System.Collections.Generic;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Lifestyle;

namespace Grace.UnitTests.Classes.FauxClasses
{
	public class FauxExportStrategy : IExportStrategy
	{
		private readonly Func<object> activationDelegate;

		public FauxExportStrategy(Func<object> activationDelegate)
		{
			this.activationDelegate = activationDelegate;
			MeetsConditionValue = true;
			ActivationName = typeof(object).FullName;
			AllowingFiltering = true;
		}

		public bool MeetsConditionValue { get; set; }

		public object Activate(IInjectionScope exportInjectionScope, IInjectionContext context, ExportStrategyFilter consider)
		{
			return activationDelegate();
		}

		public void Dispose()
		{
		}

		public void Initialize()
		{
		}

		public Type ActivationType { get; set; }

		public string ActivationName { get; set; }

		public bool AllowingFiltering { get; set; }

		public IEnumerable<Attribute> Attributes { get; set; }

		public IInjectionScope OwningScope { get; set; }

		public object Key { get; set; }

		public IEnumerable<string> ExportNames { get; set; }

		public ExportEnvironment Environment { get; set; }

		public int Priority { get; set; }

		public ILifestyle Lifestyle { get; set; }

		public bool MeetsCondition(IInjectionContext injectionContext)
		{
			return MeetsConditionValue;
		}

		public IEnumerable<IExportStrategy> SecondaryStrategies()
		{
			return new IExportStrategy[0];
		}

		public void EnrichWithDelegate(EnrichWithDelegate enrichWithDelegate)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ExportStrategyDependency> DependsOn { get; private set; }

		public IExportMetadata Metadata { get; set; }

		public bool HasConditions { get; set; }

		public bool ExternallyOwned { get; set; }
	}
}