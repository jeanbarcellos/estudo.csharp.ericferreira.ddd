using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infra.Data.Mappings
{
    public class DishMap : MapBase<Dish>
    {
        public override void Configure(EntityTypeBuilder<Dish> builder)
        {
            base.Configure(builder);

            builder.ToTable("dish");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Price)
                .HasColumnName("price")
                .IsRequired();
        }

    }
}
