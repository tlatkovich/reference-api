# import module using '. .\[database]-equipmentdb-ef-migration-tools.ps1'
# then login with 'az login'
# then add a migration with 'add-migration' (migrations are applied to the database locally via Aspire)

# Calls ef-add-migration from ef-migration-tools.ps1 with correct parameters for EquipmentDb

Write-Host "Loading script..." -NoNewline -ForegroundColor Green

function add-migration {
    param(
        [bool]$verbose = $false
    )
    $startupProjectPath         = "../../../Equipment.Api"
    $projectPath                = "../../../Equipment.Infrastructure" # The target project.
    $migrationsOutputFolder     = "Databases/EquipmentDb/Migrations" # The directory used to output the migration files. Paths are relative to the target project directory.
    $scriptsOutputFolder        = "Scripts" # The directory used to output the script files. Paths are relative to the location of this script.

    . "$PSScriptRoot/../ef-migration-tools.ps1"

    ef-add-migration -startupProjectPath $startupProjectPath -projectPath $projectPath -migrationsOutputFolder $migrationsOutputFolder -scriptsOutputFolder $scriptsOutputFolder -taco:$verbose
}

Write-Host "Done" -ForegroundColor Green
