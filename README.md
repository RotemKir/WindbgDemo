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

Steps:
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
- Enter the following command to see the stack trace:
```
!ClrStack -i -a
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

### Exercise 2 - Examine objects in memory
This exercise will show you how to examine the data of objects in memory.

The demo code will attempt to pretty print a complex object (Person) 
and will have a ArgumentNullException due to an unitialized property value.

Steps:
- Press "Go" in the Windbg menu
- In the demo app, select the second option (enter 2)
- Windbg should stop because we threw a null reference exception
- Enter the following command to see the exception details:
```
!pe
```
- Enter the following command to see the stack trace:
```
!ClrStack -i -a
```
- Note that we can see that parameters and local values of the GetFriendNames method in the stack trace:
```
... WindbgDemo.ExamineObjects.GetFriendNames(Class WindbgDemo.Person) ...

PARAMETERS:
  + WindbgDemo.ExamineObjects this @ 0x30252e0
  + WindbgDemo.Person person @ 0x30253c4

LOCALS:
  + System.Collections.Generic.IEnumerable`1<string> names = null
  + (Error 0x80004005 retrieving local variable 'local_1')
```
- Note that the local variable 'names' is null (this is the cause of the exception)
- The number after the parameter name is the memory address of the parameter
- Enter the following command to see the object details using the address you received:
```
!do 0x30253c4
```
- Note that we can see the properties that this object contains, for example:
```
      MT    Field   Offset                 Type VT     Attr    Value Name
01405038  4000004        c      WindbgDemo.Name  1 instance 030253d0 <Name>k__BackingField
...
```
- The value column is the address for the field. Try to enter the !do command for the name field:
```
!do 030253d0
```
- You will receive an error that this is an invalid object. 
This is because Name is a value type (struct) instead of a reference type (class)
- In order to see the value type details we need a different command and also the value in the MT (method table) column:
```
!dumpvc 01405038 030253d0
```
- Try to see the values of the First and Last properties of the name using the !do command