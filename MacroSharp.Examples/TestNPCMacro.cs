using MacroSharp.ExampleMacros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp.Examples
{
    // Invoke the macro using its attribute
    [NotifyPropertyChanged]
    class TestNPCMacro
    {
        public int X { get; set; }
        public string Name { get; set; }
        private string _nameNoNPC;
        public string NameNoNPC
        {
            get
            {



                return _nameNoNPC;
            }
            set
            {
                _nameNoNPC = value;
            }
        }

        // This is optional, the macro will create it if necessary
        // We create it here because the example creates a warning if it is found
        public event PropertyChangedEventHandler PropertyChanged;
    }
}