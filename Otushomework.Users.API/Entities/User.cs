using System;
using System.ComponentModel.DataAnnotations;

namespace Otushomework.Users.API.Entities
{

    /*id	integer($int64)
username	string
maxLength: 256
firstName	string
lastName	string
email	string($email)
phone	string($phone)
*/

    public class User
    {
        public long Id { get; set; }
        
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}