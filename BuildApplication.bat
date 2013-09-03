@echo off
@echo.
@echo ========================================================
@echo.
@echo		Building and add MembershipAndRolesUtilitie
@echo.
@echo ========================================================
msbuild ConsoleApplication1\MembershipAndRolesUtils.csproj /target:BuildAndDeploy
@echo on
