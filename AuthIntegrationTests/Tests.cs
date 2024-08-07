﻿using AuthMicroservice.Models.Auth;
using AuthMicroservice.Models.Auth.RequestModels.UserData;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
                FullName="TestTest",
                Role="Admin",
                Password="Password1/",
                Confirm="Password1/"
            };
            //act
            await _httpClient.DeleteAsync($"/deleteUser/{registrationData.Email}");
            var response = await _httpClient.PostAsJsonAsync("/register", registrationData);
            //assert
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task SignInUser_Success()
        {
            //arrange
            var signInData = new SignInUserData()
            {
                Email="binaryfile@mail.ru",
                Password="Password1/",
            };
            //act
            var response = await _httpClient.PostAsJsonAsync("/enter", signInData);
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
