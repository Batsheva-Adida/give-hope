using Commont.Dto;
using Commont.Entity;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Service.interfaces;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Security.Claims;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Repository.Entity;
using Org.BouncyCastle.Crypto.Macs;
using ActiveUp.Net.Mail;

namespace Progect_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeditionController : ControllerBase
    {
        private readonly IService<MedicinesDto> service;

        public MeditionController(IService<MedicinesDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<MedicinesDto>> Get()
        {
            return await service.getAllAsync();
        }

        [HttpPost("mail")]
        public async Task post(string mail,[FromForm]MedicinesDto m)
        {
            
            try
            {
                SendEmailToCustomer(mail, m);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] MedicinesDto medicines)
        {
            if (medicines.FileImage!=null)
            {
                var myPath = Path.Combine(Environment.CurrentDirectory + "/imgs/" + medicines.FileImage.FileName);
                using (FileStream fs = new FileStream(myPath, FileMode.Create))
                {
                    medicines.FileImage.CopyTo(fs);
                    fs.Close();
                }
                medicines.Image = medicines.FileImage.FileName;
            }
            return Ok(await service.AddAsync(medicines));


        }

        [HttpPut("{id}")]
    
        public async Task Put(int id, [FromForm] MedicinesDto c)
        {
            await service.updateAsync(id, c);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.deleteAsync(id);
        }
        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "imgs/", ImageUrl);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(bytes);
            string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            return image;
        }

        private async Task SendEmailToCustomer(string Email,MedicinesDto m)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("Smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("giveHope2024@gmail.com", "sybw dbly uojx mbnu");

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("נותנים תקווה-גמח תרופות בפריסה עולמית עם כל סוגי התרופות!", "giveHope2024@gmail.com"));
                    message.To.Add(MailboxAddress.Parse(Email));
                    message.Subject = "ממתין לך לקוח המתעניין בתרופה";

                    message.Body = new TextPart("plain ")
                    {
                        Text = $"פרטי התרופה שהלקוח מתעניין:{m.NameMedication}{m.PriceMedicine}{m.AmountOfMedicine}" 
                       
                    };
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