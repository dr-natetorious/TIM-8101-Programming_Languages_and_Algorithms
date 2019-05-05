# Section 1: Week 1: Lexical Parsing

The primary [Assignment](Assignment.md) dealt with [building](src/natetorio.us) a simple language called [NCU/PL](src/LDK/NCUPL-grammar.pdf).

A NCU/PL script is provided inline [other examples](src/LDK/test-programs) are provided with the LDK:

```bash
# Start the string with multi-token keyword
BEGIN NCUPL

  # Declare some variables for the script
  string name;
  int age;

  # Get the values from the user
  INPUT "Enter your name:" name;
  INPUT "Enter your age:" name;

  # Check if they are old enough for beer...
  IF (age < 21) THEN
    OUTPUT "Hello " + name + ", no beer for you for you";

  # Suggest coffee is better anyways...
  IF age > 21 THEN OUTPUT "Coffee probably makes the wife happier";

# Conclude the script
END
```

## How does it work

There were two iterations to creating the language lexer:

1. [NCU_PL.jj](src/natetorio.us/NCU_PL.jj): Writing javacc template by hand
2. [NCU_PL.jjt](src/natetorio.us/NCU_PL.jjt): Using jjtree to generate javacc template

JavaCC templates specify tokens as RegEx patterns and then sequences of these tokens can be declared.

JavaTree will instrument a JavaCC template to make extraction of an Abstract Syntax Tree (AST) easier.

## What does the AST look like

The [NCU_PL_Lexer_Driver](src/natetorio.us/NCU_PL_Lexer_Driver.java) uses the code generated from JavaCC to walk the input file. 

This structure could then be passed to a parser to convert it into a machine code or perform other actions.

```text
Beginning lexical analysis of file "../../../LDK/tests-programs/can-have-beer.ncucpl"
>> ProgramNode
>>  VarDeclarationStatement
>>   TypeName
>>    String
>>   Name
>>  VarDeclarationStatement
>>   TypeName
>>    Int
>>   Name
>>  InputStatement
>>   Literal
>>    StrLiteral
>>  InputStatement
>>   Literal
>>    StrLiteral
>>  LPAREN
>>  Literal
>>   Id
>>    Name
>>  BinaryOp
>>  Literal
>>   IntLiteral
>>  RPARAN
>>  OutputStatement
>>   Literal
>>    StrLiteral
>>   BinaryOp
>>   Literal
>>    Id
>>     Name
>>   BinaryOp
>>   Literal
>>    StrLiteral
>>  Literal
>>   Id
>>    Name
>>  BinaryOp
>>  Literal
>>   IntLiteral
>>  OutputStatement
>>   Literal
>>    StrLiteral
```
