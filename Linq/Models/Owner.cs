using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.Models
{
    public class Owner
    {
        public Guid OwnerId { get; set; }        
        public string FullName { get; set; }
        public string Email { get; set; }      
        public string Phone { get; set; }    
    }
}
