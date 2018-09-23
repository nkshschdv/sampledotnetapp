
namespace Technossus.Reincarnation.Models
{
    public class File : AuditableBase
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] DocBytes { get; set; }
        public long? FileSize { get; set; }
        public string AzureImagePath { get; set; }
    }
}