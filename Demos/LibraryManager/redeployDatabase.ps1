# Performs a drop and recreate of the LibraryManager database and uses SQL Data Generator to insert test data

####################   REQUIREMENTS   ####################
# Assumes target database is on local instance with name LibraryManager. If this is not true, update the App.Config too.
# For SQL Data Generator it is assumed that Redgate SQL Data Generaotor v4 is installed and the path to DataGenerator.exe is added to your PATH system variable
# Requires 6 GB of free disk space
##########################################################

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

# Insert data using SQL Data Generator. Lots of data to simulate performance issues in APP demo.
Write-Warning "Inserting 20,000,000 rows of test data to database $databaseName on server $ServerInstance with SQL Data Generator. (About 6 GB)."
Write-Warning "(This might take a while. Probably about 20 mins on an average spec VM.)"
$dataGenProjFile = Join-Path -Path $myDir -ChildPath "DataGeneration.sqlgen" 
SQLDataGenerator.exe /project:$dataGenProjFile
