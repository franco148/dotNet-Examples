# Unit Test-Examples


# Notes:
1. For running our unit tests we have more than a option (external runner, resharper, etc)
	- For external go to: https://github.com/NUnitSoftware/nunit-gui/releases and download nunit-gui, you can open the test dll. This is going to be loaded by reflection.
	- With Visual Studio plug-in go to: https://github.com/nunit/nunit3-vs-adapter/releases and add to visual studio.
	- With Visual Studio find test explorer. You will have a UI for this purpose.
	
# Test Doubles:
1. We need test double for each object
2. Fake
	a) An object that conforms to the predefined interface.
	b) Does nothing at all, returns default values.
	c) Null object pattern
3. Stub
	a) Like a fake, but returns the answers you define.
	b) Can record some info about calls that were made.
4. Mock
	a) A fake object where you can set expectations.
	b) Values returned, number of calls made, what parameters were used for the calls.
5. Moles/Shims
	a) Moles is a 'detouring' framework by Microsoft.
	b) Uses profiling feature of CLR to redirect method calls to custom delegates.
	c) E.g., you can mock DateTime.Now
6. Impromptu: Library that will lets us conform and dynamic object to any interface that we want which might sound
   really weird.