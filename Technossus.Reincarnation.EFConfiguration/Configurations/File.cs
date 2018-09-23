using System.Data.Entity.ModelConfiguration;
using Technossus.Reincarnation.Models;

namespace Technossus.Reincarnation.Data.Configurations
{
    public class FileConfiguration : EntityTypeConfiguration<File>
    {
        public FileConfiguration() => ToTable("File", "dbo");
    }
}
