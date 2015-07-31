@SETLOCAL
@SET config=%1
@IF ["%config%"] == [""] (
   SET config=Release
)

@FOR /r %%F IN (*OpenCover.Console.exe) DO @SET cover_exe=%%F
@IF NOT EXIST "%cover_exe%" (
   echo Unable to find OpenCover console.
   EXIT /B 2
)
::@echo %cover_exe%

@FOR /r %%F IN (*ReportGenerator.exe) DO @SET report_exe=%%F
@IF NOT EXIST "%report_exe%" (
   echo Unable to find ReportGenerator.
   EXIT /B 2
)
::@echo %report_exe%

@FOR /r %%F IN (*mspec-clr4.exe) DO @SET mspec_exe=%%F
@IF NOT EXIST "%mspec_exe%" (
   echo Unable to find MSpec console runner.
   EXIT /B 2
)
::@echo %mspec_exe%

@FOR /r %%F IN (*xunit.console.exe) DO @SET xunit_exe=%%F
@IF NOT EXIST "%xunit_exe%" (
   echo Unable to find MSpec console runner.
   EXIT /B 2
)
::@echo %xunit_exe%

@SET test_assemblies=%~dp0src\Tests\CloudFlare.NET.Tests\bin\%config%\CloudFlare.NET.Tests.dll
@SET spec_results=%~dp0src\TestResults\Specifications.html
@SET xunit_results=%~dp0src\TestResults\Xunit.Tests.html
@SET coverage_filter=+[CloudFlare.NET]*
@SET coverage_results=%~dp0src\TestResults\Test.Coverage.xml

@IF NOT EXIST "%~dp0src\TestResults" MD "%~dp0src\TestResults"
::@echo "%mspec_exe%" "%test_assemblies%" --html "%spec_results%"
::@"%mspec_exe%" "%test_assemblies%" --html "%spec_results%"
::@echo "%xunit_exe%" "%test_assemblies%" -noshadow -html "%xunit_results%"
::@"%xunit_exe%" "%test_assemblies%" -noshadow -html "%xunit_results%"

@echo "%cover_exe%" -register:user "-target:%mspec_exe%" "-targetargs:%test_assemblies% --html %spec_results%" -filter:%coverage_filter% "-output:%coverage_results%"
@"%cover_exe%" -register:user "-target:%mspec_exe%" "-targetargs:%test_assemblies% --html %spec_results%" -filter:%coverage_filter% "-output:%coverage_results%"

@echo "%cover_exe%" -register:user "-target:%xunit_exe%" "-targetargs:%test_assemblies% -noshadow -html %xunit_results%" -mergeoutput -filter:%coverage_filter% "-output:%coverage_results%"
@"%cover_exe%" -register:user "-target:%xunit_exe%" "-targetargs:%test_assemblies% -noshadow -html %xunit_results%" -mergeoutput -filter:%coverage_filter% "-output:%coverage_results%"

@echo "%report_exe%" -verbosity:Error "-reports:%coverage_results%" "-targetdir:%~dp0src\TestResults" -reporttypes:XmlSummary
@"%report_exe%" -verbosity:Error "-reports:%coverage_results%" "-targetdir:%~dp0src\TestResults" -reporttypes:XmlSummary

@echo "%report_exe%" -verbosity:Error "-reports:%coverage_results%" "-targetdir:%~dp0src\TestResults\Report" -reporttypes:Html
@"%report_exe%" -verbosity:Error "-reports:%coverage_results%" "-targetdir:%~dp0src\TestResults\Report" -reporttypes:Html
