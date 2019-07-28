Developer Environment Setup
===========================

Requirements:
* Windows 10 Pro 1809 or later (unless on Mac or Linux)
* IDE
  * Visual Studio 2017.7.3 or higher (Visual Studio 2019 recommended)
  * Visual Studio for Mac
  * Visual Studio Code
* Xamarin Tools or the Cross-platform Mobile option for Visual Studio

This solution relies on some Visual Studio workloads:

* Xamarin cross-platform tools and SDK for iOS/Android
* UWP
* ASP.NET web server

Other dependencies are pulled from NuGet, and that should automatically occur on first build.

## Emulators and Devices
One of the biggest obstacles to productivity usually centers around having the ability to run and debug code in an emulator or device.

### iOS
To do iOS development you must have a Mac, because Apple doesn't allow compilation of executables on other platforms. You can develop on a PC, but you also need a Mac, or you can just have a Mac.

The Mac can host an iOS _simulator_. This is not an emulator, and code that runs in the simulator may not work on a real device. However, the simulator is adequate for a lot of dev/debugging work.

The _best_ solution is to connect a real device (iPhone or iPad) to your Mac and deploy to that device. However, that requires that you have a $99/yr Apple developer license.

#### iOS Free Provisioning
It _is_ possible to do limited dev testing on physical devices via free iOS provisioning. It is very limited, but it may be useful if you don't have or don't want to pay for the Apple developer license. 
Note that it requires an Apple ID that is not already linked to an Apple Developer account. More information on free iOS provisioning is available from the [Microsoft Xamarin Documentation article.](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/free-provisioning)

#### iOS Auto Provisioning
If you do have a paid Apple developer license, you can make use of auto provisioning. This is the easiest method of code-signing the app and provisioning of a physical device; it allows Visual Studio to manage all this for you.

You must first ensure that you have your developer account Apple ID added to Visual Studio (either Mac or Windows versions). Instructions on this can be performed via Microsoft's Xamarin documentation article on [Apple Account Management.](https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/apple-account-management)

Authentication of your Apple ID is performed via fastlane, as specified in the above article. Here is more information on how to install and use [fastlane](https://docs.microsoft.com/en-us/xamarin/ios/deploy-test/provisioning/fastlane/index) on your Mac. Alternatively, Visual Studio for Mac will also help walk you through installation of fastlane, when it's required. 

Follow the steps in the [iOS Automatic Provisioning article](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/automatic-provisioning) which includes a video explaining more about simplified iOS provisioning.

Please make sure to _not_ check in the changes made to the iOS project by enabling auto provisioning into source control, as they will be specific to your developer information. This will cause the local build to fail for other developers.

* Note that sometimes, even when you've previously provisioned an iOS device, you need to trust the (Mac) computer it's plugged into before it will display in VS (Mac or Windows) for debugging. The easiest way to do this is to run iTunes on the Mac while your provisioned device is plugged in. You can also do this via XCode. You will then be prompted to trust the Mac on the device and enter the passcode. After this step, if you're running VS for Windows you may also have to re-pair to the Mac for the device to then show up for debugging.

### Android
Android apps can be compiled on a PC or Mac or Linux. Emulators exist for all platforms. 

The current/latest Android emulator that comes with Visual Studio runs on Hyper-V, so to use it your device must have Hyper-V installed and enabled.

The _best_ solution is to connect a real Android device to your computer and deploy to that device. No special licenses, software, or hardware is required, though you do need to enable developer mode on your Android device.

### Windows
Windows UWP apps require Windows 10. You can run and debug the UWP app on your Win10 device, or in an emulator on Win10. These features are enabled when you have Visual Studio installed on your Win10 dev PC.
