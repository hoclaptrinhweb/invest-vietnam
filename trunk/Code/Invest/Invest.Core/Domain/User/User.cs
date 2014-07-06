using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public partial class User : BaseEntity
    {
        public User()
        {
            CreatedDate = DateTime.Now;
        }

        [StringLength(256)]
        [Index("UserName", IsUnique = true)]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
