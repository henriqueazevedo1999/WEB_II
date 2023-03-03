using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Comandas.Presentation;

public class ValidateModelStateAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.ErrorCount == 0)
        {
            base.OnActionExecuting(context);
            return;
        }

        var bodyParameters = context.ActionDescriptor.Parameters.Where(p => p.BindingInfo.BindingSource.Id.Equals("Body", StringComparison.InvariantCultureIgnoreCase));
        if (!context.ActionArguments.Any() && bodyParameters.Any())
        {
            context.Result = new BadRequestObjectResult($"A body parameter was null");
            base.OnActionExecuting(context);
            return;
        }
        
        var rootModelType = bodyParameters.FirstOrDefault()?.ParameterType; //Get model type

        var expandoObj = new ExpandoObject();
        var expandoObjCollection = (ICollection<KeyValuePair<string, object>>)expandoObj; //Cannot convert IEnumrable to ExpandoObject

        var dictionary = context.ModelState.ToDictionary(k => k.Key, v => v.Value)
            .Where(v => v.Value.ValidationState == ModelValidationState.Invalid)
            .ToDictionary(
            k =>
            {
                if (rootModelType == null)
                    return k.Key;

                Type currentType = rootModelType;

                string[] propNavNames = k.Key.Split('.');
                for (int i = 0; i < propNavNames.Length; i++)
                {
                    string propName = propNavNames[i].Split('[').First();

                    var property = currentType.GetProperties().FirstOrDefault(p => p.Name == propName);
                    if (property == null)
                        continue;

                    //Try to get the attribute
                    var displayName = property.GetCustomAttributes(typeof(JsonPropertyNameAttribute), true).Cast<JsonPropertyNameAttribute>().SingleOrDefault()?.Name;
                    if (displayName != null)
                        propNavNames[i] = propNavNames[i].Replace(propName, displayName);

                    if (i == propNavNames.Length - 1)
                        continue;

                    Type innerType = property.PropertyType;
                    do
                    {
                        currentType = innerType;
                        innerType = innerType.GetElementType();
                    } while (innerType != null);
                }

                return string.Join(".", propNavNames);
            },
            v => v.Value.Errors.Select(e => e.ErrorMessage).ToList() as object); //Box String collection

        foreach (var keyValuePair in dictionary)
        {
            expandoObjCollection.Add(keyValuePair);
        }

        dynamic eoDynamic = expandoObj;
        context.Result = new UnprocessableEntityObjectResult(eoDynamic);

        base.OnActionExecuting(context);
    }
}
