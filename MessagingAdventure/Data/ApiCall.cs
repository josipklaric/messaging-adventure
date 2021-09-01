using System;

namespace MessagingAdventure.Data
{
    public class ApiCall
    {
        public int Id { get; set; }
        public string Endpoint { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Content { get; set; } 
    }
}
