using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using EASendMail;
namespace RepositoryLayer.Service
{
    public class UserRL:IuserRL
    {
        private readonly FundooContext fundooContext;
        private readonly IConfiguration configuration;

        public UserRL( FundooContext fundooContext ,IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration = configuration;
        }

        public UserModel Registration(UserModel userModel)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = userModel.FirstName;
                userEntity.LastName = userModel.LastName;
                userEntity.Email = userModel.Email;
                userEntity.PAssword = userModel.PAssword;
                fundooContext.userEntities.Add(userEntity);
                int result = fundooContext.SaveChanges();
                if(result != 0)
                {
                    return userModel;
                }else return null;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

      

        public string Login(LoginModel loginModel)
        {
            var data = fundooContext.userEntities.Where(a => a.Email.Equals(loginModel.Email) && a.PAssword.Equals(loginModel.PAssword)).FirstOrDefault();
            if (data != null)
            {
                var token = GenerateSecurityToken(data.Email, data.UserId.ToString());
                return token.ToString();
            }
            else return null;
          
        }

        public ResetModel ResetPassword(ResetModel resetModel, string Email)
        {
            try
            {
                var result = fundooContext.userEntities.Where(a => a.Email.Equals(Email)).FirstOrDefault();
                if (result != null)
                {
                    if (resetModel.Password.Equals(resetModel.ConfirmPassword))
                    {

                        result.PAssword = resetModel.Password;
                    }
                }
                else return null;
                int _result = fundooContext.SaveChanges();
                if (_result != 0)
                {
                    return resetModel;
                }
                else return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ForgetPassword(string EmailId)
        {
            var result = fundooContext.userEntities.Where(a => a.Email.Equals(EmailId)).FirstOrDefault();
            if (result != null)
            {
                var token = GenerateSecurityToken(EmailId, result.UserId.ToString());
                if (token != null)
                {
                    MsmqModel msmqModel = new MsmqModel();
                    msmqModel.sendDatatoQueue(token);
                    return true;
                }
            }
            return false;
        }


        public UserEntity getuser(int id)
        {
            var result = fundooContext.userEntities.Where(a => a.UserId==id).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else return null;
        }

        public string getalluser()
        {
            var result = fundooContext.userEntities.Select(a=>new { a.UserId,a.FirstName, a.LastName, a.Email });
            string data = null;
            if (result != null)
            {
                foreach (var item in result)
                {
                    var res = item;
                       data+=res.ToString()+" " ;
                };
                return data;
            }
            else return null;
           
        }
        public string GenerateSecurityToken(string email,string id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim("Email",email),
            new Claim("UserId",id.ToString())
              };
            var token = new JwtSecurityToken(configuration["AppSettings:Key"],
             configuration["AppSettings:Key"],
             claims,
             expires: DateTime.Now.AddMinutes(60),
             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        //public string ForgetPasswordd(string email)
        //{
        //    try
        //    {
        //        var result = fundooContext.userEntities.Where(a => a.Email.Equals(email)).FirstOrDefault();
        //        if (result!=null)
        //        {
        //            var token = GenerateSecurityToken(email, result.UserId.ToString());
        //            new MSMQ().SendMessage(token, result.Email, result.FirstName);
        //            return token.ToString();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public UserTicket CreateTicketForPassword(string email, string token)
        //{
        //    try
        //    {
        //        var result = fundooContext.userEntities.Where(a => a.Email.Equals(email)).FirstOrDefault();
        //        if (result != null)
        //        {
        //            UserTicket ticket = new UserTicket
        //            {
        //                firstName = result.FirstName,
        //                lastName = result.LastName,
        //                email = result.Email,
        //                token = token,
        //                issueDateTime = DateTime.Now
                        
        //            };
        //            return ticket;
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}

    }
}
