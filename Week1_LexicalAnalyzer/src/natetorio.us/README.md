# Building the Lexer

The course provided an initial [LDK](../LDK) and the customizable parts were copied into this folder.

1. Start the [devenv.bat](../../devenv.bat) or run the [Dockerfile](../../Dockerfile).

2. This directly will be mapped to `/src/natetorio.us` and set the working directory

3. Invoking [build.sh](build.sh) will build and execute all tests

4. The output of all steps will be `/src/out/` with `/src/out/tree/NCU_PL` the most interesting

## Understanding the Build Script

The script started out as a scratch pad and became *slightly* more formalized across the assignment. With functions:

- build_jj       : Build the a .jj file
- build_jjt      : Build the a .jjt file
- test_file      : Test a single `.ncupl` script again one of the lexer outputs (based on `pwd`)
- do_jj_section  : Build and Test all code based on jj files  (iteration 1)
- do_jjt_section : Build and Test all code based on jjt files (iteration 2)

## Adding more commands

Review [this commit](https://github.com/dr-natetorious/TIM-8110-Programming_Languages_and_Algorithms/commit/8f9a3d19dc6f17982d2a0edaaf10f306f354214e) as an example of adding the `FOR` command.