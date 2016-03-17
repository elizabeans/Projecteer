﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecteer.Core.Domain
{
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }
    }
}
