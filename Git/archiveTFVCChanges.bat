

set /p zipName= "Please Provide Zip Name :" 
for /f "tokens=1,*" %%i in ('tf diff /format:Brief ^| findstr /c:"edit" /c:"add"') do (
    echo %%j >> files.txt
)
zip %zipName%.zip -@ < files.txt
del files.txt
