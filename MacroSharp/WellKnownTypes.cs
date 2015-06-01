using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp
{
    class WellKnownTypes
    {
        private const string TypeName_MethodMacroAttribute = "MacroSharp.MethodMacroAttribute";
        private const string TypeName_TypeMacroAttribute = "MacroSharp.TypeMacroAttribute";

        public readonly INamedTypeSymbol MethodMacroAttribute;
        public readonly INamedTypeSymbol TypeMacroAttribute;

        public readonly bool AllTypesFound;

        public WellKnownTypes(Compilation compilation)
        {
            MethodMacroAttribute = compilation.GetTypeByMetadataName(TypeName_MethodMacroAttribute);
            TypeMacroAttribute = compilation.GetTypeByMetadataName(TypeName_TypeMacroAttribute);

            AllTypesFound =
                MethodMacroAttribute != null &&
                TypeMacroAttribute != null;
        }
    }
}
