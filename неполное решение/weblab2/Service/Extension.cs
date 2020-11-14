using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace weblab2.Service
{
    public static class Extension 
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }
    }
}
