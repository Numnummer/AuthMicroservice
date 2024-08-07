﻿using AuthMicroservice.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;


namespace AuthTest
{
    internal static class AuthServiceTestHelper
    {
        public static Mock<UserManager<AppUser>> GetUserManagerMock()
        {
            return new Mock<UserManager<AppUser>>(new Mock<IUserStore<AppUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<AppUser>>().Object,
                new IUserValidator<AppUser>[0],
                new IPasswordValidator<AppUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<AppUser>>>().Object);
        }
        public static Mock<SignInManager<AppUser>> GetSignInManagerMock(UserManager<AppUser> userManager)
        {
            return new Mock<SignInManager<AppUser>>(userManager,
                new HttpContextAccessor(),
                new Mock<IUserClaimsPrincipalFactory<AppUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<AppUser>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object,
                new Mock<IUserConfirmation<AppUser>>().Object);
        }
    }
}
