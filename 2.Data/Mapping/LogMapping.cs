using _1.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace _2.Data.Mapping
{
    public class LogMapping : EntityTypeConfiguration<Log>
    {
        public LogMapping()
        {
            ToTable("Log");
            HasKey(x => x.Id);
        }
    }
}