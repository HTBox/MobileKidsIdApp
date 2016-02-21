#!/bin/sh
chmod +x hooks/after_prepare/010_add_platform_class.js

CURDIR=$(PWD)

cd ../Signing

# Install Dev Provisioning Profile
PROV=Dev__MissingChildrenMinnesota_Wildcard.mobileprovision
openssl des3 -d -in $PROV.enc -out $PROV -pass pass:$ENC_PWD
UUID=$(/usr/libexec/PlistBuddy -c "Print UUID" /dev/stdin <<< $(/usr/bin/security cms -D -i "$PROV"))
cp $PROV $HOME/Library/MobileDevice/Provisioning\ Profiles/$UUID.mobileprovision

# Install Ad Hoc Release Provisioning Profile
PROV=Ad_Hoc__MissingChildrenMinnesota_Wildcard.mobileprovision
openssl des3 -d -in $PROV.enc -out $PROV -pass pass:$ENC_PWD
UUID=$(/usr/libexec/PlistBuddy -c "Print UUID" /dev/stdin <<< $(/usr/bin/security cms -D -i "$PROV"))
cp $PROV $HOME/Library/MobileDevice/Provisioning\ Profiles/$UUID.mobileprovision

# TODO: Install App Store Provisioning Profile

# Import dev and distribution certs into keychain  
openssl des3 -d -in dev.p12.enc -out dev.p12 -pass pass:$ENC_PWD
/usr/bin/security import dev.p12 -P "$P12_PWD" -A -t cert -f pkcs12 -k "$(/usr/bin/security default-keychain | grep -oE '[^"]*[\n]')"
openssl des3 -d -in distro.p12.enc -out distro.p12 -pass pass:$ENC_PWD
/usr/bin/security import distro.p12 -P "$P12_PWD" -A -t cert -f pkcs12 -k "$(/usr/bin/security default-keychain | grep -oE '[^"]*[\n]')"

# Clean up
rm dev.p12
rm distro.p12
rm Ad_Hoc__MissingChildrenMinnesota_Wildcard.mobileprovision 
rm Dev__MissingChildrenMinnesota_Wildcard.mobileprovision 

cd $CURDIR
