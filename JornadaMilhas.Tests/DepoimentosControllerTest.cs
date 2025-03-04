using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using System.Net;
using JornadaMilhas.API.Dtos.DepoimentoDtos;

namespace JornadaMilhas.Tests
{
    public class DepoimentosControllerTest
    {
        public DepoimentosControllerTest(ITestOutputHelper output)
        {
            Output = output;
        }
        private readonly string? _url = "https://localhost:7127/api/Depoimento";

        public ITestOutputHelper? Output { get; private set; }

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

            var depoimento = new CreateDepoimentoDto()
            {
                Nome = "Teste",
                Texto = "Gostei Muito, obrigado pela mensagem!"
            };

            var response = await client.PostAsJsonAsync(_url, depoimento);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task HttpPutStatusCodeTest()
        {
            using var client = new HttpClient();
            var id = "21";

            var depoimento = new UpdateDepoimentoDto()
            {
                Nome = "Real Oficial",
                Texto = "OI GOSTEI DA MENSAGEM"
            };

            var response = await client.PutAsJsonAsync($"{_url}/{id}", depoimento);
        }

        [Fact]
        public async Task HttpDeleteStatusCodeTest()
        {
            using var client = new HttpClient();
            var id = "29";

            var response = await client.DeleteAsync($"{_url}/{id}");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        
    }
}
