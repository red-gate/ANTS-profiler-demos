# Performs a drop and recreate of the Library Manager database
# Assumes target database is on local instance with name LibraryManager. If this is not true, update the App.Config too.

$ErrorActionPreference = "Stop"

# If database already exists, drop and recreate it
$ServerInstance = "."
$databaseName = "LibraryManager"
Write-Output "Dropping and recreating database $databaseName on server $ServerInstance"
$sql = "USE master IF EXISTS(select * from sys.databases where name='$databaseName') alter database $databaseName set single_user with rollback immediate DROP DATABASE $databaseName CREATE DATABASE $databaseName"
invoke-sqlcmd -ServerInstance $ServerInstance -Query $sql | Write-Host # Assumes WinAuth for authentication

# Redeploy database using SQL Change Automation
$myDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$databaseDir = Join-Path -Path $myDir -ChildPath "Database"
Test-Path $databaseDir

$targetDb = New-DatabaseConnection -ServerInstance $ServerInstance -Database $databaseName 
Test-DatabaseConnection $targetDb

Write-Host "Deploying DB scripts in $databaseDir to database $databaseName on server $ServerInstance"
Sync-DatabaseSchema -Source $databaseDir -Target $targetDb

# Insert data using SQL Data Generator
Write-Warning "Inserting 60,000,000 rows of test data to database $databaseName on server $ServerInstance with SQL Data Generator."
Write-Warning "(This might take a while.)"
$dataGenProjFile = Join-Path -Path $myDir -ChildPath "DataGeneration.sqlgen"
SQLDataGenerator.exe /project:$dataGenProjFile
