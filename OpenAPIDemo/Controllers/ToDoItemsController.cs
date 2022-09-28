using OpenAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace OpenAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        internal List<ToDoItem> _items = new List<ToDoItem>();
        public ToDoItemsController() {
            _items.Add(new ToDoItem() { Description = "Item 1", IsCompleted = false });
            _items.Add(new ToDoItem() { Description = "Item 2", IsCompleted = false });
            _items.Add(new ToDoItem() { Description = "Item 3", IsCompleted = false });
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return _items;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ToDoItem Get(string id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(ToDoItem toDoItem)
        {
            _items.Add(toDoItem);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] ToDoItem toDoItem)
        {
            ToDoItem itemToUpdate = _items.First(i => i.Id == id);
            if (itemToUpdate != null) {
                itemToUpdate.IsCompleted = toDoItem.IsCompleted;
                itemToUpdate.Description = toDoItem.Description;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ToDoItem itemToRemove = _items.First(i => i.Id == id);
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
        }
    }
}