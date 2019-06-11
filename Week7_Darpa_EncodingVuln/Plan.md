# Evolving Plan for the Paper

SQLi has been beaten to death, so we need to bubble it one level higher -- graphql.

The idea is to describe a series of test operations which can potentially lead to encoding vulnerabilities (eg. sqli or xss).

My initial proposed model is:

1. Fetch the schema
2. Use contraint programming to mark sections of the schema static/dynamic
3. For the dynamic content inject a series of malformed encoding attacks
4. Instrument the resolve -> data store operation, such that parse errors are discoverable
5. Measure the code coverage of the operation
6. Feed the score (# lines covered) into a separate optimization solver which attempts to maximize distance
7. Loop infinitely until bugs are no longer found

This is high level strategy and will obviously need refinement.

## Possible Refinement Areas

1. The dynamic content could be hitting numerous data store designs, or DML transforms.
2. How do we prevent finding the same defect multiple times
3. Is code coverage the optimial metic, if so what code are we measuring? graphql could touch multiple systems.
4. What existing REST style attacks exist here

## Proposed paper titles

1. Smashing the front door for phun or profit
2. Banging the front door
