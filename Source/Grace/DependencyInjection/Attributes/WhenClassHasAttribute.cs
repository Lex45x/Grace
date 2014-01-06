﻿using System;
using Grace.DependencyInjection.Attributes.Interfaces;
using Grace.DependencyInjection.Conditions;

namespace Grace.DependencyInjection.Attributes
{
	/// <summary>
	/// Export condition that limits the export to only be used in classes that have a particular attribute
	/// </summary>
	public class WhenClassHasAttribute : Attribute, IExportConditionAttribute
	{
		private Type attributeType;

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="attributeType"></param>
		public WhenClassHasAttribute(Type attributeType)
		{
			this.attributeType = attributeType;
		}

		/// <summary>
		/// Provides a new WhenClassHas condition
		/// </summary>
		/// <param name="attributedType"></param>
		/// <returns></returns>
		public IExportCondition ProvideCondition(Type attributedType)
		{
			return new WhenClassHas(attributedType);
		}
	}
}