[Cmdletbinding()]
Param(
    [Parameter(Mandatory = $true)][string]$StorageAccountPath,
    [Parameter(Mandatory = $true)][string]$PathToFile
)

Function ReplacePlaceholderWithValueInFile
{
    param( 
        [string]$placeholder,
        [string]$actualValue)

    $customPolicyBrandingFileContent = Get-Content -Path $PathToFile -Raw
    $customPolicyBrandingFileContent -replace $placeholder, $actualValue | Set-Content -Encoding UTF8 -Path $PathToFile
}

ReplacePlaceholderWithValueInFile -placeholder "##STORAGE_ACCOUNT_PATH##" -actualValue $StorageAccountPath