using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace UserDataAccess.Db
{
    public partial class User
    {[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UserId { get; set; } 
        [Required, EmailAddress]
        public string UserEmail { get; set; } = null!;
        [Required ]
        public string UserPassword { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
