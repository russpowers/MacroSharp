using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This needs to appear once in an assembly to have it run the macro plugin
[assembly:MacroSharp.MacroPlugin]

namespace MacroSharp.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var testNPC = new TestNPCMacro();
            testNPC.PropertyChanged += TestNPC_PropertyChanged;
            testNPC.X = 5;
            testNPC.Name = "Roslyn";
            testNPC.NameNoNPC = "This should not print";
            testNPC.X = 10;
            Console.ReadLine();
        }

        private static void TestNPC_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("You changed " + e.PropertyName);
        }
    }
}
