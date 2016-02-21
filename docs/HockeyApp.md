#Configuring CI for an automated HockeyApp deployment

##Setting up HockeyApp

1. Go into the HockeyApp portal and manually setup a new app (click new app and then click manual setup)
    1. Give the app a descriptive name and use the ID from the "id" attribute of the "widget" element in config.xml (src/MCM.KidsIdApp/config.xml)
    2. Select Android as the platform
2. Take note of the HockeyApp App ID (not to be confused with the one in config.xml) in the detail page of the app. (For example, you may see: App ID:
278a0d6194964ec686a358590c0afa14)
3. Update hockeyappAppIdAndroid in gulpfile.js with this value
3. Repeat #1 but this time for iOS. Update hockeyappAppIdiOS in gulpfile.js with the HockeyApp App ID this time.

##Configuring the CI build

1. If you have not already, generate an [API token](https://rink.hockeyapp.net/manage/auth_tokens) in the account menu on the HockeyApp portal.
2. Set an environment variable called HOCKEYAPP_API_TOKEN with this value. **This environment variable should be filtered from CI output**.
3. [Configure the build to generate a release build](./App Signing.md) and then call the HockeyApp task.

    Android:
    ```
    gulp build-android-release hockeyapp-android-release
    ```

    iOS:
    ```
    gulp build-ios-release hockeyapp-ios-release
    ```
    **NOTE:** The iOS build requires a Mac. **Appveryor does not have Macs today.** However, you can kick off the build manually this same way as needed.