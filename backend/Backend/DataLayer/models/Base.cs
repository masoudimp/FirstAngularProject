using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.models
{
    public class Base
    {
        public DateTime CreationDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
