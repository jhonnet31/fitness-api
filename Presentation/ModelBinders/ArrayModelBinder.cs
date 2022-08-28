﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ModelBinders
{
    public class ArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var providerValue = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName)
                .ToString();
            if (string.IsNullOrEmpty(providerValue))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            var genericType=bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
            var converter=TypeDescriptor.GetConverter(genericType);
            var objectArray = providerValue.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => converter.ConvertFromString(x.Trim()))
                            .ToArray();
            var guidArray = Array.CreateInstance(genericType, objectArray.Length);
            objectArray.CopyTo(guidArray, 0);
            bindingContext.Model = guidArray;
            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}
