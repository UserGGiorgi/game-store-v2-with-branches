Param(
  [string] $Shard1Svc = "MongoShard1Daemon",
  [string] $DataDirectory = "C:\mongo\data",
  [string] $LogsDirectory = "C:\mongo\logs"
)

Set-StrictMode -Version 3

$WorkingDir = Convert-Path "."

# remove services
.\mongobin\mongod --remove --serviceName "$Shard1Svc"

# cleanup data directory
New-Item $DataDirectory -Type Directory -Force
New-Item $LogsDirectory -Type Directory -Force

Remove-Item ($DataDirectory + "\*") -Recurse -Force
Remove-Item ($LogsDirectory + "\*") -Recurse -Force

New-Item ($DataDirectory + "\shard1") -Type Directory -Force

# install services
.\mongobin\mongod --config "$WorkingDir\config\shard1.cfg" --install --serviceName "$Shard1Svc" --serviceDisplayName "$Shard1Svc" --logpath "$LogsDirectory\shard1.log"
net start $Shard1Svc
Write-Host "Mongo installed"
# run db init
.\mongobin\mongo --host localhost --port 27017 --shell