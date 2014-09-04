using Invest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invest.Web
{
    public class UserModel : BaseEntity
    {
        public UserModel()
        {
            CreatedDate = DateTime.Now;
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool RememberMe { get; set; }
    }
}