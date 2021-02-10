namespace LibraryManagementSystem.Models.ApplicationModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            IssueBooks = new HashSet<IssueBook>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short StudentId { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(10)]
        public string ContactNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueBook> IssueBooks { get; set; }
    }
}
