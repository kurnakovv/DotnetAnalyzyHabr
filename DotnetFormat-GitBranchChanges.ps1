$baseBranch = "main" # or "master"
$currentBranch = git rev-parse --abbrev-ref HEAD

# Get changed file names in current branch
$files = git diff --name-only $baseBranch

# Delete useless spaces
$files = $files | Where-Object { $_ -ne "" }

if ($files.Count -eq 0) {
    Write-Host "No diff between current branch ($currentBranch) and base branch ($baseBranch)"
    exit
}

Write-Host "Diff between current branch ($currentBranch) and base branch ($baseBranch) list"
Write-Host "-----------------------"
$files | ForEach-Object { Write-Host $_ }
Write-Host "-----------------------"

dotnet format --include $files --verbosity detailed
