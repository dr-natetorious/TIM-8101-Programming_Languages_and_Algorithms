# Section 1: Week 3: Domain Specific Languages

A Domain Specific Language is one of the core tools available for Language Oriented Design.

## Internal DSL

A DSL does not need to be implemented as a separate thing off on the side. Often they can be embedded within another language.

This reduces the ability to customize the syntax but reduces the effort to implement them.

An example might include creating various SQL functions and stored procedures that encapsulate a domain. This improves the readability and enhances the developer experience.

Consider this example which is self-documenting and is instantly the intent.

```sql
SELECT students.*
FROM Schools(state: 'WA') school
    INNER JOIN Students(min_grade: '3', max_grade:5) student
    ON  school.id = student.school_id
;
```

## External DSL

There are cases when the problem demands very specific syntax or custom operators.

A clear example of this can be seen with [Neo4j's Cypher](https://neo4j.com/docs/cypher-manual/current/), a graph query language.

Many custom DSL languages are implemented with JavaCC as discussed during [Week1_LexicalAnalyzer](../Week1_LexicalAnalyzer).

```sql
MATCH (user)-[:friend]->(follower)
WHERE user.name IN ['Joe', 'John', 'Sara', 'Maria', 'Steve'] AND follower.name =~ 'S.*'
RETURN user.name, follower.name

+---------------------------+
| user.name | follower.name |
+---------------------------+
| "Joe"     | "Steve"       |
| "John"    | "Sara"        |
+---------------------------+
```
