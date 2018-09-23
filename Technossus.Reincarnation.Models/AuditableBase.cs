using System;
using Technossus.Reincarnation.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technossus.Reincarnation.Models
{
    public abstract class AuditableBase : IAuditable
    {
        public long Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public bool IsDeleted { get; set; }
    }
}
