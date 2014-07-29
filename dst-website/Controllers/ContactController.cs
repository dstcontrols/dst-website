#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/ContactController.cs
// 
// Creation Time     : 2014-07-29 9:24 AM
// Time Last Updated : 2014-07-29 11:45 AM
// Copyright         : (C) 2014 Devbridge Group LLC
// Contributions By  : (C) 2014 DST Controls
// License           : Better CMS License Agreement
// License URL:      : https://raw.githubusercontent.com/devbridge/BetterCMS/dev/license.txt
// 
// Author            : Andrew Pong
// Email             : apong@dstcontrols.com
// Website           : www.dstcontrols.com
// Phone             : 1(800) 251-0773
// 
// Use of this software is subject to the terms and conditions provided in dst-website/dst-website/betterCMS.license.txt
// 
// ************************************************************************************************************************

#endregion

namespace dst_website.Controllers
{
    #region

    using System;
    using System.Net.Mail;
    using System.Web.Mvc;
    using dst_website.Helpers;
    using dst_website.Models;

    #endregion

    public class ContactController : Controller
    {
        [HttpPost]
        public virtual ActionResult ContactForm(ContactFormViewModel viewModel)
        {
            bool success;
            if (this.ModelState.IsValid)
            {
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress("info@BetterCmsDemo.com");
                    message.ReplyToList.Add(new MailAddress(viewModel.Email));
                    message.To.Add(new MailAddress(viewModel.EmailTo));
                    message.Subject = string.Format("[BetterCmsDemo.com] Message from {0}", viewModel.Name);
                    message.IsBodyHtml = true;
                    message.Body = EmailHelper.FormatMessage(viewModel);

                    try
                    {
                        SmtpClient client = new SmtpClient();
                        client.Send(message);
                        success = true;
                    }
                    catch (Exception)
                    {
                        success = false;
                    }
                }
            }
            else
            {
                success = false;
            }

            return new JsonResult
                   {
                       Data = new
                              {
                                  success,
                                  message =
                           success
                               ? "Your message successfully send."
                               : "Sorry there has been an error while sending your message, please try again later."
                              }
                   };
        }
    }
}
