param(
    $path
)

$csFiles = (Get-ChildItem -Path $path -Filter *.cs -Recurse) | 
    Where-Object {
        (-Not $_.FullName.Contains('\obj\')) -And
        (-Not $_.FullName.Contains('\packages\')) -And
        (-Not $_.FullName.Contains('\bin\')) -And
        (-Not $_.FullName.Contains('RefitStubs.cs')) -And
        (-Not $_.FullName.Contains('.Designer.cs')) }

$validationSuccess = $true

foreach ($csFile in $csFiles)
{
    $fileContent = (Get-Content $csFile.FullName)

    if ($fileContent[0] -match '// <external>')
    {
        # skip external files
        continue
    }
    
    if ($fileContent[0] -match '// <copyright file=\"(.*)\" company=\"PlanGrid, Inc.\">')
    {
        if ($Matches[1] -ne $csFile.Name)
        {
            $validationSuccess = $false
            
            Write-Output "$($csFile.FullName)(1) : error CP0002: Copyright name doesn't match file name"
        }
    }
    else
    {
        $validationSuccess = $false
        Write-Output "$($csFile.FullName)(1) : error CP0001: Copyright block not found"
    }
}

if (-Not $validationSuccess)
{
    exit 1
}

exit 0