using Common.Models.DTOs;

namespace Server.Tests.TestData.Dtos;

public static class TestSignInResponseDto
{
    public static SignInResponseDto GetTestSignInResponseDto(
        bool signOnSuccess = true, 
        string? token = "testToken")
    {
        return new SignInResponseDto()
        {
            SuccessfulSignOn = signOnSuccess,
            BearerToken = token
        };
    } 
}