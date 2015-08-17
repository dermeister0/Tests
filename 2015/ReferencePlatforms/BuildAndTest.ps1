#requires -Version 3.0

$msbuild = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe'
$solutionPath = "$PSScriptRoot\ReferencePlatforms.sln"
$outputPath = "$PSScriptRoot\Test"

$platform = 'Any CPU'
& $msbuild $solutionPath '/m' '/t:Build' '/p:Configuration=Release' "/p:Platform=$platform" '/verbosity:normal'

$platform = 'x64'
& $msbuild $solutionPath '/m' '/t:Build' '/p:Configuration=Release' "/p:Platform=$platform" '/verbosity:normal'

$platform = 'x86'
& $msbuild $solutionPath '/m' '/t:Build' '/p:Configuration=Release' "/p:Platform=$platform" '/verbosity:normal'

if (Test-Path $outputPath)
{
    Remove-Item -recurse -force $outputPath
}

New-Item $outputPath -ItemType directory
New-Item "$outputPath\AnyCPU" -ItemType directory
New-Item "$outputPath\x64" -ItemType directory
New-Item "$outputPath\x86" -ItemType directory

Copy-Item "$PSScriptRoot\SomeLibrary\bin\Release\*" "$outputPath\AnyCPU"
Copy-Item "$PSScriptRoot\SomeLibrary\bin\x64\Release\*" "$outputPath\x64"
Copy-Item "$PSScriptRoot\SomeLibrary\bin\x86\Release\*" "$outputPath\x86"

Copy-Item "$PSScriptRoot\ReferencePlatforms\bin\Release\ReferencePlatforms.*" "$outputPath\AnyCPU"
Copy-Item "$PSScriptRoot\ReferencePlatforms\bin\Release\ReferencePlatforms.*" "$outputPath\x64"
Copy-Item "$PSScriptRoot\ReferencePlatforms\bin\Release\ReferencePlatforms.*" "$outputPath\x86"
