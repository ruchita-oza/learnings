@echo off
set /p zipName= "Please Provide Zip Name :" 
git diff --name-only --diff-filter=ACMRTUXB HEAD > files.txt
zip %zipName%.zip -@ < files.txt
del files.txt
