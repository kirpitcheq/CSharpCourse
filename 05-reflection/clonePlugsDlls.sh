#!/bin/sh
rm -rf 05-reflection/plugins/*
find . -type f -iregex "./05-reflection\.Plugins.*/bin/Debug/net7.0/05-reflection.Plugins.*\.dll" -exec cp {} 05-reflection/plugins/ \;