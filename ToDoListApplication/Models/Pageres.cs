using Azure;

namespace ToDoListApplication.Models
{
    public class Pageres<T>
    {
        public string SearchDay { get; set; }
        public string SearchMonth { get; set; }
        public string SearchYear { get; set; }
        public Pager<T> Items { get; set; }
    }
}
