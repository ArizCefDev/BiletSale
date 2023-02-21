using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Username minumum 8 character")]
        public string? UserName { get; set; }
        public string? Salt { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password minumum 8 character")]
        public string? Password { get; set; }
        public string? PasswordHash { get; set; }

    }
}
