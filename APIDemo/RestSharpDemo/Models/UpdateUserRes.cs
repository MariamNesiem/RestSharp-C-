using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo.Models
{
    public class UpdateUserRes
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
