using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{

    [Required(ErrorMessage = "L'username è obbligatorio")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "La password è obbligatoria")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

}