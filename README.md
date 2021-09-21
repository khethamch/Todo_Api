# Todo_Api

External Installed packages:
1. "Ninject" version="3.3.4"
2. "Ninject.Web.Common" version="3.3.2"
3. "Ninject.Web.Common.WebHost" version="3.3.2"
4. "Ninject.Web.WebApi" version="3.3.1"
5. "Ninject.Web.WebApi.WebHost" version="3.3.1"
6. "Swashbuckle" version="5.6.0"
7. "Swashbuckle.Core" version="5.6.0"

##Please restore these packages via nuget restore in a case they do not appear when this project is cloned.

Todo_Api has 4 endpoints
1. GET /api/todos-get
2. POST /api/todos-post
3. PUT /api/todos/{id}-put
4. DELETE /api/todos/{id}-delete

1. GET /api/todos-get
**Request Url: https://localhost:44333/api/todos-get
** Returns a list of todo objects

2. POST /api/todos-post
**Request Url: https://localhost:44333/api/todos-post
**Body: "test"
** Pass the Name of the todo task in the body to insert the todo

3. PUT /api/todos/{id}-put
**Request Url: https://localhost:44333/api/todos/Y5RLV0-put
**Parameter: id
**Body: {
  "Id": "string",
  "Name": "test2",
  "Completed": true
}
** Pass the Id of the todo and the Todo object to update an existing todo

4. DELETE /api/todos/{id}-delete
**Request Url: https://localhost:44333/api/todos/Y5RLV0-delete
**Parameter: id
** Pass the Id of the todo to delete a todo object

Please use Swagger Docs for a more detailed documentation and for easy testing purposes.
To access Swagger Docs for Todo_Api: https://localhost:44333/swagger/ui/index#/
