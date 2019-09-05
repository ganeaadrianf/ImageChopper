Get-ChildItem | ForEach-Object {Copy-Item -Path ($_.DirectoryName+'\'+$_.Name) -Destination ($_.DirectoryName+'\'+ $_.Name.Replace("_3","_4"))}
