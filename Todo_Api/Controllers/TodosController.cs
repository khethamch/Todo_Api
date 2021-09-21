using System;
using System.Web.Http;
using Todo_Api.Models;
using Todo_Api.Services;

namespace Todo_Api.Controllers
{
    [RoutePrefix("api")]
    public class TodosController : ApiController
    {
        private readonly ITodo _todo;
        public TodosController()
        { }
        public TodosController(ITodo todo)
        {
            _todo = todo;
        }

        [HttpGet]
        [Route("todos-get")]
        public IHttpActionResult GetTodos()
        {
            try
            {
                var todos = _todo.GetTodos();
                return Ok(todos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("todos-post")]
        public IHttpActionResult AddTodo([FromBody] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("The name parameter is required.");
                }

                _todo.Add(name);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("todos/{id}-put")]
        public IHttpActionResult UpdateTodo([FromUri] string id, [FromBody] Todo todo)
        {
            try
            {
                todo.Id = id;
                _todo.Update(todo);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("todos/{id}-delete")]
        public IHttpActionResult DeleteTodo([FromUri] string id)
        {
            try
            {
                _todo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
