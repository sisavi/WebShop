﻿using System;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public abstract class DomainEntityMetadata : IDomainEntityMetadata
    {
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime? DeletedAt { get; set; }
    }
}