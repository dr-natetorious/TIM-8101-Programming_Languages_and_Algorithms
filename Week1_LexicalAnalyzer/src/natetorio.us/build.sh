#!/bin/bash

OUTPUT_DIRECTORY=/src/out/

function build_jj(){
  name=$1
  java javacc -OUTPUT_DIRECTORY=${OUTPUT_DIRECTORY}/${name} "${name}.jj"
  javac ${OUTPUT_DIRECTORY}/${name}/*.java
  jar cvf ${name}.jar ${OUTPUT_DIRECTORY}/${name}/*.class
}

build_jj HelloWorld
build_jj MoreStatements
build_jj NCU_PL
