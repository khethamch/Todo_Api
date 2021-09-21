using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Caching;
using Todo_Api.Helper;
using Todo_Api.Models;

namespace Todo_Api.Services
{
    public interface ITodo
    {
        void Add(string name);

        void Update(Todo todo);

        void Delete(string id);

        List<Todo> GetTodos();

        Todo GetTodo(string id);
    }

    public class TodoService : ITodo
    {
        public void Add(string name)
        {
            Todo todo = new Todo();

            todo.Name = name;
            todo.Id = Generate.Key();

            ObjectCache cache = MemoryCache.Default;

            var jsonData = JsonConvert.SerializeObject(todo);

            CacheItemPolicy policy = new CacheItemPolicy();

            cache.Add($"{todo.Id}", jsonData, policy);
        }

        public void Delete(string id)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(id);
        }

        public Todo GetTodo(string id)
        {
            ObjectCache cache = MemoryCache.Default;
            var todoJsonObject = cache.Get(id).ToString();

            var todo = JsonConvert.DeserializeObject<Todo>(todoJsonObject);

            return todo;
        }

        public List<Todo> GetTodos()
        {
            List<Todo> todos = new List<Todo>();

            foreach (var item in MemoryCache.Default)
            {
                var todo = GetTodo(item.Key);
                todos.Add(todo);
            }

            return todos;
        }

        public void Update(Todo todo)
        {
            ObjectCache cache = MemoryCache.Default;

            var jsonData = JsonConvert.SerializeObject(todo);

            CacheItemPolicy policy = new CacheItemPolicy();

            cache.Set($"{todo.Id}", jsonData, policy);
        }
    }
}