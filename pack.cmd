@SET config=%1
@IF ["%config%"] == [""] (
   SET config=Release
)

@call "%~dp0build.cmd" %config%

@echo "%~dp0src\.nuget\NuGet.exe" pack "%~dp0src\CloudFlare.NET\CloudFlare.NET.csproj" -Properties Configuration=%config% -NonInteractive -Symbols -OutputDirectory "%~dp0src\CloudFlare.NET\bin\%config%"
@"%~dp0src\.nuget\NuGet.exe" pack "%~dp0src\CloudFlare.NET\CloudFlare.NET.csproj" -Properties Configuration=%config% -NonInteractive -Symbols -OutputDirectory "%~dp0src\CloudFlare.NET\bin\%config%"
