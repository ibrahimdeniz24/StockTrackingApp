﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTrackingApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.Entities.EntityTypeConfigurations
{
    public abstract class BaseUserConfiguration<T>:AuditableEntityConfiguration<T> where T : BaseUser
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Email).HasMaxLength(256).IsRequired();
            //builder.Property(x => x.DateOfBirth).HasColumnType("date").IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.IdentityId).IsRequired();
        }
    }
}
