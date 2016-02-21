/// <binding BeforeBuild='default' />
"use strict";

var gulp = require('gulp');
var fs = require("fs");
var ts = require("gulp-typescript");
var cordovaBuild = require("taco-team-build");
var gutil = require('gulp-util');
var bower = require('bower');
var concat = require('gulp-concat');
var sass = require('gulp-sass');
var minifyCss = require('gulp-minify-css');
var rename = require('gulp-rename');
var sh = require('shelljs');

var jasmine = require('gulp-jasmine');

var paths = {
  sass: ['./scss/**/*.scss']
};

// Signing releated vars
var androidKeystorePwd = process.env["ANDROID_PWD"],
    encryptionPwd = process.env["ENC_PWD"],
    iosP12Pwd = process.env["P12_PWD"],
    iosCodeSignIdentityRelease = "iPhone Distribution: Rockford Lhotka",
    iosCodeSignIdentityDebug = "iPhone Developer";

var winPlatforms = ["android", "windows"],
    linuxPlatforms = ["android"],
    osxPlatforms = ["ios"],
    buildArgs = {
        android: ["--debug",
                  "--device",
                  "--gradleArg=--no-daemon"],
        ios: ["--debug", "--device", "--codeSignIdentity=" + iosCodeSignIdentityDebug],
        windows: ["--debug", "--device"],
        wp8: ["--debug", "--device"]
    },
    buildArgsRelease = {
        android: ["--release",
                  "--device",
                  "--gradleArg=--no-daemon",
                  "--storePassword=" + androidKeystorePwd,
                  "--password=" + androidKeystorePwd],
        ios: ["--release", 
              "--device",
              "--codeSignIdentity=" + iosCodeSignIdentityRelease],                                            
        windows: ["--release", "--device"]
    },
    platformsToBuild = process.platform === "darwin" ? osxPlatforms :
                       (process.platform === "linux" ? linuxPlatforms : winPlatforms),  
    tsconfigPath = "scripts/tsconfig.json"; 

gulp.task('default', ['sass', 'build', 'spec'], function() {
    // Copy results to bin folder
    gulp.src("platforms/android/build/outputs/apk/*.apk").pipe(gulp.dest("bin/Android/Debug"));         // Gradle build
    gulp.src("platforms/windows/AppPackages/**/*").pipe(gulp.dest("bin/Windows/Debug/AppPackages"));
    gulp.src("platforms/ios/debug/device/*.ipa").pipe(gulp.dest("bin/iOS/Debug"));
});

gulp.task('sass', function(done) {
  gulp.src('./scss/ionic.app.scss')
    .pipe(sass())
    .on('error', sass.logError)
    .pipe(gulp.dest('./www/css/'))
    .pipe(minifyCss({
      keepSpecialComments: 0
    }))
    .pipe(rename({ extname: '.min.css' }))
    .pipe(gulp.dest('./www/css/'))
    .on('end', done);
});

gulp.task('watch', function() {
  gulp.watch(paths.sass, ['sass']);
});

gulp.task('install', ['git-check'], function() {
  return bower.commands.install()
    .on('log', function(data) {
      gutil.log('bower', gutil.colors.cyan(data.id), data.message);
    });
});

gulp.task('git-check', function(done) {
  if (!sh.which('git')) {
    console.log(
      '  ' + gutil.colors.red('Git is not installed.'),
      '\n  Git, the version control system, is required to download Ionic.',
      '\n  Download git here:', gutil.colors.cyan('http://git-scm.com/downloads') + '.',
      '\n  Once git is installed, run \'' + gutil.colors.cyan('gulp install') + '\' again.'
    );
    process.exit(1);
  }
  done();
});

gulp.task("scripts", function () {
    // Compile TypeScript code - This sample is designed to compile anything under the "scripts" folder using settings
    // in scripts/tsconfig.json if present or this gulpfile if not.  Adjust as appropriate for your use case.
    if (fs.existsSync(tsconfigPath)) {
        // Use settings from scripts/tsconfig.json
        gulp.src("./www/scripts/**/*.ts")
            .pipe(ts(ts.createProject(tsconfigPath)))
            .pipe(gulp.dest("."));
    } else {
        // Otherwise use these default settings
         gulp.src("./www/scripts/**/*.ts")
            .pipe(ts({
                noImplicitAny: false,
                noEmitOnError: true,
                removeComments: false,
                sourceMap: true,
                out: "appBundle.js",
            target: "es5"
            }))
            .pipe(gulp.dest("./www/scripts"));        
    }
});

gulp.task("build", ["sass","scripts"], function () {
    return cordovaBuild.buildProject(platformsToBuild, buildArgs);
});

gulp.task("build-win", ["sass", "scripts"], function() {
    return cordovaBuild.buildProject("windows", buildArgs);
});

gulp.task("build-android", ["sass","scripts"], function() {
    return cordovaBuild.buildProject("android", buildArgs);
});

gulp.task("build-ios", ["sass","scripts"], function() {
    return cordovaBuild.buildProject("ios", buildArgs);
});

gulp.task("build-android-release", ["sass","scripts"], function() {
    if(!androidKeystorePwd || !encryptionPwd) {
        console.error("Set environment variables ANDROID_PWD to the keystore password and ENC_PWD to the openssl encryption password. Be sure openssl is in the path.");
        process.exit(1);
    }
    sh.exec("openssl des3 -d -in release.keystore.enc -out release.keystore -pass pass:" + encryptionPwd);
    return cordovaBuild.buildProject("android", buildArgsRelease)
            .then(function() { 
                sh.rm("release.keystore"); 
                gulp.src("platforms/android/build/outputs/apk/*.apk").pipe(gulp.dest("bin/Android/Release"));
            });
});

gulp.task("build-ios-release", ["sass","scripts"], function() {
    if(!iosP12Pwd || !encryptionPwd) {
        console.error("Set environment variables P12_PWD to the p12 signing cert password and ENC_PWD to the openssl encryption password. Be sure openssl is in the path.");
        process.exit(1);
    }
    sh.exec("sh ios-install-certs.sh");
    return cordovaBuild.buildProject("ios", buildArgsRelease)
        .then(function() {
            gulp.src("platforms/ios/release/device/*.ipa").pipe(gulp.dest("bin/iOS/Release"));
        });
});

// Test JS
gulp.task('spec', function () {
    return gulp.src('spec/**/*.js').pipe(jasmine());
})