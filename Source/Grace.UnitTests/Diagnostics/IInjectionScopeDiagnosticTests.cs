﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grace.DependencyInjection;
using Grace.Diagnostics;
using Xunit;

namespace Grace.UnitTests.Diagnostics
{
	public class IInjectionScopeDiagnosticTests
	{
		[Fact]
		public void ImportIInjectionScopeDiagnostic()
		{
			DependencyInjectionContainer container = new DependencyInjectionContainer();

			IInjectionScopeDiagnostic diag = container.Locate<IInjectionScopeDiagnostic>();

			Assert.Equal(0, diag.PossibleMissingDependencies.Count());
		}
	}
}
