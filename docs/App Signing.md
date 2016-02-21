#Configuring Automated Release App Signing

##Android
Android requires a keystore called release.keystore to be generated and stored in an encrypted form in the root of the Cordova project (**release.keystore.enc**).

###Configuring the build
There are two environment variables that need to be set for the build to succeed.

- ANDROID_PWD - Password to the Java keystore and alias the certificate.
- ENC_PWD - Password to unencrypt the file.

**These should be filtered from CI output**. Do not add them as normal environment variables and be sure to validate they are also filtered out of the log output.

To build the release version of the app for beta testing, use the following task:

```
gulp build-android-release
```

**NOTE:** You may need to remove the android platform to get a debug build to work again after doing a release build.  You can do this by installing the Cordova CLI (npm install -g cordova) and typing "cordova platform remove android"


###Generating the offical Android signing certificates
Currently there is a self-signed bogus one in the repo. See **[Android documentation](http://developer.android.com/tools/publishing/app-signing.html)** for details on generating an offical one. Use **droid-mkid** as the key alias when doing so.

You can then encrypt the new / updated keychain using the following command with the Git command line tools installed and in the path:
```
openssl des3 -in release.keystore -out release.keystore
```

Take note of the keystore password (use the same one for the alias) and the encryption passphrase and update the environment variables above.

##iOS
iOS requires a "signing certificate" tied to a "signing identity" and a "provisioning proflie" tied to that cert to be installed on a Mac in order to build.  There are three combinations:

1. Development
2. Distribution - Ad Hoc
3. Distribution - App Store

Signing for development requires a development enabled iOS device. Ad Hoc is used for beta testing. Both development and ad hoc certs **require a specific list of devices inside the provisioning profile.** Unfortunatley not just anyone can install.

The "Signing" directory currently contains:

1. A **development** cert and a development provisioning profile (dev.p12.enc, Dev__MissingChildrenMinnesota_Wildcard.mobileprovision.enc)
2. A distribution cert and an **ad hoc** provisioning profile (distro.p12.enc, Ad_Hoc__MissingChildrenMinnesota_Wildcard.mobileprovision.enc)

These files have been encrypted for security since they are in a public github repo.

###Configuring a build
There are two environment variables that need to be set for the build to succeed.

- P12_PWD - Password to the P12 file containing the certificate. Use the same password for both p12 files.
- ENC_PWD - Password to unencrypt the files. Use the same password for all files.

**These should be filtered from CI output**. Do not add them as normal environment variables and be sure to validate they are also filtered out of the log output.

To build the ad-hoc version of the app for beta testing, use the following task:

```
gulp build-ios-release
```

###Updating the certificates and provisioning profiles
You will need to edit the provisioning profile any time one of the following happens:

1. You want to add a new device for beta testing
2. You change the ID of the app (currently com.MissingChildrenMinnesota.KidsIdApp)

To update, see [this article](https://msdn.microsoft.com/en-us/Library/vs/alm/Build/apps/secure-certs) for details on exporting a provisioning profile or signing certificate from Xcode. Provisioning profiles may also be downloaded from the Apple developer portal, but signing certificates cannot. Note that steps specific Visual Studio Team Services (VSO/VSTS/TFS) can be ignored.

See "Optional: Using an Encrypted .p12 and .mobileprovision File" in [the same article](https://msdn.microsoft.com/en-us/Library/vs/alm/Build/apps/secure-certs) information on encrypting the files, but the syntax is simple:

```
openssl des3 -in <input file> -out <output file>
```

Now, simply upload the new files using the same filenames back into the repository.

Finally, take note of the P12 and encryption passwords you used and update the environment variables above accordingly.
