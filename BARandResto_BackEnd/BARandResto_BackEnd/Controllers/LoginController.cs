using Azure;
using BARandResto_BackEnd.Models;
using BARandResto_BackEnd.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BARandResto_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BarandRestoDbContext _context;
        public LoginController(BarandRestoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<BAR_LOGIN>> Get()
        {
            var result = await _context.BAR_LOGIN.ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<string> PostLoginInfo(BAR_LOGIN login)
        {
            string message = "";
            try
            {
                _context.BAR_LOGIN.Add(login);
                await _context.SaveChangesAsync();


                message = "Login Info Added Successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            ResponseMessage response = new ResponseMessage { ResponseRequiredMessage = message };
            var result = JsonConvert.SerializeObject(response);
            return result;
        }

        [HttpPut]
        public async Task<string> UpdateLoginInfo(BAR_LOGIN login)
        {
            string message = string.Empty;
            try
            {
                _context.Entry(login).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                message = "Login Info Updated Successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }

            ResponseMessage response = new ResponseMessage { ResponseRequiredMessage = message };
            var result = JsonConvert.SerializeObject(response);
            return result;
        }

        [HttpDelete]
        public async Task<string> DeleteLoginInfo(int id)
        {
            string message = string.Empty;
            try
            {
                var login = await _context.BAR_LOGIN.FindAsync(id);
                if (login == null)
                {
                    return "Login Info Not Found";
                }
                _context.BAR_LOGIN.Remove(login);
                await _context.SaveChangesAsync();

                message = "Login Info Deleted Successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }

            ResponseMessage response = new ResponseMessage { ResponseRequiredMessage = message };
            var result = JsonConvert.SerializeObject(response);
            return result;
        }
    }
}
