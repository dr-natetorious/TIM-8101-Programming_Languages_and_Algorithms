# Finish a Lexical Analyzer for a Simple Procedural Programming Language

## Instructions

Parsing is one of the critical tasks a computer can perform. It allows computer scientists to process user input, compile computer code, and a whole lot more. When creating a new programming language, two critical components of the language are its grammar and syntax specification and the compiler that will actually turn it into runnable code.

One of the most fun and interesting ways of learning about languages and their structure is to actually implement a language or associated tools. The Java Compiler Compiler (JavaCC) is a program and accompanying language for implementing lexical analyzers, interpreters, and code compilers written in Java. In this exercise, you will use JavaCC to complete a lexical analyzer for a new procedural programming language called the “Northcentral University Programming Language” (NCU/PL).

NCU/PL contains the following basic operations: variable declaration, variable assignment, input, output, if/then statements, and binary arithmetic/comparison. It does not contain loops.

There are three data types in NCU/PL: 32-bit integers (“int”), strings of 16-bit Unicode characters (“string”), and Boolean (“bool”).

Part of the lexical analyzer has already been implemented for you as an example. To finish the lexical analyzer, complete the following tasks:

1. Download the NCU/PL language development kit (LDK).
The BNF grammar for NCU/PL is located in “/NCUPL Grammar.pdf.”
The lexer has been started for you inside “/lexer/NCU_PL.jj.”

2. Modify “/lexer/NCU_PL.jj” so that it will recognize and validate all valid NCU/PL programs.

3. Generate the source code for your lexer using javacc:
java –cp javacc.jar javacc NCU_PL.jj

4. Compile the resulting Java code and the Lexer driver (“NCU_PL_Lexer_Driver.java”) using the javac command.

5. Run the lexer against the test NCU/PL programs provided in folder “/Test Programs 1”:
java NCU_PL_Lexer_Driver test-program.ncupl
Debug and revise your JavaCC file as necessary until the lexer driver properly validates all of the provided test programs.

Note: You may use the Eclipse IDE for this project, but it will probably be easier if you just use the command-line compiler. It’s up to you.

In a Word document, answer the following questions:

1. What does the lexer do? What does it not do?
2. Does the lexer check for semantic correctness?
3. Does the lexer check for logical correctness?
4. Modify the BNF grammar for NCU/PL to permit the use of FOR loops.