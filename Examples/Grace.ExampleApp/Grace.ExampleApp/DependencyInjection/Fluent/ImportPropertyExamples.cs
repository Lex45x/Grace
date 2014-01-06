﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grace.DependencyInjection;
using Grace.ExampleApp.DependencyInjection.ExampleClasses;

namespace Grace.ExampleApp.DependencyInjection.Fluent
{
	/// <summary>
	/// This example shows how to import a property
	/// </summary>
	public class ImportPropertyExample : IExample<FluentSubModule>
	{
		public void ExecuteExample()
		{
			DependencyInjectionContainer container = new DependencyInjectionContainer();

			container.Configure(c =>
				                    {
					                    c.Export<BasicService>().As<IBasicService>();
					                    c.Export<ImportProperty>().As<IImportProperty>().ImportProperty(p => p.BasicService);
				                    });

			IImportProperty importProperty = container.Locate<IImportProperty>();

			if (importProperty == null)
			{
				throw new Exception("importPropert is null");
			}

			if (importProperty.BasicService == null)
			{
				throw new Exception("BasicService is null");
			}
		}
	}

	/// <summary>
	/// This example shows how to import a ReadOnlyCollection(T) into a property
	/// </summary>
	public class ImportMultiplePropertyExample : IExample<FluentSubModule>
	{
		public void ExecuteExample()
		{
			DependencyInjectionContainer container = new DependencyInjectionContainer();

			container.Configure(c =>
				                    {
											  c.Export(Types.FromThisAssembly()).ExportInterface(typeof(ISimpleObject));
											  c.Export<ImportPropertyMultiple>().As<IImportPropertyMultiple>().ImportProperty(p => p.SimpleObjects);
				                    });

			IImportPropertyMultiple multipleProperty = container.Locate<IImportPropertyMultiple>();

			if (multipleProperty == null)
			{
				throw new Exception("multipleProperty is null");
			}

			if (multipleProperty.Count != 5)
			{
				throw new Exception("simpleCount should be 5");
			}
		}
	}

	/// <summary>
	/// This example shows how to sort a collection
	/// </summary>
	public class SortImportedCollectionByProperty : IExample<FluentSubModule>
	{
		public void ExecuteExample()
		{
			DependencyInjectionContainer container = new DependencyInjectionContainer();

			container.Configure(c =>
			{
				c.Export(Types.FromThisAssembly()).ExportInterface(typeof(ISimpleObject));
				c.Export<ImportPropertyMultiple>()
				 .As<IImportPropertyMultiple>()
				 .ImportPropertyCollection(p => p.SimpleObjects).SortByProperty(p => p.SortProperty);
			});

			IImportPropertyMultiple multipleProperty = container.Locate<IImportPropertyMultiple>();

			if (multipleProperty == null)
			{
				throw new Exception("multipleProperty is null");
			}

			if (multipleProperty.Count != 5)
			{
				throw new Exception("simpleCount should be 5");
			}

			foreach (ISimpleObject simpleObject in multipleProperty.SimpleObjects)
			{
				Console.WriteLine("SimpleObject: " + simpleObject.SortProperty);
			}
		}
	}

	/// <summary>
	/// This example shows how to import only specific exports into a property
	/// </summary>
	public class SelectivelyImportMultiplePropertyExample : IExample<FluentSubModule>
	{
		public void ExecuteExample()
		{
			DependencyInjectionContainer container = new DependencyInjectionContainer();

			container.Configure(c =>
			{
				c.Export(Types.FromThisAssembly()).ExportInterface(typeof(ISimpleObject));
				c.Export<ImportPropertyMultiple>().
					As<IImportPropertyMultiple>().
					ImportProperty(p => p.SimpleObjects).Consider(ExportsThat.HaveAttribute<SomeTestAttribute>());
			});

			IImportPropertyMultiple multipleProperty = container.Locate<IImportPropertyMultiple>();

			if (multipleProperty == null)
			{
				throw new Exception("multipleProperty is null");
			}

			if (multipleProperty.Count != 3)
			{
				throw new Exception("simpleCount should be 3");
			}
		}
	}
}
