namespace Common.Models.DTOs;

public class SignInResponseDto
{ 
    public bool SuccessfulSignOn { get; set; }
    public string? BearerToken { get; set; }
}