using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    
    public class Company
    {
        [Key]
        public int CompId { get; set; }

        public string Name { get; set; }
        
        //public Address Address { get; set; }

        //public Contract? Contract { get; set; }
    }
}
