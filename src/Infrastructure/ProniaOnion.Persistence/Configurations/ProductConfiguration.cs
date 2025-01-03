﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired()
            .HasMaxLength(100);

            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(6,2)");

            builder
                .Property(p => p.SKU)
                .HasColumnType("char(10)");
        }
    }
}
