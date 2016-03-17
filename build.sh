#!/usr/bin/env bash
if test "$OS" = "Windows_NT"
then
  # use .Net


  packages/build/FAKE/tools/FAKE.exe $@ --fsiargs -d:MONO build.fsx 
else
  # use mono

  mono packages/build/FAKE/tools/FAKE.exe $@ --fsiargs -d:MONO build.fsx 
fi
