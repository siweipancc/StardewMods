# 在 release 下边发行文件
Set-Location -LiteralPath $PSScriptRoot
$wdir=Get-Item -LiteralPath $PSScriptRoot
$projectName=$wdir.Name

if(-not (Test-Path -Path "./release" -PathType Container)){
   New-Item -Path "./release" -ItemType "directory"
}

$version= (Get-Content "manifest.json" | ConvertFrom-Json).Version;
Write-Output "current release version $version"
$expected="./release/$projectName $version.zip"
if(Test-Path -LiteralPath $expected){
   Write-Host "remove exist file"
   Remove-Item -LiteralPath $expected -Confirm
}

7z a -tzip "./release/$projectName $version.zip" -mx0 -xr!".idea" -xr!".psd" -xr!"Folder.DotSettings.user" -xr!"release.ps1" -xr!"release" -xr!"docs"
$release = Get-Item -LiteralPath "./release/$projectName $version.zip"
Write-Output "new release ($version) in $($release.FullName)"

pause