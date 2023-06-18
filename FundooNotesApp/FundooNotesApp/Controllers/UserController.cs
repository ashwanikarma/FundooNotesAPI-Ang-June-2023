using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System.Linq;
using System.Security.Claims;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserBL iuserBL;
        private readonly FundooContext fundooContext;

       
        public UserController (IuserBL iuserBL, FundooContext fundooContext)
        {
            this.iuserBL = iuserBL;
            this.fundooContext = fundooContext;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser(UserModel userModel)
        {
            try
            {
                var result = iuserBL.Registration(userModel);
                if(result != null)
                {
                    return Ok(new { success=true , message= "Register Successfully", data=result});
                }else
                {
                    return BadRequest(new { success=false,message="unable to Register"});
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var result = iuserBL.Login(loginModel);
                if (result!=null)
                {
                    return Ok(new { success = true, message = "User Found" ,data=result});
                }
                else
                {
                    return BadRequest(new { success = false, meesage = "User is not Found" });
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetModel resetModel)
        {
            try
            {
                var email = User.Claims.FirstOrDefault(a => a.Type == "Email").Value;
                //var email = User.FindFirst().Value.ToString();

                var result = iuserBL.ResetPassword(resetModel, email);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Password updated", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, meesage = "unable to update password" });
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("ForgetPassword/{EmailId}")]

        public IActionResult ForgetPassword(string EmailId)
        {
            try
            {
                var result = iuserBL.ForgetPassword(EmailId);
                if (result != false)
                {
                    return Ok(new { success = true, message = "Mail send Succesfully" });
                }
                else
                {
                    return BadRequest(new { success = false, meesage = "unable to send mail" });

                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Getuser")]
        public IActionResult Getuser(int id)
        {
            try
            {
                var result = iuserBL.GetUser(id);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Successfuly get data", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, meesage = "unable to get data" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("Getalluser")]
        public IActionResult Getalluser()
        {
            try
            {
                var result = iuserBL.Getalluser();
                if (result != null)
                {
                    return Ok(new { success = true, message = "Successfuly get data", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, meesage = "unable to get data" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }

}
