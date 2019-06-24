# Section 1: Week 2: Review Literature Related to Aspect Object Oriented and Functional Programming

## Aspect Oriented Programming

AOP is a design approach for encapsulating `cross cutting` concerns into isolated packages.

These `aspects` appear in scenarios such as logging, authentication/authorization, and related scenarios. Bascially the spaghetti that doesn't quiet fit cleanly in the `is-a` or `has-a` relationship.

### Apect Mining

Aspect mining involves strategies for identifying and extracting redundancies from the code base.

### Aspect Oriented Domain-Specific Languages

Many languages support the notion of aspect injection during compilation or runtime.

This maybe driven by preprocessors which compile a build script into target platform, or metadata programming through annotations.

### Aspectization of Loops

There is often a trade off between code maintainability (seperate classes) and the performance enhancements by looping few times.

A method for having your cake and eating it too, is leverage precompilation hooks to consume mulitple classes and infuse them together.

Then the code is maintable because it is authored as separate classes, but the compiler can optimize the byte code so that it "physically becomes one thing." Afterwards, the logic can loop once and touch numerous disjoined logic in a single pass.

### Aspect Weaving

This is a compile time or runtime strategy to inject commonality so that the originating source code does not redundantly repeat itself.

An example might include annotating every argument with attributes e.g. `void Foo(@NotNull String bar)` and letting the compiler write `if (bar == null) throw ArgNull();`. Later if the checks need to be modified such as including the argument name, it can be centrally modified and global deployed.

## Functional Programming

Functional Programming languages are stateless transforms which take a set of arguments and return a result.

### Evaluation and Feasibility

There are many scenarios where functions are superior to the readability of full blown objects.

### Utility of functional languages for education, research, or professional software development

To say that they are not used in a setting would be to misunderstand their purpose.

Frequently it is cleaner to implement a small number of functions as an expression of an [Internal DSL](../Week3_DomainSpecificLanguages).

They are stateless and sneak into every corner of programming.
 