#!/bin/bash

# çalıştırıldığı dizine git
cd "$(dirname "$0")"

# .nupkg uzantılı dosyaları bul ve sil
find . -type f -name "*.nupkg" -exec rm -f {} \;

echo "nupkg uzantılı dosyalar başarıyla silindi."

nuspec_file=$(find . -type f -name "*.nuspec" -print -quit)

# nuget pack oluştur.
dotnet clean
dotnet build -c Release
nuget pack "$nuspec_file" -Properties Configuration=Release

echo "yeni nuget pack başarıyla oluşturuldu."

nupkg_file=$(find . -type f -name "*.nupkg" -print -quit)

echo "$nupkg_file"

# Bu alana nuget.org yada nexus adresini yazabilirsin.
#nuget push "$nupkg_file" -src ""

echo "nuget paketi başarıyla gönderildi."

# For CI/CD pipeline remove this line
read -p "Press [Enter] key to exit..."