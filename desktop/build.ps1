param([string]$OutputPath)
$ErrorActionPreference = 'Stop'
$project = Split-Path $PSScriptRoot -Parent
if (!$OutputPath) { $OutputPath = Join-Path $PSScriptRoot 'Heartbeam.exe' }
$compiler = Join-Path $env:windir 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'
if (!(Test-Path $compiler)) { $compiler = Join-Path $env:windir 'Microsoft.NET\Framework\v4.0.30319\csc.exe' }
if (!(Test-Path $compiler)) { throw 'Microsoft .NET Framework C# compiler missing.' }
node (Join-Path $project 'build.cjs')
if ($LASTEXITCODE -ne 0) { throw 'Web build failed.' }
& $compiler /nologo /target:winexe /optimize+ /codepage:65001 /reference:System.Windows.Forms.dll "/out:$OutputPath" "/resource:$project\index.html,Heartbeam.Page" (Join-Path $PSScriptRoot 'Program.cs')
if ($LASTEXITCODE -ne 0) { throw 'Windows build failed.' }
