using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_Models
{
    [Table("Users")]
    public partial class User
    {
        public string Password { get; set; }

        public string? Role { get; set; }

        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }
    }
}