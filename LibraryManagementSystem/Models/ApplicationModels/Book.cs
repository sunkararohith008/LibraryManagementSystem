namespace LibraryManagementSystem.Models.ApplicationModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            IssueBooks = new HashSet<IssueBook>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookId { get; set; }

        [StringLength(30)]
        public string BookTitle { get; set; }

        [StringLength(20)]
        public string AuthorName { get; set; }

        [StringLength(20)]
        public string PublisherName { get; set; }

        [StringLength(20)]
        public string Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueBook> IssueBooks { get; set; }
    }
}
