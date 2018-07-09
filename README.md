# WindbgDemo
Code for a Windbg demo presentation and training.

## Setup
- Download this project and build it
- Download Windbg from [here](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugger-download-tools)
- Create a local folder for symbols cache (e.g. C:\Symbols)

## Exercises
### Prerequisites
Before strating each excersize you need to open Windbg and do the following commands:
- Launch the demo app (WindbgDemo.exe)
- Press "Go" in the Windbg menu (or enter the command *g*)
- Press "Break" in the Windbg menu
- Enter the command:
```
.loadby sos clr
```
- Set the symbols path by entering the following commands:

```
.sympath srv* Path to local symbols folder *https://msdl.microsoft.com/download/symbols
.sympath+ Path to demo app pdb files
```

For example, if your local symbols cache is in C:\Symbols and the demo app pdb files are in C:\WindbgDemo\bin\debug then run the following commands:

```
.sympath srv*C:\Symbols*https://msdl.microsoft.com/download/symbols
.sympath+ C:\WindbgDemo\bin\debug
```
