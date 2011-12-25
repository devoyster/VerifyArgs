@cd VerifyArgs
..\.nuget\nuget.exe pack VerifyArgs.csproj -Prop Configuration=Release
..\.nuget\nuget.exe push VerifyArgs.1.0.0.0.nupkg -ApiKey
@pause
