using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindsorMvcDemo.Models
{
    public class ToDo
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }

    public interface ToDoListService
    {
        IEnumerable<ToDo> GetToDoList();
    }

    public class ToDoListServiceImpl : ToDoListService
    {
        public IEnumerable<ToDo> GetToDoList()
        {
            return new List<ToDo>
            {
                new ToDo
                {
                    Title = "Meeting with client",
                    Comment = "Meet at the office on 08:00AM",
                    Date = DateTime.Today
                },
                new ToDo
                {
                    Title = "Lunch with Girlfriend",
                    Comment = "At restaurant near the office",
                    Date = DateTime.Today
                },
                new ToDo
                {
                    Title = "Go to dentist",
                    Comment = "Scheduled Visit to dentist",
                    Date = DateTime.Today.AddDays(2)
                }
            };
        }
    }
}