using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using Xpedia.Models;
using Xpedia.ViewModel;

namespace Xpedia.Controllers
{
    public class RegisterController : BaseController
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Exclude = "IsEmailVerified,ActivationCode")] VmRegister vmUser)
        {
            if (!ValidateRegister(vmUser)) return View(vmUser);

            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    FirstName = vmUser.FirstName,
                    LastName = vmUser.LastName,
                    Username = vmUser.Username,
                    Email = vmUser.Email,
                    Password = vmUser.Password,
                    Phone = vmUser.Phone,
                    Address = vmUser.Address,
                };
                var uniquser = _context.Users.FirstOrDefault(m => m.Email == user.Email);
                if (uniquser != null)
                {
                    ModelState.AddModelError("Email", "Bu E-Poçt artıq mövcuddur");
                    return View(user);
                }
                user.ActivationCode = Guid.NewGuid();

                user.Password = Crypto.HashPassword(user.Password);
                user.IsEmailVerified = false;
                _context.Users.Add(user);
                _context.SaveChanges();
                SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
                message = "Qeydiyyat uğurla başa çatdı. Aktivasiya linki" +
                " hesabınıza göndərildi:" + user.Email;
                Status = true;
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(vmUser);

        }

        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Register/"+emailFor+"/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("elvinem@code.edu.az", "Təsdiqetmə mesajı");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "elvin1998";
            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Hesabınız uğurla yaradıldı!";
                body = "<br/><br/>Sizin Xpedia hesabınız" +
               " uğurla yaradıldı. Aşağıdakı linkə klik edərək hesabınızı təsdiqlədin" +
                " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Şifrəni yenilə";
                body = "Salam,<br/>br/>Aşağıdakı linkə klik edərək şifrənizi yeniləyin" +
                    "<br/><br/><a href=" + link + ">Şifrə yeniləmə linki</a>";
            }
            

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

      

        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            _context.Configuration.ValidateOnSaveEnabled = false; 
            var v = _context.Users.Where(u => u.ActivationCode == new Guid(id)).FirstOrDefault();
            if (v != null)
            {
                v.IsEmailVerified = true;
                v.IsUser = true;
                _context.SaveChanges();
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }
            ViewBag.Status = Status;
            return View();
        }


        [HttpGet]
        public ActionResult Login(string ReturnURL)
        {
            ViewBag.Return = ReturnURL;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(VmUserLogin user, string ReturnURL)
        {

            string message = "";

            var v = _context.Users.Where(a => a.Email == user.Email).FirstOrDefault();
            if (v != null)
            {
                if (!v.IsEmailVerified)
                {
                    ViewBag.Message = "İlk öncə e-poçtunuzu təsdiqləyin";
                    return View();
                }
                if (Crypto.VerifyHashedPassword(v.Password,user.Password))
                {
                    int timeout = user.RememberMe ? 525600 : 20;
                    var ticket = new FormsAuthenticationTicket(user.Email, user.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    v.IsUser = true;
                    Session["LoginnedUser"] = v;
                    Session["UserID"] = v.ID;
                    Session["UserFullname"] = v.FirstName +" "+ v.LastName;


                    if (IsValidUri(ReturnURL))
                    {
                        return Redirect(ReturnURL);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }


            }
            else
            {
                message = "İstifadəçi tapılmadı";
            }

            ViewBag.Message = message;
            return View(user);
        }

        public bool IsValidUri(string uri)
        {
            return Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out Uri validatedUri);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            //Verify Email ID
            //Generate Reset password link 
            //Send Email 
            string message = "";
            bool status = false;
            var account = _context.Users.Where(a => a.Email== EmailID).FirstOrDefault();
            if (account != null)
            {
                //Send email for reset password
                string resetCode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(account.Email, resetCode, "ResetPassword");
                account.ResetPasswordCode = resetCode;
                //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                //in our model class in part 1
                _context.Configuration.ValidateOnSaveEnabled = false;
                _context.SaveChanges();
                message = "Şifrə yeniləmə kodu e-poçt adresinizə göndərildi.";
            }
            else
            {
                message = "Hesab tapılmadı.";
            }
            ViewBag.Message = message;
            return View();
        }


        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            var user = _context.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
            if (user != null)
            {
                VmResetPassword model = new VmResetPassword();
                model.ResetCode = id;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(VmResetPassword model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    user.Password = Crypto.HashPassword(model.NewPassword);
                    user.ResetPasswordCode = "";
                    _context.Configuration.ValidateOnSaveEnabled = false;
                    _context.SaveChanges();
                    message = "Şifrə uğurla yeniləndi !";
                }

            }
            else
            {
                message = "Nəsə düzgün deyil .";
            }
            ViewBag.Message = message;
            return View(model);
        }


        private bool ValidateRegister(VmRegister vmUser)
        {
            if (!vmUser.ConfirmPassword.Equals(vmUser.Password))
            {
                ModelState.AddModelError("Password","İkinci şifrə uyğun gəlmir");
                return false;
            }
            return true;
        }

    }
}