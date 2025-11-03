# Get git current changes (file names)
$files = git status --porcelain | ForEach-Object {
    $_.Substring(3)
}

if ($files.Count -eq 0) {
    Write-Host "No diff"
    exit
}

# Concat file names to string with space separator
$filesString = $files -join " "

Write-Host "Run dotnet format --include $files --verbosity detailed --no-restore"
dotnet format --include $files --verbosity detailed --no-restore
