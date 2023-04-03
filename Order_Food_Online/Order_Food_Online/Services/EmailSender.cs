using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace Order_Food_Online.Services
{
	public class EmailSender : IEmailSender
	{
		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var fromMail = "foodsd43@outlook.com";
			var frompass = "ItiMobSd";

			var message = new MailMessage();
			message.From = new MailAddress(fromMail);
			message.Subject = subject;
			message.To.Add(email);
			message.Body = $"<html><body>{htmlMessage}</body></html>";
			message.IsBodyHtml= true;

			var stmtpClient=new SmtpClient(host: "smtp-mail.outlook.com")
			{
				Port= 587,
				Credentials=new NetworkCredential(fromMail,frompass),
				EnableSsl=true
			};
			stmtpClient.Send(message);
		}
	}
}
