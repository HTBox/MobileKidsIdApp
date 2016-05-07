/// <binding BeforeBuild='sass, default' />
"use strict";

var gulp = require('gulp');
var fs = require("fs");
var del = require('del');
var sourcemaps = require('gulp-sourcemaps');
var ts = require("gulp-typescript");
var cordovaBuild = require("taco-team-build");
var gutil = require('gulp-util');
var bower = require('bower');
var concat = require('gulp-concat');
var sass = require('gulp-sass');
var minifyCss = require('gulp-minify-css');
var rename = require('gulp-rename');
var sh = require('shelljs');
var watch = require('gulp-watch');

var jasmine = require('gulp-jasmine');
require('any-promise/register')('es6-promise');
var jasmineBrowser = require('gulp-jasmine-browser');

var appName = "Kids Id App";
var paths = {
  sass: ['./scss/**/*.scss'],
  ipaPath: "./platforms/ios/build/device/" + appName + ".ipa",
  dsymPath: "./platforms/ios/build/device/" + appName + ".app.dSYM",
  releaseApkPath: "./platforms/android/build/outputs/apk/android-release.apk",
  debugApkPath: "./platforms/android/build/outputs/apk/android-debug.apk",
  appPackagesPath: "./platforms/windows/AppPackages/**/*",
  typeScriptSources: "./www/scripts/**/*.ts",
  specSources: 'spec/**/*.ts',
  specOut: 'spec-out/'
};

// Signing releated vars
var androidKeystorePwd = process.env["ANDROID_PWD"],
    encryptionPwd = process.env["ENC_PWD"],
    iosP12Pwd = process.env["P12_PWD"],
    iosCodeSignIdentityRelease = "iPhone Distribution: Rockford Lhotka",
    iosCodeSignIdentityDebug = "iPhone Developer";

// HockeyApp vars
var hockeyappApiToken = process.env["HOCKEYAPP_API_TOKEN"],
    hockeyappAppIdiOS = "8411945a0f2c48b4bc5184304ef110a2",             // TODO: UPDATE WITH CORRECT APP ID FROM HOCKEYAPP ACCOUNT
    hockeyappAppIdAndroid = "149a28f8df374b18a9df3dbb15c57b6e";         

// build settings
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
    tsconfigPath = "tsconfig.json";
 

gulp.task('default', ['sass', 'build', 'spec'], function() {
    // Copy results to bin folder
    // Android
    gulp.src(paths.debugApkPath).pipe(gulp.dest("./bin/Android/Debug")); 
    // iOS
    gulp.src(paths.ipaPath).pipe(gulp.dest("./bin/iOS/Debug"));
    gulp.src(paths.dsymPath).pipe(gulp.dest("./bin/iOS/Debug"));
    // Windows
    gulp.src(paths.appPackagesPath).pipe(gulp.dest("./bin/Windows/Debug/AppPackages"));
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
    gulp.watch(paths.typeScriptSources, ['scripts']);
    gulp.watch(paths.specSources, ['spec-compile']);
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
    var tsConfig;
    if (fs.existsSync(tsconfigPath)) {
        // Use settings from scripts/tsconfig.json
        tsConfig = ts(ts.createProject(tsconfigPath));
    } else {
        // Otherwise use these default settings
        tsConfig = ts({
            noImplicitAny: false,
            noEmitOnError: true,
            removeComments: false,
            sourceMap: true,
            out: "appBundle.js",
            target: "es5"
        });
    }
    gulp.src(paths.typeScriptSources)
        .pipe(sourcemaps.init())
        .pipe(tsConfig)
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest("./www/scripts"));
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
    // ** NOTE: You may need to remove the android platform (cordova platform remove android) when switching between debug and release builds. 
    //          Build artifacts may expect release.keystore to be present after a release build and the script cleans it up to not leave 
    //          an unencrypted version on the build server.
     
    var openssl = sh.which("openssl");
    if(!openssl) {
        console.error("\"openssl\" not found in path. Download and install git command line tools at http://git-scm.com/downloads, ensure openssl is in the path, and try again.");
    }
    if(!androidKeystorePwd || !encryptionPwd) {
        console.error("Set environment variables ANDROID_PWD to the keystore password and ENC_PWD to the openssl encryption password.");
        process.exit(1);
    }
    sh.exec('"' + openssl + '" des3 -d -in release.keystore.enc -out release.keystore -pass pass:' + encryptionPwd);
    return cordovaBuild.buildProject("android", buildArgsRelease)
            .then(function() { 
                sh.rm("release.keystore"); 
                gulp.src(paths.releaseApkPath).pipe(gulp.dest("./bin/Android/Release"));
            });
});

