@cd VerifyArgs
..\.nuget\nuget.exe pack VerifyArgs.csproj -Prop Configuration=Release -OutputDirectory bin
..\.nuget\nuget.exe push bin\VerifyArgs.1.0.1.0.nupkg -ApiKey
@pause
