﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentACar.Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(b => b.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(b => b.CarState).HasColumnName("State").IsRequired();
        builder.Property(b => b.ModelYear).HasColumnName("ModelYear").IsRequired();

        builder.HasOne(b => b.Model);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
