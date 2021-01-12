using Microsoft.AspNetCore.Mvc;
using System;

namespace areioredis
{
    [BindProperties(SupportsGet = true)]
    public class Areioredis
    {
        [BindProperty]
        public int Id { get; set; }
    }
}
