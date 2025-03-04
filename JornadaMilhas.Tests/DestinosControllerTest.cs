using JornadaMilhas.API.Dtos.DestinoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace JornadaMilhas.Tests
{
    public class DestinosControllerTest
    {
        private readonly string? _url = "https://localhost:7127/api/destino";

        [Fact]
        public async Task HttpGetStatusCodeTest()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(_url);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task HttpPostStatusCodeTest()
        {
            using var client = new HttpClient();

            var destino = new CreateDestinoDto()
            {
                Nome = "Casa Teste",
                Preco = 111.11
            };

            var response = await client.PostAsJsonAsync(_url, destino);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task HttpPutStatusCodeTest()
        {
            using var client = new HttpClient();
            var id = "1";

            var destino = new UpdateDestinoDto()
            {
                Nome = "Casa Real Oficial",
                Preco = 111.99
            };

            var response = await client.PutAsJsonAsync($"{_url}/{id}", destino);
        }

        [Fact]
        public async Task HttpDeleteStatusCodeTest()
        {
            using var client = new HttpClient();
            var id = "2";

            var response = await client.DeleteAsync($"{_url}/{id}");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
