<#
.SYNOPSIS
createProjects.ps1 creates project structure of class library, tests and benchmark.
.DESCRIPTION
createProjects.ps1 creates a project structure consisting of project library, tests and benchmark.
Class library name is name given as parameter. 
Tests are named as input parameter + 'Tests'.
Benchmark is named as input parameter + 'Benchmark'
.PARAMETER where
Where to create project structure.
.PARAMETER what
What to create. What is the (common) name for project(s).
.EXAMPLE
createProjects.ps1 . myApplication
#>
[CmdletBinding()]
param (
[Parameter(Mandatory=$True)]
[string]$where,
[string]$what
)
$whatproj = $what + '/' + $what + '.csproj'


cd $where
mkdir $what
cd $what

mkdir $what
cd $what
dotnet new classlib
cd ..

$whattests = $what + 'Tests'
mkdir $whattests
cd $whattests
dotnet new nunit
dotnet add reference ../$whatproj
cd ..

$whatbm = $what + 'Benchmark'
mkdir $whatbm
cd $whatbm
dotnet new console
dotnet add reference ../$whatproj
cd ..

$whattestsproj = $whattests + '/' + $whattests + '.csproj'
$whatbmproj = $whatbm + '/' + $whatbm + '.csproj'

dotnet new sln
dotnet sln add $whatproj $whattestsproj $whatbmproj