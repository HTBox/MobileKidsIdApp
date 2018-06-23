#!/bin/bash
# Requires npm package svgexport
# https://www.npmjs.com/package/svgexport

declare -a sizes=("20" "29" "40" "58" "60" "76" "87" "120" "152" "167" "180" "1024")
for s in "${sizes[@]}"
do
    svgexport iOS_svg.svg "appicon_""$s".png "$s":"$s"   
done
