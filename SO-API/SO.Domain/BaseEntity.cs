using SO.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SO.Domain
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ChangedDate { get; set; }
        public User CreatedBy { get; set; }
        public User ChangedBy { get; set; }
    }
}
