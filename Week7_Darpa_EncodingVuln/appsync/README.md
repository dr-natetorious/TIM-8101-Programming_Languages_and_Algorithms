# Amazon AppSync

AppSync is a serverless GraphQL implementation that is hosted by Amazon.

This [tutorial](https://docs.aws.amazon.com/appsync/latest/devguide/tutorial-local-resolvers.html) can be used to quickly setup a basic example.

Apache has a useful [developer guide](http://velocity.apache.org/engine/devel/developer-guide.html) for how to author these scripts.

Steps:

1. Create and save the schema
2. Create a `None` data source and bind it to new resolver
3. Queries to the method will now run sandboxed [VTL code](http://velocity.apache.org/engine/2.0/vtl-reference.html)

## Example Request

```graphql
mutation {
    page(to: "Nadia", body: "Hello, World!") {
        body
        to
        from
        sentAt
    }
}
```

## Example Response

```graphql
{
  "data": {
    "page": {
      "body": "Hello, World!",
      "to": "com.amazonaws.deepdish.transform.model.MappingTemplateContext@6a950ba3",
      "from": "${context.identity.username}",
      "sentAt": "2019-06-12T06:12:54.348Z"
    }
  }
}
```
