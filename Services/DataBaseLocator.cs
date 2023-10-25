using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfTry.Model;
namespace wpfTry.Services
{
    public class DatabaseLocator
        {
            public static ProductContext Context { get; set; }
        }
    
}
