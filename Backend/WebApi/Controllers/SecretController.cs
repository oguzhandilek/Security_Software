using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretController : BaseController
    {
        private readonly IHostEnvironment _environment;

        public SecretController(IHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPut]
        [Route("writesecret")]
        public string WriteSecret()
        {
            string secretString = "Server=localhost;Port=6432;Database=jsga;User Id=root;Password=ROOT;";
            DataProtector dataProtector = new DataProtector(_environment.ContentRootPath);
            int length=dataProtector.EncryptData(secretString);
            return "Secret lines wrote successfully";
        }

        [HttpGet]
        [Route("readsecret")]
        public string ReadSecret()
        {
            
            DataProtector dataProtector = new DataProtector(_environment.ContentRootPath);
            string secret = dataProtector.DecryptData();
            return secret;
        }
    }
}
