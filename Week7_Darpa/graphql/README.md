# Independent Readings

## GraphQL and Security

In [this blog post](https://mikewilliamson.wordpress.com/2016/09/15/graphql-and-security/) Williamson describes how SQLi has continued to be a hot topic, but there is light investigation into GraphQL.

GQL provides a DSL language which can be used to call numerous services through resolvers and converge those results in a user defined structure.

## Implementing GraphQL with Apollo

This [blog post](https://scotch.io/tutorials/implementing-graphql-using-apollo-on-an-express-server) describes the core aspects of the graphql DQL/DML using Apollo.

Apollo is the 'big name' in open source node implementations and commonly used by industry implementations.

## GraphQL Spec

The official DSL specification is defined [on github](https://github.com/graphql/graphql-spec).

It describes the language requirements and optional implementation features.

## C++ Fuzzing Libraries

This [blog post](http://jefftrull.github.io/c++/clang/llvm/fuzzing/sanitizer/2015/11/27/fuzzing-with-sanitizers.html) describes `libFuzzer` and `AFL`.

These are commonly referenced tools for mutating strings in an effort to trigger vulnerabilities.

## LibGraphQLParser

Facebook [provides an official](https://github.com/graphql/libgraphqlparser) C++ parser for extracting the AST from a GraphQL query.

A [local build environment](libgraphqlparser) is provided for building utilities against this library.

## Fetching GraphQL Schema

There is a graphql cli that can be used to fetch data from an endpoint.

This [stackflow post](https://stackoverflow.com/questions/37397886/get-graphql-whole-schema-query) details the setup.
