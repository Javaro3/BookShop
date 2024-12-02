using BookShop.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasMany(b => b.OrderItems)
            .WithOne(oi => oi.Book)
            .HasForeignKey(oi => oi.BookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}