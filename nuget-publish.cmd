@cd VerifyArgs
..\.nuget\nuget.exe pack VerifyArgs.csproj -Version 1.0.0.1 -Prop Configuration=Release -OutputDirectory bin
..\.nuget\nuget.exe push bin\VerifyArgs.1.0.0.1.nupkg -ApiKey
@pause
