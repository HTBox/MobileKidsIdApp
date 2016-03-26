Testing
=======

This project uses Jasmine for tests.  Tests without any browser dependencies can be run by Gulp (inside a Node JS environment) like this:
gulp.task('spec', function () {
    return gulp.src('spec/**/*.js').pipe(jasmine());
})

But Angular requires a browser, so the above method won't work for this project.  If you reference the Angular library and run the above Gulp task you will get an error "window is not defined".  In order to run Jasmine tests with a browser dependency you can use something like gulp-jasmine-browser, Karma, or Chutzpah.  Currently the Kids Id App is using gulp-jasmine-browser.  This package allows you to choose between running "headless" tests using PhantomJS or running tests in your browser.  Appveyor needs to have a way to run the tests headless so it will run the 'spec' Gulp task.  There is also a spec-browser Gulp task for running tests in your browser, which is nice for development.  The spec-browser task will run a web server using Node so you just need to point your browser to the URL that prints out when you run the spec-browser task.

The gulp-jasmine-browser package required that a javascript Promise implementation is available.  On Node version 0.12.0 and above that isn't a problem, but on earlier versions the any-promise node package is required so that you can register your preferred Promise implementation.  Currently the es6-promise package is being used as the implementation.

**Typescript Support**
The spec and spec-browser Gulp tasks depend on the spec-compile task which converts typescript to javascript and dumps results in the spec-out folder.  This folder has been added to .gitignore so nothing should be manually placed in that folder.