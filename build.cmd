@SET config=%1
@IF ["%config%"] == [""] (
   SET config=Release
)

@CALL "%~dp0RestorePackages.cmd"

@CALL "%~dp0setmsbuild.cmd"

@echo %msbuild% "%~dp0src\cloudflare.net.sln" /verbosity:m /t:Rebuild /p:Configuration="%config%"
@%msbuild% "%~dp0src\cloudflare.net.sln" /verbosity:m /t:Rebuild /p:Configuration="%config%"
