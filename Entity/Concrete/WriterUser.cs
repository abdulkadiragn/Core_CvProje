﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
   public class WriterUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string ImageUrl { get; set; }

    }
}
