using System.ComponentModel.DataAnnotations;

namespace AutoDiag.BL.DTOs.UserDtos
{
    public class CreateUserDto
    {
      //  public string id { get; set; }  
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$",
        //ErrorMessage = "First Name must contain only letters and start with a capital letter")]
        //[Length(3,25)]
        //[Display(Name ="First Name")]
        public string FristName { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$",
        //ErrorMessage = "Last Name must contain only letters and start with a capital letter")]
        //[Length(3, 25)]
        //[Display(Name = "Last Name")]
        public string LastName { get; set; }    
        public string UserName { get; set; }   
        public string Email { get; set; }
        public string Password { get; set; }    
    }
}
