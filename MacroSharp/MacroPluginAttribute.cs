using Microsoft.CodeAnalysis.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp
{
    public class MacroPluginAttribute : Attribute, ICompilerPluginAttribute
    {
        public ICompilerPlugin Create()
        {
            return new MacroCompiler();
        }
    }
}
