#!/usr/bin/env bash
if test "$OS" = "Windows_NT"
then
  # use .Net


  tools/build/FAKE/tools/FAKE.exe $@ --fsiargs -d:MONO build.fsx 
else
  # use mono

  mono tools/build/FAKE/tools/FAKE.exe $@ --fsiargs -d:MONO build.fsx 
fi
