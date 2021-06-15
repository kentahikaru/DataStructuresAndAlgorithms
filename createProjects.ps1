[CmdletBinding()]
param (
[Parameter(Mandatory=$True)]
[string]$where,
[string]$what
)

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
dotnet new mstest
cd ..

$whatbm = $what + 'Benchmark'
mkdir $whatbm
cd $whatbm
dotnet new console
cd ..

$whatproj = $what + '/' + $what + '.csproj'
$whattestsproj = $whattests + '/' + $whattests + '.csproj'
$whatbmproj = $whatbm + '/' + $whatbm + '.csproj'

dotnet new sln
dotnet sln add $whatproj $whattestsproj $whatbmproj