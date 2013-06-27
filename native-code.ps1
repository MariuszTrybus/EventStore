﻿# Event Store Build (.NET/Windows) - v8.ps1
# Use Invoke-psake ? to see further description

Framework "4.0x64"

Task default -depends ?

Task ? -description "Writes script documentation to the host" {
    Write-Host "Builds the Event Store native portions. See default.ps1 for more info."
}

# Directories and solutions
Properties {
    $baseDirectory = Resolve-Path .
    $srcDirectory = Join-Path $baseDirectory (Join-Path "src" "EventStore")
    $libsDirectory = Join-Path $srcDirectory "libs"
    $v8Directory = Join-Path $baseDirectory "v8"
    $pythonExecutable = Join-Path $v8Directory (Join-Path "third_party" (Join-Path "python_26" "python.exe"))
    $js1Project = Join-Path $srcDirectory (Join-Path "EventStore.Projections.v8Integration" "EventStore.Projections.v8Integration.vcxproj")
}

# Configuration
Properties {
    if ($platform -eq "x64")
    {
        # The parameter to pass to Gyp to generate projects for the appropriate architecture
	    $v8PlatformParameter = "-Dtarget_arch=x64"
        
        # The platform name for V8 (as generated by gyp)
        $v8VisualStudioPlatform = "x64"
        
        # The destination for the built V8 libraries to be copied to
        $v8LibsDestination = Join-Path $libsDirectory "x64"

        # The platform for JS1 (as defined in the project file)
        $js1VisualStudioPlatform = "x64"
    }
    elseif ($platform -eq "x86")
    {
        # The parameter to pass to Gyp to generate projects for the appropriate architecture
        $v8VisualStudioPlatform = "Win32"
        
        # The platform name for V8 (as generated by Gyp)
        $v8PlatformParameter = "-Dtarget_arch=Win32"
        
        # The destination for the built V8 libraries to be copied to
        $v8LibsDestination = Join-Path $libsDirectory "Win32"

        # The platform for JS1 (as defined in the project file)
        $js1VisualStudioPlatform = "Win32"
    }
    else
    {
        throw "Platform $platform is not supported." 
    }

    if ($configuration -eq "release")
    {
        # The configuration name for V8 (as generated by Gyp)
        $v8VisualStudioConfiguration = "Release"

        # The destination V8 is built in (as generated by Gyp)
        $v8OutputDirectory = Join-Path $v8Directory (Join-Path "build" (Join-Path "Release" "lib"))
        
        # The configuration name for JS1 (as defined in the project file)
        $js1VisualStudioConfiguration = "Release"
    }
    elseif ($configuration -eq "debug")
    {
        # The configuration name for V8 (as generated by Gyp)
        $v8VisualStudioConfiguration = "Debug"
        
        # The destination V8 is built in (as generated by Gyp)
        $v8OutputDirectory = Join-Path $v8Directory (Join-Path "build" (Join-Path "Debug" "lib"))
        
        # The configuration name for JS1 (as defined in the project file)
        $js1VisualStudioConfiguration = "Debug"
    }
    else
    {
        throw "Configuration $configuration is not supported. If you think it should be, edit the Setup-ConfigurationParameters task to add it."
    }
}

Task Build-NativeFull -Depends Clean-V8, Build-V8, Copy-V8ToLibs, Build-JS1

Task Build-NativeIncremental -Depends Build-V8, Copy-V8ToLibs, Build-JS1


Task Clean-V8 {
    Push-Location $v8Directory
    Exec { git clean --quiet -e gyp -fdx -- build }
    Exec { git clean --quiet -dfx -- src }
    Exec { git clean --quiet -dfx -- test } 
    Exec { git clean --quiet -dfx -- tools }
    Exec { git clean --quiet -dfx -- preparser }
    Exec { git clean --quiet -dfx -- samples }
    Exec { git reset --quiet --hard }
    Pop-Location
}

Task Build-V8 {
    Push-Location $v8Directory
    try {
        $gypFile = Join-Path $v8Directory (Join-Path "build" "gyp_v8")
        $commonGypiPath = Join-Path $v8Directory (Join-Path "build" "common.gypi")
        $includeParameter = "-I$commonGypiPath"

        if ($platformToolset -eq $null) {
            $platformToolset = Get-BestGuessOfPlatformToolsetOrDie($v8VisualStudioPlatform)
        }

        Exec { & $pythonExecutable $gypFile $includeParameter $v8PlatformParameter }
        Exec { msbuild .\build\all.sln /m /p:Configuration=$v8VisualStudioConfiguration /p:Platform=$v8VisualStudioPlatform /p:PlatformToolset=$platformToolset }
    } finally {
        Pop-Location
    }
}

