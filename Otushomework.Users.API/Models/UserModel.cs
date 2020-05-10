using System.ComponentModel.DataAnnotations;

namespace Otushomework.Users.API.Models
{
    public class AddUserModel
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Phone]
        public string Phone { get; set; }
    }

    public class UpdateUserModel
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(256)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Phone]
        public string Phone { get; set; }
    }
}