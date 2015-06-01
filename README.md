# MacroSharp
Attribute-based Macros for C#

# Getting Started
- Be sure you have VS2015 RC installed
- Clone and build src/RoslynLight.sln from my fork of Roslyn: https://github.com/russpowers/roslyn
- Clone this
- Edit RoslynCommon.targets and change the RoslynBinaryPath to point to the binary folder of the Roslyn you just built
- Open MacroSharp.sln in VS 2015 RC
- Build all 
- Switch the startup project to MacroSharp.Examples and Run.

Note that the first build with macros will take a couple of seconds because it has to startup an external version of Roslyn to compile.  Subsequent compiles are normal speed.

There is only one example right now, NotifyPropertyChanged.  It automatically implements INotifyPropertyChanged for a class and emits PropertyChanged events for auto properties.