gulp.task("build-ios-release", ["sass","scripts"], function() {
    if(!iosP12Pwd || !encryptionPwd) {
        console.error("Set environment variables P12_PWD to the p12 signing cert password and ENC_PWD to the openssl encryption password.");
        process.exit(1);
    }
    sh.exec("sh ios-install-certs.sh");
    return cordovaBuild.buildProject("ios", buildArgsRelease)
        .then(function() {
            gulp.src(paths.ipaPath).pipe(gulp.dest("./bin/iOS/Release"));
            gulp.src(paths.dsymPath).pipe(gulp.dest("./bin/iOS/Release"));
        });
});

gulp.task("hockeyapp-android-release", function() {
    var curl = sh.which("curl");
    if(!curl) {
        console.error("\"curl\" not found in path. Download and install git command line tools at http://git-scm.com/downloads, ensure openssl is in the path, and try again.");
        process.exit(1);
    }
    if(!hockeyappApiToken) {
        console.error("Set environment variable HOCKEYAPP_API_TOKEN to your API key and try again.");
        process.exit(1);
    }
    // Upload - See http://support.hockeyapp.net/kb/api/api-apps    
    sh.exec('"' + curl + '" -F "status=2" -F "notify=0" -F "ipa=@' + paths.releaseApkPath + '" -H "X-HockeyAppToken: ' + hockeyappApiToken + '" https://rink.hockeyapp.net/api/2/apps/' + hockeyappAppIdAndroid + '/app_versions/upload');
});

gulp.task("hockeyapp-ios-release", function() {
    if(!hockeyappApiToken) {
        console.error("Set environment variable HOCKEYAPP_API_TOKEN to your API key and try again.");
        process.exit(1);
    }
    var curl = sh.which("curl");
    var zip = sh.which("zip");
    var zipfile = "hockey-dsym-upload.dsym.zip";
    // Compress dsym - Required for upload if you install cordova-plugin-hockeyapp
    var zipcmd=zip + ' -r "' + zipfile + '" "' + paths.dsymPath + '"';
    sh.exec(zipcmd);    
    // Upload - See http://support.hockeyapp.net/kb/api/api-apps
    var curlString = curl + ' -F "status=2" -F "notify=0" -F "ipa=@' + paths.ipaPath + '" -F "dsym=@' + zipfile + '" -H "X-HockeyAppToken: ' + hockeyappApiToken + '" https://rink.hockeyapp.net/api/2/apps/' + hockeyappAppIdiOS + '/app_versions/upload';
    sh.exec(curlString);
    sh.rm(zipfile);
});


// Test JS
gulp.task("spec-clean", function () {
    return del(paths.specOut + "/**/*");
})
gulp.task('spec-compile', ['spec-clean'], function () {
    var tsConfig = ts({
        noImplicitAny: false,
        noEmitOnError: true,
        removeComments: false,
        sourceMap: true,
        target: "es5"
    });
    return gulp.src([paths.specSources])
        .pipe(sourcemaps.init())
        .pipe(tsConfig)
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest(paths.specOut));
})
var testFiles = ['www/lib/ionic/js/ionic.bundle.js',
            'node_modules/angular-mocks/angular-mocks.js',
            'spec-out/appFake.js',
            'www/scripts/appBundle.js',
            'spec-out/**/*spec.js'];
gulp.task('spec', ['spec-compile'], function () {
    gulp.src(testFiles)
        .pipe(jasmineBrowser.specRunner({ console: true }))
        .pipe(jasmineBrowser.headless());
})
gulp.task('spec-browser', ['spec-compile'], function () {
    gulp.src(testFiles)
        .pipe(watch(testFiles))
        .pipe(jasmineBrowser.specRunner())
        .pipe(jasmineBrowser.server({ port: 8888 }));
})