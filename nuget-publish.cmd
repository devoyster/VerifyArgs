rmdir bin /S /Q
mkdir bin
xcopy VerifyArgs\bin\*.dll bin\lib\net40\
xcopy VerifyArgs\bin\*.xml bin\lib\net40\
xcopy VerifyArgs.Silverlight\bin\*.dll bin\lib\sl40\
xcopy VerifyArgs.Silverlight\bin\*.xml bin\lib\sl40\
xcopy license.txt bin\lib\ /Y
xcopy VerifyArgs.nuspec bin\ /Y

cd bin
..\.nuget\nuget.exe pack VerifyArgs.nuspec
..\.nuget\nuget.exe push VerifyArgs.1.0.2.0.nupkg -ApiKey

@pause
