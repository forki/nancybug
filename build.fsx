// include Fake lib
#r @"tools/FAKE/tools/FakeLib.dll"
#r @"tools/FAKE/tools/Newtonsoft.Json.dll"
open Fake
open FileUtils
open Fake.AssemblyInfoFile
open Fake.Git
open Fake.FileHelper
open Fake.Testing.XUnit2
open Newtonsoft.Json
open System
open System.Net
open System.Web
open System.Text
open System.IO

let buildDir = "./buildoutput/"
let testDir  = "./unittestoutput/"

let nugetPath = EnvironmentHelper.environVarOrDefault "nugetPath" "NuGet.exe"



Target "Clean" (fun _ ->
    trace "Clean"
    CleanDir buildDir
    CleanDir testDir
)

Target "Restore" (fun _ ->

    trace "Restore"
    !! "packages.config"
    |> Seq.iter (RestorePackage ( fun p -> {p with ToolPath = nugetPath }))

    trace "Restore"
    !! "/src/xUnitNancyv2Bug/packages.config"
    |> Seq.iter (RestorePackage ( fun p -> {p with ToolPath = nugetPath }))


)

Target "BuildTest" (fun _ ->
    trace "Build Test"
    !! "**/*.csproj" 
      |> MSBuildDebug testDir "Build"
      |> ignore //Log "TestBuild-Output: "
)


Target "RunTests" (fun _ ->
      trace "Run Tests"
      !! (testDir + "/xUnitNancyv2Bug.dll") 
        |> xUnit2 (fun p ->
            {p with
              ToolPath = findToolInSubPath "xunit.console.exe" (currentDirectory @@ "packages")
              ErrorLevel = TestRunnerErrorLevel.Error
            })
)



// Default target
Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

"Clean"
  ==> "Restore"
  ==> ("BuildTest")
  ==> ("RunTests")

  ==> "Default"

// start build
RunTargetOrDefault "Default"
