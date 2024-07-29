using AuthMicroservice.Models.Auth;
using AuthMicroservice.Models.Auth.RequestModels.UserData;
using AuthMicroservice.Models.Auth.ResponseModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;


namespace AuthIntegrationTests
{
    [TestFixture]
    internal class Tests
    {
        private readonly WebApplicationFactory<Program> _webAppFactory = new();
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = _webAppFactory.CreateClient();
        }

        [Test]
        public async Task RegistrateUser_Success()
        {
            //arrange
            var registrationData = new RegistrationUserData()
            {
                Email="binaryfile@mail.ru",
                FullName="User0",
                Role="admin",
                Password="Password1/",
                Confirm="Password1/"
            };
            //act + assert           

            // Делаем запрос на регистрацию
            var response = await _httpClient.PostAsJsonAsync("/register", registrationData);
            response.EnsureSuccessStatusCode();
            // Достаём токены доступа и устанавливаем их в хедер
            var responseContent = await response.Content
                .ReadFromJsonAsync<AuthResponse>();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", responseContent.Token);
            // Удаляем пользователя
            var deleteResponse =
                await _httpClient.DeleteAsync($"/deleteUser/{registrationData.Email}");

            deleteResponse.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task SignInUser_Success()
        {
            //arrange
            var signInData = new SignInUserData()
            {
                Email="bignumbergames@gmail.com",
                Password="Password1/",
            };
            //act
            var response = await _httpClient.PostAsJsonAsync("/signIn", signInData);
            //assert
            response.EnsureSuccessStatusCode();
        }

        [TearDown]
        public void Teardown()
        {
            _httpClient.Dispose();
        }
    }
}
