#!/usr/bin/env bash
if test "$OS" = "Windows_NT"
then
  # use .Net


  tools/FAKE/tools/FAKE.exe $@ --fsiargs -d:MONO build.fsx 
else
  # use mono

  mono tools/FAKE/tools/FAKE.exe $@ --fsiargs -d:MONO build.fsx 
fi
