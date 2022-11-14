using NPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NPMS.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Data.Common;
using Newtonsoft.Json;
using System.Net;
using NPMS.ViewModels;

namespace NPMS.Tests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<NPMSContext>>
    {
        private readonly WebApplicationFactory<NPMSContext> _webApplicationFactory;
        public UnitTest1(WebApplicationFactory<NPMSContext> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }
        [Fact]
        public async void PassesIndexLoads()
        {
            var client = _webApplicationFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7223/Passes/Index");
            int code = (int)response.StatusCode;

            Assert.Equal(200, code);
        }
        [Fact]
        public async void CareersIndexLoads()
        {
            var client = _webApplicationFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7223/Careers/Index");
            int code = (int)response.StatusCode;

            Assert.Equal(200, code);
        }
        [Fact]
        public async void EventsIndexLoads()
        {
            var client = _webApplicationFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7223/Events/Index");
            int code = (int)response.StatusCode;

            Assert.Equal(200, code);
        }
        [Fact]
        public async void HomeIndexLoads()
        {
            var client = _webApplicationFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7223/Home/Index");
            int code = (int)response.StatusCode;

            Assert.Equal(200, code);
        }
        [Fact]
        public async void ParksIndexLoads()
        {
            var client = _webApplicationFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7223/Parks/Index");
            int code = (int)response.StatusCode;

            Assert.Equal(200, code);
        }

        //[Fact]
        //public async void RegisterTest()
        //{
            
        //    var client = _webApplicationFactory.CreateClient();
        //    var response = await client.PostAsync("https://localhost:7223/Account/Register", new StringContent(JsonConvert.SerializeObject(new RegisterViewModel()
        //    {
        //        Username = "2",
        //        Email = "hg@gmail.com",
        //        Password="test1@123",
        //        ConfirmedPassword="test1@123"

               
        //    })));

        //    //response.EnsureSuccessStatusCode();

        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //}

    }
}
