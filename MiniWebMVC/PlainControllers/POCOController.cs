using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniWebMVC.PlainControllers
{
    public class POCOController
    {
        public IActionResult Http([FromQuery]int p1 = 0)
        {
            return new ContentResult(){ Content = p1.ToString()};
        }
    }
}
