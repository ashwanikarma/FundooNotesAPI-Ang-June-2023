using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IuserBL
    {
        public UserModel Registration(UserModel userModel);
        public string Login(LoginModel loginModel);
        public ResetModel ResetPassword(ResetModel resetModel, string Email);
        public UserEntity GetUser(int id);
        public string Getalluser();
        public bool ForgetPassword(string EmailId);
        //public string ForgetPasswordd(string email);
        //public UserTicket CreateTicketForPassword(string email, string token);

    }
}
