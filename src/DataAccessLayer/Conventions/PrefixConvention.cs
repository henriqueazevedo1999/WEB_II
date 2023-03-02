using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Repository.Conventions;

public class PrefixConvention : IPropertyAddedConvention
{
    public void ProcessPropertyAdded(IConventionPropertyBuilder propertyBuilder, IConventionContext<IConventionPropertyBuilder> context)
    {
        string originalPropertyName = propertyBuilder.Metadata.Name;
        string newPropertyName = char.ToLowerInvariant(originalPropertyName[0]) + originalPropertyName.Substring(1);

        propertyBuilder.Metadata.SetColumnName(newPropertyName);
    }
}

