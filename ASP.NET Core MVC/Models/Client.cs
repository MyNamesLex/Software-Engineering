﻿namespace ASP.NET_Core_MVC.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ItemClient>? ItemClients { get; set; }
    }
}
