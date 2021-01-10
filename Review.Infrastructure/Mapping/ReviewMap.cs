using System.Data.Entity.ModelConfiguration;
using Review.Infrastructure.Domain;

namespace Review.Infrastructure.Mapping
{
    public class ReviewMap : EntityTypeConfiguration<ReviewDomain>
    {
        public ReviewMap()
        {
            ToTable("Reviews");
            HasKey(domain => domain.Id);
        }
    }
}
