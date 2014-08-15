@echo off
@echo.
@echo ========================================================
@echo.
@echo		Building and add MembershipAndRolesUtilitie
@echo.
@echo ========================================================
msbuild mru\MembershipAndRolesUtils.csproj /target:BuildAndDeploy
@echo on
