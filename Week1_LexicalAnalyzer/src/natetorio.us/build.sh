#!/bin/bash
# =================================================
# Nate Bachmeier
# TIM-8110: Programming Languages and Algorithms
# NorthCentral Univesity
# (c) 2019.05.05
# =================================================
OUTPUT_DIRECTORY=/src/out/

function build_jj(){
  name=$1
  java javacc -OUTPUT_DIRECTORY=${OUTPUT_DIRECTORY}/${name} "${name}.jj"
  javac ${OUTPUT_DIRECTORY}/${name}/*.java
  jar cf ${OUTPUT_DIRECTORY}/${name}.jar ${OUTPUT_DIRECTORY}/${name}/*.class
}

function build_jjt(){
  name=$1
  jjt_out=${OUTPUT_DIRECTORY}/tree/${name}
  java jjtree -OUTPUT_DIRECTORY=${jjt_out} "${name}.jjt"

  java javacc -OUTPUT_DIRECTORY=${jjt_out} "${jjt_out}/NCU_PL.jj"

  cp NCU_PL_Lexer_Driver.java ${jjt_out}
  #cp MyVisitor.java ${jjt_out}
  javac ${jjt_out}/*.java
  jar cf ${OUTPUT_DIRECTORY}/${name}.tree.jar ${jjt_out}/*.class 
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

function do_jj_section(){
  header "Build the .jj files"
  build_jj HelloWorld
  build_jj MoreStatements
  build_jj NCU_PL

  header "Bulid the Lexer Driver"
  javac -d ${OUTPUT_DIRECTORY}/NCU_PL -cp ../out/NCU_PL/  NCU_PL_Lexer_Driver.java

  header "Unit test scripts"
  pushd ${OUTPUT_DIRECTORY}/NCU_PL 
  test_file ../../LDK/tests-programs/output-repro.ncupl
  test_file ../../LDK/tests-programs/hello-world.ncupl
  test_file ../../LDK/tests-programs/budget-calculator.ncupl
  test_file ../../LDK/tests-programs/age-calculator.ncupl
  test_file ../../LDK/tests-programs/can-have-beer.ncucpl
  popd
}

function do_jjt_section(){
  header "Build the .jjt files"
  build_jjt NCU_PL
  pushd ${OUTPUT_DIRECTORY}/tree/NCU_PL 
  test_file ../../../LDK/tests-programs/hello-world.ncupl
  test_file ../../../LDK/tests-programs/output-repro.ncupl
  test_file ../../../LDK/tests-programs/budget-calculator.ncupl
  test_file ../../../LDK/tests-programs/age-calculator.ncupl
  test_file ../../../LDK/tests-programs/for-loop.ncupl
  test_file ../../../LDK/tests-programs/can-have-beer.ncucpl
  popd
}

#do_jj_section
do_jjt_section 