namespace OpenAPIDemo.Models
{
    public class ToDoItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public string LinkUrl
        {
            get { 
                    return "https://openapidemo.azurewebsites.net/api/todoitems/" + Id;
            }
            private set{}
        }

        public ToDoItem()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}