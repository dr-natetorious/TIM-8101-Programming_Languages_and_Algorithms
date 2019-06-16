# Thesis in 30 seconds

GraphQL allows allows users to interact with numerous protected data stores and back end systems.

A dynamic fuzzer can be constructed which attempts to maximize code coverage in an effort to exploit these systems.

This can be accomplished through steps:

1. Download the published schema
2. Feed the schema into a constraint solver (eg. Z3 or Google OR)
3. Manipulate the query
    - dynamic portions: high probability of injection
    - static portions: low probability of injection
4. For each iteration
    - compute an efficiency score (eg. code coverage)
    - check through instrumentation for parse errors
5. Using a separate optimizer, attempt to maximize the iteration score

