@ECHO ON
@ECHO =================================
@ECHO (c) Nate Bachmeier
@ECHO https://github.com/dr-natetorious
@ECHO =================================
@SETLOCAL enableextensions enabledelayedexpansion
@SET base_path=%~dp0
@PUSHD %base_path%

@SET ImageName=natetorious/libgraphql

@CALL docker build -t %ImageName% .
@IF NOT ERRORLEVEL 0 GOTO ERROR
@CALL docker run -it -v %base_path%\src:/src -v %userprofile%\.aws:/root/.aws -w /src/ %ImageName% bash
@IF NOT ERRORLEVEL 0 GOTO ERROR
GOTO END

:ERROR
@ECHO Failed to perform the last step, exiting early.

:END
@POPD