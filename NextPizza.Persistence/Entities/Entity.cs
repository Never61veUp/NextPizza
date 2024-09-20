﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Persistence.Entities
{
    public abstract class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }

    }

    public abstract class Entity : Entity<Guid>
    {
    }
}
