using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Technossus.Reincarnation.Models.Interfaces
{
    public interface IAuditable
    {
        [Column(TypeName = "datetime2")]
        DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        DateTime UpdatedDate { get; set; }

        string CreatedById { get; set; }

        string UpdatedById { get; set; }

        bool IsDeleted { get; set; }
    }
}
