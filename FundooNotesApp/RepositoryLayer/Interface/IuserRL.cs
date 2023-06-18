using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IuserRL
    {
        public UserModel Registration(UserModel userModel);
        public string Login(LoginModel loginModel);
        public ResetModel ResetPassword(ResetModel resetModel, string Email);
        public UserEntity getuser(int id);
        public string getalluser();

        public bool ForgetPassword(string EmailId);
        //public string ForgetPasswordd(string email);
        //public UserTicket CreateTicketForPassword(string email, string token);

    }
}
