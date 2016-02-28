Developer Environment Setup
===========================

* Some [TypeScript configuration](https://github.com/HTBox/MobileKidsIdApp/blob/master/docs/Typescript%20compilation.md) is required
* TACO requires that you manually create a directory: `%appdata%\taco_home\node_modules`
* Make sure gulpfile is processed on each build
  * Right-click gulpfile in Solution Explorer - click Task Runner Explorer
  * In Task Runner Explorer - right-click `default` select `bindings|Before Build`
