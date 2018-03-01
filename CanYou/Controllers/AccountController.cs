using CanYou.Models.Info.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace CanYou.Controllers
{
    public class AccountController : AbstractController
    {        
        [HttpGet]
        public ActionResult Login()
        {
            if (accountItem != null) return Redirect("/Lecture/List");
            return View();
        }

        // 액션은 특정 URL에 대한 요청이 들어올 때 호출되는 컨트롤러 상의 메서드
        // 액션 결과는 컨트롤러 액션이 브라우저 요청에 대해 반환하는 것을 의미
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            AccountItem item = AccountDao.FindByEmail(email);
            if (item == null) return Json(new { result = "fail", message = "존재하지 않는 이메일입니다." }, JsonRequestBehavior.AllowGet);
            if (item.State == "DEL") return Json(new { result = "fail", message = "탈퇴한 이메일입니다." }, JsonRequestBehavior.AllowGet);
            if (!item.Password.Equals(password)) return Json(new { result = "fail", message = "존재하지 않는 비밀번호입니다." }, JsonRequestBehavior.AllowGet);
            // 쿠키 할당
            FormsAuthentication.SetAuthCookie(item.Email, true);
            Session["account"] = item;
            // JsonResult 액션 결과 반환
            // dafault JsonRequestBehavior.DenyGet - HttpGet x
            return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
        }
      
        public ActionResult Index()
        {

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(string currentPwd,string newPassword)
        {
            AccountItem item = AccountDao.FindByEmail(accountItem.Email);
            if (item.Password != currentPwd) return Json(new { result = "fail", message = "현재 비밀번호가 다릅니다." }, JsonRequestBehavior.AllowGet);
            item.Password = newPassword; 
            try
            {
                AccountDao.Update(item);
                Session["account"] = item;
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "fail", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        

        [HttpGet]
        public ActionResult Join()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JoinUpdate(string email, string password)
        {
            AccountItem item = AccountDao.FindByEmail(email);
            if (item != null) return Json(new { result = "fail", message = "동일한 이메일이 이미 존재합니다." }, JsonRequestBehavior.AllowGet);
            item = new AccountItem();
            item.Email = email;
            item.Password = password;
            item.State = "REG";
            try
            {
                AccountDao.Insert(item);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "fail", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            SetLogoutProcess();
            return Redirect("/Account/Login");
        }

        private void SetLogoutProcess()
        {
            FormsAuthentication.SignOut();
            Session["account"] = null;
        }

        [Authorize]
        public ActionResult Withdraw()
        {
             try
            {
                AccountDao.UpdateState(accountItem.Id, "DEL");
                SetLogoutProcess();
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "fail", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult FindPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindPassword(string email)
        {
            try
            {
                AccountItem item = AccountDao.FindByEmail(email);
                if (item == null) return Json(new { result = "fail", message = "존재하지 않는 이메일입니다."}, JsonRequestBehavior.AllowGet);
                if (item.State == "DEL") return Json(new { result = "fail", message = "탈퇴한 이메일입니다." }, JsonRequestBehavior.AllowGet);
                SendEmail(email, item.Password);
                return Json(new { result = "success", message= "비밀번호를 이메일로 전송하였습니다."}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "fail", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //private void SendEmail(string email, string password)
        //{
        //    //Smtpclient client = new smtpclient("smtp.gmail.com", 465);
        //    SmtpClient client = new SmtpClient("127.0.0.1");

        //    client.UseDefaultCredentials = true; // 시스템에 설정된 인증 정보를 사용하지 않는다.
        //    //client.EnableSsl = true;
        //    //client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 gmail에 인증을 받지 못한다.
        //    //client.Credentials = new System.Net.NetworkCredential("Administrator", "tobeornottobe");

        //    MailAddress from = new MailAddress("ekdnlt1995@gmail.com", "이정희", System.Text.Encoding.UTF8);
        //    MailAddress to = new MailAddress(email);

        //    MailMessage message = new MailMessage(from, to);

        //    message.Body = "canyou에서의 비밀번호는 " + password + " 입니다.";
        //    string somearrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
        //    message.Body += Environment.NewLine + somearrows;
        //    message.BodyEncoding = System.Text.Encoding.UTF8;
        //    message.Subject = "CanYou 비밀번호 찾기" + somearrows;
        //    message.SubjectEncoding = System.Text.Encoding.UTF8;

        //    client.Send(message);
        //    message.Dispose();
        //}

        private void SendEmail(string email, string password)
        {
            var fromAddress = new MailAddress("ekdnlt1995@gmail.com");
            var fromPassword = "tkfkd1614!";
            var toAddress = new MailAddress(email);

            string subject = "비밀번호 찾기 입니다.";
            string body = "CanYou에서의 비밀번호는 " + password + " 입니다.";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })


                smtp.Send(message);
        }

        [Authorize]
        public ActionResult UseInfo()
        {
            return View();
        }
	}
}