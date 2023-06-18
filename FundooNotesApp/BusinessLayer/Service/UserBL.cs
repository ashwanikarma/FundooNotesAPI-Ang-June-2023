using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL:IuserBL
    {
        private readonly IuserRL iuserRL;

        public UserBL(IuserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }   

        public UserModel Registration(UserModel userModel) {
            try
            {
                return iuserRL.Registration(userModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }    
        }

        public string Login (LoginModel loginModel)
        {
            try
            {
                return iuserRL.Login(loginModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResetModel ResetPassword(ResetModel resetModel, string Email)
        {
            try
            {
                return iuserRL.ResetPassword(resetModel, Email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public UserEntity GetUser(int id)
        {
            try
            {
                return iuserRL.getuser(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string Getalluser()
        {
            try
            {
                return iuserRL.getalluser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ForgetPassword(string EmailId)
        {
            try
            {
                return iuserRL.ForgetPassword(EmailId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public string ForgetPasswordd(string email)
        //{
        //    try
        //    {
        //        return iuserRL.ForgetPasswordd(email);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public UserTicket CreateTicketForPassword(string email, string token)
        //{
        //    try
        //    {
        //        return iuserRL.CreateTicketForPassword(email, token);
        //    }
        //    catch (Exception e )
        //    {

        //        throw e;
        //    }
        //}



    }
}
