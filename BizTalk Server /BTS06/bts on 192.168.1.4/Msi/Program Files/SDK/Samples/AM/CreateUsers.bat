@echo off

echo Creating user "Susan" with password "pass@word1"...
net user Susan pass@word1 /add
if errorlevel 1 goto errorhandler

echo Creating user "John" with password "pass@word1"...
net user John pass@word1 /add
if errorlevel 1 goto errorhandler

echo Creating user "Mary" with password "pass@word1"...
net user Mary pass@word1 /add
if errorlevel 1 goto errorhandler

echo The operation completed successfully.
goto end

:errorhandler
echo The operation failed.

:end
pause
