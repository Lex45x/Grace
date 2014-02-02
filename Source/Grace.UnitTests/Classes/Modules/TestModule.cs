﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grace.DependencyInjection;
using Grace.UnitTests.Classes.Simple;

namespace Grace.UnitTests.Classes.Modules
{
	public class TestModule : IConfigurationModule
	{
		public void Configure(IExportRegistrationBlock registrationBlock)
		{
			registrationBlock.Export<BasicService>().As<IBasicService>();
		}
	}
}
