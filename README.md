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

# Getting started
1. Be sure you have VS2015 (any version) installed
2. Clone my fork of Roslyn: https://github.com/russpowers/roslyn
3. Install the nuget dependencies by opening a command prompt in the cloned Roslyn folder and typing: `nuget.exe restore Roslyn.sln`
4. Open src/Roslyn.sln in VS2015 and build
5. Clone this into a separate folder
6. Edit RoslynCommon.targets and change the `RoslynBinaryPath` to point to the binary folder of the Roslyn you just built
7. Open MacroSharp.sln in VS 2015
8. Build all
9. Switch the startup project to MacroSharp.Examples and Run.

# To use macros in a new project
- Follow the above steps 1-8
- Create a new macro project `A` (where the macros will be stored)
- Create a new project that will use the macro project `B` (console, class library, whatever)
- Add a reference to MacroSharp.dll in both `A` and `B` projects
- Add a reference to `A` in `B`
- Edit `B`'s .csproj file by adding `<CscToolPath>*ROSLYN PATH*\Binaries\Debug or Release</CscToolPath>` and `<CscToolExe>csc2.exe</CscToolExe>` to the first `<PropertyGroup>`.  Example: `<CscToolPath>D:\roslyn\Binaries\Debug</CscToolPath>` `<CscToolExe>csc2.exe</CscToolExe>`
- In one of `B`'s .cs files, add an assembly attribute `[assembly:MacroSharp.MacroPlugin]`

# Notes

The first build with macros will take a couple of seconds because it has to startup an external version of Roslyn to compile.  Subsequent compiles are normal speed.

There is only one example right now, NotifyPropertyChanged.  It automatically implements INotifyPropertyChanged for a class and emits PropertyChanged events for auto properties.

This does not integrate with Intellisense (yet), so you may see warnings/errors in Visual Studio that do not reflect your macros.  Also, debugging a file with macros in it can be a bit wonky, especially if you heavily modify the syntax, so expect some issues there.