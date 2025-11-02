# Получаем список изменённых файлов
$files = git status --porcelain | ForEach-Object {
    $_.Substring(3)  # Убираем первые 3 символа, оставляем путь к файлу
}

# Если нет изменённых файлов — ничего не делаем
if ($files.Count -eq 0) {
    Write-Host "Изменённых файлов нет."
    exit
}

# Объединяем имена файлов в одну строку через пробел
$filesString = $files -join " "

# Вызываем dotnet format с включением этих файлов
# Используем --include "$filesString"
dotnet format --include $files --verbosity detailed
