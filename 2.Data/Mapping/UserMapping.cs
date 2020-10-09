using _1.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace _2.Data.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");
            HasKey(x => x.Id);
            HasMany(x => x.Orders).WithOptional(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}