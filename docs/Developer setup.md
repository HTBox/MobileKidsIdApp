Developer Environment Setup
===========================

Requirements:
* IDE
  * Visual Studio 2017.7.3 or higher
  * Visual Studio for Mac
  * Visual Studio Code
* Xamarin Tools or the Cross-platform Mobile option for Visual Studio
* Windows 10 FCU or later (unless on Mac or Linux)

This solution relies on the Xamarin tools and SDK for iOS, Android, UWP, and other platforms. The Xamarin tools are free, and you must add them to your Visual Studio installation before you can work with the projects in this solution.

Other dependencies are pulled from NuGet, and that should automatically occur on first build.

## Emulators and Devices
One of the biggest obstacles to productivity usually centers around having the ability to run and debug code in an emulator or device.

### iOS
To do iOS development you must have a Mac, because Apple doesn't allow compilation of executables on other platforms. You can develop on a PC, but you also need a Mac, or you can just have a Mac.

The Mac can host an iOS _simulator_. This is not an emulator, and code that runs in the simulator may not work on a real device. However, the simulator is adequate for a lot of dev/debugging work.

The _best_ solution is to connect a real device (iPhone or iPad) to your Mac and deploy to that device. However, that requires that you have a $99/yr Apple developer license.

### Android
Android apps can be compiled on a PC or Mac or Linux. Emulators exist for all platforms. 

The emulators for PC generally require VirtualBox and so can't run if you have HyperV installed (for Docker, or other reasons).

Again, the _best_ solution is to connect a real Android device to your computer and deploy to that device. No special licenses, software, or hardware is required, though you do need to enable developer mode on your Android device.
