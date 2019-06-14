# Section 3: Week 7: Develop a Research Proposal

This week focuses on the development of a research proposal for a DARPA grant.

The research topic is security research into GraphQL (GQL), a public facing data query/manipulation language (DQL/DML).

## Table of Contents

- [Readings](Readings.md) - Bibliography of independent readings for the week.

- [Assignment](Assignment.md) - Requirements of this weeks research material.

- [Plan](Plan.md) - Note while planning the research topic / details that don't really fit anywhere else.

## Thesis in 30 seconds

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

## Alternative Plan

How do you build evolutationary software that does not have the maintainability costs?

https://www.darpa.mil/news-events/2015-04-08

Recent awards for complexity research

https://www.darpa.mil/news-events/2017-09-07

The Information Innovation Office (I2O) appears to be the most relevant to my field.

https://www.darpa.mil/about-us/offices/i2o