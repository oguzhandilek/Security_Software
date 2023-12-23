using Entity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using WebApi.Service;

namespace WebApi.Security
{
    public class BasicAuthenticationHandler: AuthenticationHandler<BasicAuthenticationOption>
    {
        private readonly Entity.Context.MyDbContext _context;
        private readonly UserService userService;
        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOption> options, ILoggerFactory loggerFactory,UrlEncoder urlEncoder,ISystemClock systemClock): base(options, loggerFactory, urlEncoder, systemClock)
        {
            userService = new UserService();
            _context = new Entity.Context.MyDbContext();
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            byte[] incomingCredential = Convert.FromBase64String(headerValue.Parameter);


            string userCredential = Encoding.UTF8.GetString(incomingCredential);
            string username = userCredential.Split(':')[0];
            string password = userCredential.Split(":")[1];
            
            Student student = _context.Students.SingleOrDefault(s => s.Firstname==username && s.Password == password);
            if (student == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Wrong username or password"));
            }

            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, student.Firstname),
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.MobilePhone, student.Phone),
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
