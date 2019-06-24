# Section 2: Week 5: Implement an Algorithm

The operating system's file system is responsible for persisting bytes streams to disk and retrieving it at a later point. While this in a simple concept its actual implementation is foreign to me.

File Allocation Tables (FAT) are an ideal starting point as:

1. it shares many design patterns of modern file systems
2. does this without all the bells and whistles

Afterwards, a transparent compression feature was added to the implementation, based on Huffman Compression.

## Table of Contents

- [Algorithm Source Code](fat32/Fat32Algo) - The code for this week's project.
- [Fat32 Algorithm Paper](Week5.docx) - Essay covering this week's requirements.
- [Articles](Articles) - Readings and learnings from the week.
- [Z3 Solver](z3) - Additional Research into using Microsoft's Z3 solver.
