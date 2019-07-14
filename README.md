# PlaceholderAPI is a template for a REST API project based on .NET Core WebAPI

  It represents two controllers for proxying requests to https://jsonplaceholder.typicode.com/.
  It features IHttpClientFactory generated-clients pattern with the help of Refit library.
  API documentation is generated with Swagger. 
  Endpoints allows  Content Negotiation based on Accept header of the request.

## Basic Usage

    Configure PlaceholderAPI.BaseUri in appsettings.json. https://jsonplaceholder.typicode.com/ is default.
	Address swagger docs for info about API usage. 