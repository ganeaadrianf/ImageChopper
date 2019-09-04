#comanda in poershell penru a face copiere si redenumire
Get-ChildItem C:\outf6e95815-8152-45a2-bb98-389f03d15b71\ | ForEach-Object {Copy-Item -Path ($_.DirectoryName+'\\'+$_.Name)  -Destination ('C:\outc2a2f78d-ecd7-4b35-8864-e52d581313f9\'+ $_.Name.Replace("_1","_3"))}
