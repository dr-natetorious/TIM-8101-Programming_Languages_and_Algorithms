@ECHO ON
@SETLOCAL enableextensions enabledelayedexpansion
@SET base_path=%~dp0
@PUSHD %base_path%

@SET ImageName=ncu/javacc

@CALL docker build -t %ImageName% .
@IF NOT ERRORLEVEL 0 GOTO ERROR
@CALL docker run -it -v %base_path%\src:/src -v %userprofile%\.aws:/root/.aws -w /src/natetorio.us -p 5005:5005 %ImageName% bash
@IF NOT ERRORLEVEL 0 GOTO ERROR
GOTO END

:ERROR
@ECHO Failed to perform the last step, exiting early.

:END
@POPD