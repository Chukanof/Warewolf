REM ********************************************************************************************************************
REM * Hi-Jack the Auto Build Variables by QtAgent since this is injected after it has REM * setup
REM * Open the autogenerated qtREM * setup in the test run location of
REM * C:\Users\IntegrationTester\AppData\Local\VSEQT\QTAgent\...
REM * For example:
REM * set DeploymentDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\DEPLOY~1
REM * set TestRunDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1
REM * set TestRunResultsDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results\RSAKLF~1
REM * set TotalAgents=5
REM * set AgentWeighting=100
REM * set AgentLoadDistributor=Microsoft.VisualStudio.TestTools.Execution.AgentLoadDistributor
REM * set AgentId=1
REM * set TestDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1
REM * set ResultsDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results
REM * set DataCollectionEnvironmentContext=Microsoft.VisualStudio.TestTools.Execution.DataCollectionEnvironmentContext
REM * set TestLogsDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results\RSAKLF~1
REM * set ControllerName=rsaklfsvrtfsbld:6901
REM * set TestDeploymentDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\DEPLOY~1
REM * set AgentName=RSAKLFTST7X64-3
REM ********************************************************************************************************************

REM ** Check for admin **
@echo off
echo Administrative permissions required. Detecting permissions...
REM using the "net session" command to detect admin, it requires elevation in the most operating systems - Ashley
IF EXIST %windir%\nircmd.exe (nircmd elevate net session >nul 2>&1) else (net session >nul 2>&1)
if %errorLevel% == 0 (
	echo Success: Administrative permissions confirmed.
) else (
	echo Failure: Current permissions inadequate.
	exit 1
)
@echo on

REM ** Cleanup **
call "%~dp0Cleanup.bat"

:StopRetryingClean

REM Init paths to Warewolf server under test
IF EXIST "%DeploymentDirectory%\DebugServer.zip" powershell.exe -nologo -noprofile -command "& { Expand-Archive '%DeploymentDirectory%\DebugServer.zip' '%DeploymentDirectory%\Server' -Force }"
IF EXIST "%DeploymentDirectory%\DebugStudio.zip" powershell.exe -nologo -noprofile -command "& { Expand-Archive '%DeploymentDirectory%\DebugStudio.zip' '%DeploymentDirectory%\Studio' -Force }"
IF "%DeploymentDirectory%"=="" IF EXIST "%~dp0..\..\Dev2.Server\bin\Debug\Warewolf Server.exe" SET DeploymentDirectory=%~dp0..\..\Dev2.Server\bin\Debug
IF "%DeploymentDirectory%"=="" IF EXIST "%~dp0Server\Warewolf Server.exe" SET DeploymentDirectory=%~dp0Server
IF "%DeploymentDirectory%"=="" IF EXIST "%~dp0..\Server\Warewolf Server.exe" SET DeploymentDirectory=%~dp0..\Server
IF "%DeploymentDirectory%"=="" IF EXIST "%~dp0..\DebugServer\Warewolf Server.exe" SET DeploymentDirectory=%~dp0..\DebugServer
IF EXIST "%DeploymentDirectory%\Server\Warewolf Server.exe" SET DeploymentDirectory=%DeploymentDirectory%\Server

REM ** Try Refresh Warewolf Server Bin Resources and Tests
IF EXIST "%~dp0..\..\Resources - Debug\Resources" "%~dp0..\..\Resources - Debug\Resources" echo d | xcopy /S /Y "%~dp0..\..\Resources - Debug\Resources" "%DeploymentDirectory%\Resources"
IF EXIST "%~dp0..\..\Resources - Debug\Tests" echo d | xcopy /S /Y "%~dp0..\..\Resources - Debug\Tests" "%DeploymentDirectory%\Tests"

REM ** Try Refresh Warewolf ProgramData Resources and Tests
IF NOT EXIST "%ProgramData%\Warewolf\Resources" IF EXIST "%DeploymentDirectory%\Resources" echo d | xcopy /S /Y "%DeploymentDirectory%\Resources" "%ProgramData%\Warewolf\Resources"
IF NOT EXIST "%ProgramData%\Warewolf\Tests" IF EXIST "%DeploymentDirectory%\Tests" echo d | xcopy /S /Y "%DeploymentDirectory%\Tests" "%ProgramData%\Warewolf\Tests"

REM ** Start Warewolf server from deployed binaries **
IF EXIST "%DeploymentDirectory%\ServerStarted" DEL "%DeploymentDirectory%\ServerStarted"
IF EXIST %windir%\nircmd.exe (nircmd elevate "%DeploymentDirectory%\Warewolf Server.exe") else (START "%DeploymentDirectory%\Warewolf Server.exe" /D "%DeploymentDirectory%" "Warewolf Server.exe")
@echo Started "%DeploymentDirectory%\Warewolf Server.exe".

REM ** Wait for server start
@echo off
:WaitForServerStart
set /a LoopCounter=0
:MainLoopBody
IF EXIST "%DeploymentDirectory%\ServerStarted" goto StartStudio
set /a LoopCounter=LoopCounter+1
IF %LoopCounter% EQU 30 echo Timed out waiting for the Warewolf server to start. &exit /b
@echo Waiting 10 more seconds for %DeploymentDirectory%\ServerStarted file to appear...
waitfor ServerStart /t 10 2>NUL
goto MainLoopBody

:StartStudio
REM Try use Default Workspace Layout
IF EXIST "%DeploymentDirectory%\DefaultWorkspaceLayout.xml" COPY /Y "%DeploymentDirectory%\DefaultWorkspaceLayout.xml" "%LocalAppData%\Warewolf\UserInterfaceLayouts\WorkspaceLayout.xml"
IF EXIST "%DeploymentDirectory%\..\DefaultWorkspaceLayout.xml" COPY /Y "%DeploymentDirectory%\..\DefaultWorkspaceLayout.xml" "%LocalAppData%\Warewolf\UserInterfaceLayouts\WorkspaceLayout.xml"
IF EXIST "%~dp0..\..\Warewolf.UITests\Properties\DefaultWorkspaceLayout.xml" COPY /Y "%~dp0..\..\Warewolf.UITests\Properties\DefaultWorkspaceLayout.xml" "%LocalAppData%\Warewolf\UserInterfaceLayouts\WorkspaceLayout.xml"
REM Init paths to Warewolf studio under test
IF NOT EXIST "%DeploymentDirectory%\..\Studio\Warewolf Studio.exe" IF EXIST "%~dp0..\..\Dev2.Studio\bin\Debug\Warewolf Studio.exe" SET DeploymentDirectory=%~dp0..\..\Dev2.Studio\bin\Debug
IF EXIST "%DeploymentDirectory%\..\Studio\Warewolf Studio.exe" SET DeploymentDirectory=%DeploymentDirectory%\..\Studio
IF EXIST "%DeploymentDirectory%\..\DebugStudio\Warewolf Studio.exe" SET DeploymentDirectory=%DeploymentDirectory%\..\DebugStudio

REM ** Start Warewolf studio from deployed binaries **
@echo on
IF EXIST %windir%\nircmd.exe (nircmd elevate "%DeploymentDirectory%\Warewolf Studio.exe") else (START "%DeploymentDirectory%\Warewolf Studio.exe" /D "%DeploymentDirectory%" "Warewolf Studio.exe")
@echo Started "%DeploymentDirectory%\Warewolf Studio.exe".

exit 0
