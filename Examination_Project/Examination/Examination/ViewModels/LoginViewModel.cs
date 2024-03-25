using System.ComponentModel.DataAnnotations;

namespace Examination.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.Password)]//this will change the input type to password

        public string Password { get; set; }
        public string Email { get; set; }
    }
}

