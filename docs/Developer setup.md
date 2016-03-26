Developer Environment Setup
===========================

* Some [TypeScript configuration](https://github.com/HTBox/MobileKidsIdApp/blob/master/docs/Typescript%20compilation.md) is required
* TACO requires that you manually create a directory: `%appdata%\taco_home\node_modules`
* Make sure gulpfile is processed on each build
  * Right-click gulpfile in Solution Explorer - click Task Runner Explorer
  * In Task Runner Explorer - right-click `default` select `bindings|Before Build`
* **Live Reload**: Debugging on an emulator or a device can be very time-consuming if you have to do a full rebuild/deploy after every code change.  Ionic has command-line tools that offer live reload so that you can reload the app and get code updates without the deploy step.  See http://ionicframework.com/docs/cli/run.html.  Note that your phone must be able to access your development machine on the network so you will need to make sure that access isn't blocked by any firewalls or anti-viruses.
