@echo off
if not exist update-tmp.bat goto runtmp

if exist double-d.rar del double-d.rar
if exist depdot.rar del depdot.rar
wget http://davenicoll.com/updates/double-d.rar
unrar e -o+ -inul double-d.rar *.* %ProgramFiles%\DepDot
goto cleanup

:runtmp
copy update.bat update-tmp.bat
update-tmp.bat
goto end

:cleanup
echo Update complete :)
echo.
echo The next error message can safely be ignored...
if exist update-tmp.bat del update-tmp.bat

:end