using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}

