# import module using . .\MigrationGenerator.ps1
# then login with az login
# then add a migration with EF-Add-Migration (include the updateDb switch to update the database after adding a migration)

Write-Host "Loading script..." -NoNewline -ForegroundColor Green

# Define paths as variables for reuse
$projectPath       = "../../../Equipment.Infrastructure"
$startupProject    = "../../../Equipment.Api"
$migrationsOutput  = "Databases/EquipmentDb/Migrations"
$scriptsOutput     = "Scripts"

function EF-Add-Migration () {
    $ErrorActionPreference = "Stop"

    # get the list of current migrations
    $migrations = Get-ChildItem -Path "Migrations" |
                  Where-Object { $_.Name -match "^\d{14}_\S*.cs$" } |
                  Sort-Object -Descending |
                  ForEach-Object { $_.Name.Split("_")[1].Split(".")[0] }

    # set variables from list
    if ($migrations -and $migrations.Count -gt 0) {
        $current = $migrations[0]
    } else {
        $current = "0"
    }

    if ([bool]($current -as [int] -is [int])) {
        $next = [int]$current + 1
    } else {
        $next = 1
    }

    Write-Host "Current Migration is $current" -ForegroundColor Green
    Write-Host "Next Migration is $next"    -ForegroundColor Green

    $env:ASPNETCORE_ENVIRONMENT = "Local"

    # add the new migration
    Write-Host "Adding migration $next" -ForegroundColor Green
    dotnet ef migrations add $next `
        -p $projectPath `
        -s $startupProject `
        -o $migrationsOutput

    # script the new migration
    Write-Host "Generating SQL script for migration $next" -ForegroundColor Green
    dotnet ef migrations script --verbose -i `
        -p $projectPath `
        -s $startupProject `
        -o "$scriptsOutput/$next.sql"

    Write-Host "Generating SQL script for migration latest" -ForegroundColor Green
    dotnet ef migrations script --verbose -i `
        -p $projectPath `
        -s $startupProject `
        -o "$scriptsOutput/latest.sql"

    # script the rollback
    if ($current) {
        Write-Host "Generating SQL rollback script for migration $next" -ForegroundColor Green
        dotnet ef migrations script $next $current --verbose `
            -i `
            -p $projectPath `
            -s $startupProject `
            -o "$scriptsOutput/$next.rollback.sql"

        Write-Host "Generating SQL rollback script for migration latest" -ForegroundColor Green
        dotnet ef migrations script $next $current --verbose `
            -i `
            -p $projectPath `
            -s $startupProject `
            -o "$scriptsOutput/latest.rollback.sql"
    }

    Write-Host "Done" -ForegroundColor Green
}

Write-Host "Done" -ForegroundColor Green
