using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical.Configuration;
using Practical.Configuration.InputModels;
using Practical.Configuration.OutputModels;
using Practical.Configuration.Utils;
using Practical.Models;

namespace Practical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private readonly Exam_ASPNetContext _context;

        public AccountAPIController(Exam_ASPNetContext context)
        {
            _context = context;
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] frData = Encoding.UTF8.GetBytes(str);
            byte[] tgData = md5.ComputeHash(frData);
            string hashString = "";
            for (int i = 0; i < tgData.Length; i++)
            {
                hashString += tgData[i].ToString("x2");
            }
            return hashString;
        }

        [HttpPost]
        [Route("Login")]
        public ResponseLogin Login([FromBody] RequestLogin m)
        {
            ResponseLogin res = new ResponseLogin();
            try
            {
                m.Password = GetMD5(m.Password);
                var MemberLogin = _context.HtUsers.FromSqlRaw("sp_htUsers_Login {0},{1}", m.UserName, m.Password).ToList();
                if (MemberLogin.Count() != 1)
                {
                    res.Status = StatusID.AccessDenied;
                    res.Message = "Thông tin đăng nhập không chính xác";
                }
                else
                {
                    var User = MemberLogin.FirstOrDefault();
                    res.Info = new UserInfo();
                    UserInfo us = new UserInfo();
                    us.UserID = User.UserId;
                    us.FullName = User.FullName;
                    us.Email = User.Email;
                    us.UserName = m.UserName;


                    res.Token = API.createToken(m.UserName);
                    res.Info = us;
                    res.Status = StatusID.Success;
                    res.Message = "Đăng nhập thành công";
                }
            }
            catch (Exception ex)
            {
                res.Status = StatusID.InternalServer;
                res.Message = ex.Message;
            }
            return res;
        }      
    }
}