Task Copy-V8ToLibs -Depends Build-V8 {
    $v8IncludeDestination = Join-Path $libsDirectory "include"
    
    $v8LibsSource = Join-Path $v8OutputDirectory "*.lib"
    $v8IncludeSource = Join-Path $v8Directory (Join-Path "include" "*.h")
    
    New-Item -ItemType Container -Path $v8LibsDestination -ErrorAction SilentlyContinue
    Copy-Item $v8LibsSource $v8LibsDestination -Recurse -Force -ErrorAction Stop
    New-Item -ItemType Container -Path $v8IncludeDestination -ErrorAction SilentlyContinue
    Copy-Item $v8IncludeSource $v8IncludeDestination -Recurse -Force -ErrorAction Stop

    Push-Location $v8LibsDestination

    #V8 build changed at some point to include the platform in the
    # name of the lib file. Where we use V8 we still use the old names
    # so rename here if necessary.
    foreach ($libFile in Get-ChildItem) {
        $newName = $libFile.Name.Replace(".x64.lib", ".lib")
        if ($newName -ne $libFile.Name) {
            if (Test-Path $newName) {
                Remove-Item $newName -Force
            }
            Rename-Item -Path $libFile -NewName $newName
        }
    }
    Pop-Location
}

Task Build-JS1 {    
    if ($platformToolset -eq $null) {
        $platformToolset = Get-BestGuessOfPlatformToolsetOrDie($js1VisualStudioPlatform)
        Write-Verbose "Projections Integration PlatformToolset: Determined to be $platformToolset"
    } else {
        Write-Verbose "Projections Integration PlatformToolset: Set to $platformToolset"
    }

    Exec { msbuild $js1Project /p:Configuration=$js1VisualStudioConfiguration /p:Platform=$js1VisualStudioPlatform /p:PlatformToolset=$platformToolset }
}

# Helper Functions
Function Get-BestGuessOfPlatformToolsetOrDie {
    [CmdletBinding()]
    Param(
        [Parameter()][string]$platform = "x64"
    )
    Process {
        if (Test-Path 'Env:\ProgramFiles(x86)') {
            $programFiles = ${env:ProgramFiles(x86)}
        } else {
            $programFiles = ${env:ProgramFiles}
        }

        $mscppDir = Join-Path $programFiles (Join-Path "MSBuild" (Join-Path "Microsoft.Cpp" "v4.0"))

        Assert (Test-Path $mscppDir) "$mscppDir does not exist. It appears this machine either does not have MSBuild and C++ installed, or it's in a weird place. Specify the platform toolset manually as a parameter."

        #We'll prefer the V120 toolset if it's available (VS2013) - EDIT apparently not.
        #$potentialV120Dir = Join-Path $mscppDir "V120"
        #if (Test-Path $potentialV120Dir) {
        #    return "V120"
        #}

        #Failing that V110 toolset (VS2012)
        $potentialV110Dir = Join-Path $mscppDir "V110"
        if (Test-Path $potentialV110Dir) {
            return "V110"
        }

        #Failing that, we'll have to look inside a platform to figure out which ones are there
        $platformToolsetsDir = Join-Path $mscppDir (Join-Path "Platforms" (Join-Path $platform "PlatformToolsets"))

        Assert (Test-Path $platformToolsetsDir) "None of these directories exist: [V110, Platforms]. Specify the platform toolset manually as a parameter."

        #If we have Windows7.1SDK we'll take that, otherwise we'll assume V100
        if (Test-Path (Join-Path $platformToolsetsDir "Windows7.1SDK")) {
            return "Windows7.1SDK"
        } elseif (Test-Path (Join-Path $platformToolsetsDir "V100")) { 
            return "V100"
        } else {
            Assert ($false) "Can't find any supported platform toolset (V100, V110, Windows7.1SDK). It's possible that this detection is wrong, in which case you should specify the platform toolset manually as a parameter."
        }
    }
}