#!/bin/sh
chmod +x hooks/after_prepare/010_add_platform_class.js

CURDIR=$(PWD)

cd ../Signing

openssl des3 -d -in Ad_Hoc__MissingChildrenMinnesota_Wildcard.mobileprovision.enc -out Ad_Hoc__MissingChildrenMinnesota_Wildcard.mobileprovision -pass pass:$ENC_PWD
openssl des3 -d -in Dev__MissingChildrenMinnesota_Wildcard.mobileprovision.enc -out Dev__MissingChildrenMinnesota_Wildcard.mobileprovision -pass pass:$ENC_PWD
openssl des3 -d -in dev.p12.enc -out dev.p12 -pass pass:$ENC_PWD
openssl des3 -d -in distro.p12.enc -out distro.p12 -pass pass:$ENC_PWD

UUID=$(/usr/libexec/PlistBuddy -c "Print UUID" /dev/stdin <<< $(/usr/bin/security cms -D -i "Ad_Hoc__MissingChildrenMinnesota_Wildcard.mobileprovision"))
cp Ad_Hoc__MissingChildrenMinnesota_Wildcard.mobileprovision $HOME/Library/MobileDevice/Provisioning\ Profiles/$UUID.mobileprovision
UUID=$(/usr/libexec/PlistBuddy -c "Print UUID" /dev/stdin <<< $(/usr/bin/security cms -D -i "Dev__MissingChildrenMinnesota_Wildcard.mobileprovision"))
cp Dev__MissingChildrenMinnesota_Wildcard.mobileprovision $HOME/Library/MobileDevice/Provisioning\ Profiles/$UUID.mobileprovision
  
/usr/bin/security import dev.p12 -P "$P12_PWD" -A -t cert -f pkcs12 -k "$(/usr/bin/security default-keychain | grep -oE '[^"]*[\n]')"
/usr/bin/security import distro.p12 -P "$P12_PWD" -A -t cert -f pkcs12 -k "$(/usr/bin/security default-keychain | grep -oE '[^"]*[\n]')"

rm dev.p12
rm distro.p12
rm Ad_Hoc__MissingChildrenMinnesota_Wildcard.mobileprovision 
rm Dev__MissingChildrenMinnesota_Wildcard.mobileprovision 

cd $CURDIR
