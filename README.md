# WindbgDemo
Code for a Windbg demo presentation and training.

## Setup
- Download this project and build it
- Download Windbg from [here](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugger-download-tools)
- Create a local folder for symbols cache (e.g. C:\Symbols)

## Exercises
### Prerequisites
Before strating each exercise you need to open Windbg and do the following commands:
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

### Exercise 1 - Breakpoints
This exercise will show you how to setup breakpoints.
The demo code will perform a loop and throw an exception if the index of the loop is 84.

- Press "Break" in the Windbg menu (if not already pressed)
- Enter the following command to set a breakpoint in the start of the Run method:
```
!bpmd WindbgDemo.exe WindbgDemo.BreakpointsDemo.Run
```
- Enter the following command to set a brekpoint in line #14 of the demo file:
```
!bpmd BreakpointsDemo.cs:14
```
- Press "Go" in the Windbg menu
- In the demo app, select the first option (enter 1)
- Windbg should stop at the first breakpoint we set
- Enter one of the following commands to see the stack trace:
```
!ClrStack -i -a
!DumpStack -EE
```
- Press "Go" in the Windbg menu
- Windbg should stop at the second breakpoint we set
- Enter the following command to see the stack trace:
```
!ClrStack -i -a
```
- Note that we can see the value of the index (int i = 84)
- Press "Go" in the Windbg menu
- Windbg should stop because we threw an exception
- Enter the following command to see the exception details:
```
!pe
```
- Note that we can see the exception type, message and stack trace