﻿using WhingePool.Core.API;

namespace WhingePool.Core.Entities
{
    public class WhingeEntity : IWhinge
    {
        public string Whinge { get; set; }

        public string WhingePool { get; set; }

        public string Whinger { get; set; }
    }
}