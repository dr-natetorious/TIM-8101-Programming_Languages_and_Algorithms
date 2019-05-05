#!/bin/bash

OUTPUT_DIRECTORY=/src/out/

function build_jj(){
  name=$1
  java javacc -OUTPUT_DIRECTORY=${OUTPUT_DIRECTORY}/${name} "${name}.jj"
  javac ${OUTPUT_DIRECTORY}/${name}/*.java
  jar cvf ${OUTPUT_DIRECTORY}/${name}.jar ${OUTPUT_DIRECTORY}/${name}/*.class
}

function header(){
  echo "====================="
  echo "$*"
  echo "====================="
  echo
}

function test_file(){
  filename=$1
  java NCU_PL_Lexer_Driver $filename > `basename $filename.log`

  if [ $? -eq 0 ]; then
    echo "test: pass: $filename"
  else
    echo "test: fail: $filename"
  fi
}

header "Build the .jj files"
#build_jj HelloWorld
#build_jj MoreStatements
build_jj NCU_PL

header "Bulid the Lexer Driver"
javac -d ${OUTPUT_DIRECTORY}/NCU_PL -cp ../out/NCU_PL/  NCU_PL_Lexer_Driver.java

header "Unit test scripts"
pushd ${OUTPUT_DIRECTORY}/NCU_PL 

test_file ../../LDK/tests-programs/output-repro.ncupl
test_file ../../LDK/tests-programs/hello-world.ncupl
test_file ../../LDK/tests-programs/budget-calculator.ncupl
test_file ../../LDK/tests-programs/age-calculator.ncupl
test_file ../../LDK/tests-programs/can-have-beer.ncupl

popd