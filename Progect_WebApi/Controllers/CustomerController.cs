using Commont.Entity;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using Repository.Entity;
using Service.interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Security.Claims;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Repository.Entity;
using Org.BouncyCastle.Crypto.Macs;


namespace Progect_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        private readonly ILoginService service;
        private IConfiguration configuration;
        public CustomerController(ILoginService service, IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }
        
        private async Task<CustomersDto> Authenticate(string Email, int Password)
        {

           return  service.Login(Email, Password);
        }

        private string Generate(CustomersDto user)
        {
            //מפתח להצפנה-מהקובץ appsettings
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            //אלגוריתם להצפנה
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //אלו שדות להצפין
            var claims = new[] {
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.GivenName,user.FirstName),
            new Claim(ClaimTypes.Surname,user.LastName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // החלף את Id עם תכונת מזהה המשתמש בפועל

            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims,
                //תוקף ההזמנה
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //שליפת המשתמש מהטוקן
        private CustomersDto GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var UserClaim = identity.Claims;
                if (userId != null)
                {
                    return new CustomersDto()
                    {
                        Id = int.Parse(userId),
                        //Id=UserClaim.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier)?.Value,
                        FirstName = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                        Email = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                        LastName = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                    };
                }
            }
            return null;
        }
        //
        [HttpGet]

        public async Task<List<CustomersDto>> Get()
        {
            return await service.getAllAsync();
        }



        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<CustomersDto> Get(int id)
        {
            return await service.getAsync(id);
        }

        [HttpGet("{email}")]
        public async Task<Customers> Get([FromBody] Customers email)
        {
            await SendEmailToCustomer(email);
            return null;
        }
        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomersDto customers)
        {
            return Ok(await service.AddAsync(customers));
        }

        [HttpPost("/login")]
        public async Task<ActionResult> Login([FromBody] CustomersDto customers)
        {
            CustomersDto c =await Authenticate(customers.Email,customers.Password);
            if(c!=null)
            {
              var token=  Generate(c);
                return Ok(token);
            }
            return NotFound("user not found");
           
        }

        [HttpGet("customers/{customersEmail}")]


        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CustomersDto c)
        {
            await service.updateAsync(id, c);

        
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.deleteAsync(id);
        }

        private async Task SendEmailToCustomer(Customers c)
        {
            try
            {
                //using (var client = new SystemNetMailClient())

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("giveHope2024@gmail.com", "wouz kfjp tllw kotb");

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("נותנים תקווה-גמח תרופות בפריסה עולמית עם כל סוגי התרופות!", "giveHope2024@gmail.com"));
                    message.To.Add(MailboxAddress.Parse(c.Email));
                    message.Subject = "ממתין לך לקוח המתעניין בתרופה";
                    var builder = new BodyBuilder();
                    var htmlContent = System.IO.File.ReadAllText("Html/htmlPageToEmail.html");
                    builder.HtmlBody = htmlContent;
                    message.Body = builder.ToMessageBody();
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                Console.WriteLine("Mail Sent Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}






