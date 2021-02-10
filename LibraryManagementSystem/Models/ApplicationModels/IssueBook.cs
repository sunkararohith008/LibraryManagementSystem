namespace LibraryManagementSystem.Models.ApplicationModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IssueBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short IssueId { get; set; }

        public short? StudentId { get; set; }

        public int? BookId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IssueDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; }

        public virtual Student Student { get; set; }
    }
}
