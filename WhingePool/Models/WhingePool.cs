using System;

namespace WhingePool.Models
{

    public class UserWhingePool
    {
        public string UserId { get; set; }
        public string WhingePool { get; set; }
    }
    public class WhingePool
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Members { get; set; }

    }

    public class Whinge
    {
        public string Id { get; set; }

        public string WhingePool { get; set; }
        public DateTime WhingeTime { get; set; }
        public string Text { get; set; }
    }
}
