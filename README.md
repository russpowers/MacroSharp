# MacroSharp
This library provides attribute-based macros for C#.  Macro attributes can be applied to methods and type declarations, allowing you to manipulate syntax trees at compile time.  This project uses my fork of Roslyn to provide compiler plugin support.

# Basic Example
I have created `NotifyPropertyChanged`, a simple macro that automatically implements INotifyPropertyChanged for a class and emits PropertyChanged events for auto properties.  It also will create a PropertyChanged handler if one does not exist.

The macro source is in MacroSharp.ExampleMacros [here](https://github.com/russpowers/MacroSharp/blob/master/MacroSharp.ExampleMacros/NotifyPropertyChanged.cs).  See the Getting Started section below to download the full working example.

The usage of `NotifyPropertyChanged` looks like this:

	// Invoke the macro using its attribute
    [NotifyPropertyChanged]
    public class MyMacroTest
    {
        public int X { get; set; }
    }
    
And the generated code looks like this:

	[NotifyPropertyChanged]
    public class MyMacroTest
    {
    	private int _x;
        public int X 
        { 
        	get { return _x; }
            set
            {
            	_x = value;
                if (PropertyChanged != null)
                	PropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("X"));
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }

# Getting Started
- Be sure you have VS2015 RC installed
- Clone my fork of Roslyn: https://github.com/russpowers/roslyn
- Install the nuget dependencies by opening a command prompt in the cloned Roslyn folder and typing: `Src\.nuget\nuget restore Src\Roslyn.sln`
- Open src/RoslynLight.sln in VS2015 RC and build
- Clone this
- Edit RoslynCommon.targets and change the `RoslynBinaryPath` to point to the binary folder of the Roslyn you just built
- Open MacroSharp.sln in VS 2015 RC
- Build all
- Switch the startup project to MacroSharp.Examples and Run.

# Notes
The first build with macros will take a couple of seconds because it has to startup an external version of Roslyn to compile.  Subsequent compiles are normal speed.

There is only one example right now, NotifyPropertyChanged.  It automatically implements INotifyPropertyChanged for a class and emits PropertyChanged events for auto properties.

This does not integrate with Intellisense (yet), so you may see warnings/errors in Visual Studio that do not reflect your macros.  Also, debugging a file with macros in it can be a bit wonky, especially if you heavily modify the syntax, so expect some issues there.