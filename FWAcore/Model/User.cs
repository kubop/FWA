using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FWAcore.Model
{
	public partial class User
	{
        [NotMapped]
        public string? OldPassword { get; set; }

        [NotMapped]
        public string? NewPassword { get; set; }

        [NotMapped]
        public string? ConfirmPassword { get; set; }
    }
}
