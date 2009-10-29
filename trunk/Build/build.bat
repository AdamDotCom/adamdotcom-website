@echo off
cls
..\Dependencies\nAnt\bin\NAnt.exe -buildfile:AdamDotCom.Website.build %*
pause
