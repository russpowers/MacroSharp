using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp
{
    public abstract class MacroTransform<TMacroAttribute> : IMacroTransform
    {
        public abstract SyntaxNode Transform(TransformContext context);
    }
}