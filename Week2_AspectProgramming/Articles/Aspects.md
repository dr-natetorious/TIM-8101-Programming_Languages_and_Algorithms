# Articles related to Aspect Oriented Programming

## What is AOP

In [Aspect-Oriented Programming](AOP.pdf)(1997) and [A Theory of Aspects](aspects-theory.pdf)(2003) the authors (cryptically) explain what is aspect programming.

**Cross Cutting Concern**: A concern is something the program does (eg. sort a file, display an image). A cross cutting concern is something the program does in many places (eg. logs state, caches an object). These cross cutting concerns become expensive to maintain as they are not well encapuslated and are spaghetti through the code base.

**Joinpoint**: A joinpoint is a candidate point in the Program Execution of the application where an aspect can be plugged in. This point could be a method being called, an exception being thrown, or even a field being modified. These are the points where your aspect’s code can be inserted into the normal flow of your application to add new behavior.

**Advice**: This is an object which includes API invocations to the system wide concerns representing the action to perform at a joinpoint specified by a point.

**Pointcut**: A pointcut defines at what joinpoints, the associated Advice should be applied. Advice can be applied at any joinpoint supported by the AOP framework. Of course, you don’t want to apply all of your aspects at all of the possible joinpoints. Pointcuts allow you to specify where you want your advice to be applied. Often you specify these pointcuts using explicit class and method names or through regular expressions that define matching class and method name patterns. Some AOP frameworks allow you to create dynamic pointcuts that determine whether to apply advice based on runtime decisions, such as the value of method parameters.

JoinPoint definitions copied from [StackOverflow](https://stackoverflow.com/questions/15447397/spring-aop-whats-the-difference-between-joinpoint-and-pointcut)/

## Use cases of AOP

In [Automating ETL processes using the domain-specific modeling approach](Automated_ETL_via_AOP.pdf)(2016) the authors decribe creating an Domain Specific Modeling (DSM) Language for ETL operations. The DSM allows for the creation of generic ETL transforms (aspects) which can be bound to visual work flows.

## Aspect Mining

Aspect mining attempts to find the common cross cutting concerns from legacy systems. One approach is to use [CallTree Mining](CallTree_AspectMining.pdf)(2007) which:

1. Extracts the call tree from the application
2. Creates a transition matrix (eg. calling A() leads to  B())
3. Use the matrix to identify cross cutting concerns

Their approach 