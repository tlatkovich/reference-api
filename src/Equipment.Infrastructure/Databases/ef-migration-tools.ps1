# Contains the ef-add-migration function for EF Core migrations

function ef-add-migration {
    param(
        [Parameter(Mandatory=$true)][string]$startupProjectPath,
        [Parameter(Mandatory=$true)][string]$projectPath,
        [Parameter(Mandatory=$true)][string]$migrationsOutputFolder,
        [Parameter(Mandatory=$true)][string]$scriptsOutputFolder,
        [bool]$taco = $false
    )
    $ErrorActionPreference = "Stop"

    $root = Resolve-Path "$PSScriptRoot/.."

    # get the list of current migrations
    $migrations = Get-ChildItem -Path (Join-Path $root $migrationsOutputFolder) |
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

    $verboseFlag = if ($taco) { "--verbose" } else { "" }

    # add the new migration
    Write-Host "Adding migration $next" -ForegroundColor Green
    dotnet ef migrations add $next `
        -p $projectPath `
        -s $startupProjectPath `
        -o $migrationsOutputFolder

    # script the new migration
    Write-Host "Generating SQL script for migration $next" -ForegroundColor Green
    $args = @("ef", "migrations", "script")
    if ($taco) { $args += "--verbose" }
    $args += @(
        "-i",
        "-p", $projectPath,
        "-s", $startupProjectPath,
        "-o", "$scriptsOutputFolder/$next.sql"
    )
    dotnet @args

    Write-Host "Generating SQL script for migration latest" -ForegroundColor Green
    $args = @("ef", "migrations", "script")
    if ($taco) { $args += "--verbose" }
    $args += @(
        "-i",
        "-p", $projectPath,
        "-s", $startupProjectPath,
        "-o", "$scriptsOutputFolder/latest.sql"
    )
    dotnet @args

    # script the rollback
    if ($current) {
        Write-Host "Generating SQL rollback script for migration $next" -ForegroundColor Green
        $args = @("ef", "migrations", "script", $next, $current)
        if ($taco) { $args += "--verbose" }
        $args += @(
            "-i",
            "-p", $projectPath,
            "-s", $startupProjectPath,
            "-o", "$scriptsOutputFolder/$next.rollback.sql"
        )
        dotnet @args

        Write-Host "Generating SQL rollback script for migration latest" -ForegroundColor Green
        $args = @("ef", "migrations", "script", $next, $current)
        if ($taco) { $args += "--verbose" }
        $args += @(
            "-i",
            "-p", $projectPath,
            "-s", $startupProjectPath,
            "-o", "$scriptsOutputFolder/latest.rollback.sql"
        )
        dotnet @args
    }

    Write-Host "Done" -ForegroundColor Green
}
