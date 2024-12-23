# ParkService
The ParkService repository is a proof of concept .NET GraphQL service. Together with the following repositories, it's
meant to demonstrate how a Gateway Service can be used along with GraphQL Federation to create a single GraphQL API from
multiple GraphQL microservices:
- [UserService](https://github.com/24dlong/UserService)
- [HikeService](https://github.com/24dlong/HikeService)
- [GatewayService](https://github.com/24dlong/GatewayService)

The ParkService provides a REST API and GraphQL API for managing parks and trails.

## Running the Service
1. Run `make bootstrap` to run the service using Docker
2. An overview of the REST API can be found at http://localhost:5000/swagger/index.html
3. An overview of the GraphQL API and a UI for making requests can be found at http://localhost:5000/graphql/

### Making a GraphQL Request
1. In your browser, open http://localhost:5000/graphql/
1. Click on the 'Operation' tab
1. In the Request pane, paste in the following GQL query:
    ```gql
    query {
      trails {
        id
        name
        park {
          id
          name
        }
        length
      }
    }
    ```
1. Hit the 'Run' button to execute your GraphQL request

Alternatively, you can make a POST request to the /graphql endpoint using your API Client of choice. For more info on 
structuring a GraphQL request, see [Make an HTTP call with GraphQL](
https://learning.postman.com/docs/sending-requests/graphql/graphql-http/).

## Building a Docker Image
1. If you want to build a docker image for the service without running it, you can execute `make build`

## Resources
The following documentation may be helpful when reviewing and understanding key components of this service:
- [ASP.NET Core in a container](https://code.visualstudio.com/docs/containers/quickstart-aspnet-core)
- [Introduction to GraphQL](https://graphql.org/learn/)
- [Hot Chocolate - Introduction](https://chillicream.com/docs/hotchocolate/v13)
    - The .NET GraphQL library used in this service
- [Hot Chocolate - Distributed Schemas](https://chillicream.com/docs/hotchocolate/v13/distributed-schema)
    - An overview of how distributed GraphQL schemas work and different high-level designs
- [Hot Chocolate - Apollo Federation Subgraph Support](
  https://chillicream.com/docs/hotchocolate/v13/api-reference/apollo-federation)
    - An overview of Hot Chocolate with Apollo Federation, a specific GraphQL federation implementation
- [Udemy .NET API Course Code Samples](
  https://github.com/DomTripodi93/DotNetAPICourse/tree/main/4-APIIntermediate/7-DotnetAPI_Repository)
    - Code samples from the .NET API Course from which I copied the general Model/Repository/Controller project structure
      used here