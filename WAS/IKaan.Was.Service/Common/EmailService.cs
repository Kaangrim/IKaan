using System;
using System.Net;
using System.Net.Mail;
using IKaan.Base.Utils;
using IKaan.Model.Common.UserModels .Mail;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Variables;

namespace IKaan.Was.Service.Base
{
	public static class EmailService
	{
		public static WasRequest Send(WasRequest request)
		{
			try
			{
				if (request.Data == null)
					throw new Exception("이메일 전송 데이터가 정확하지 않습니다.");

				USendMail sendMail = request.Data.JsonToAnyType<USendMail>();
				using (MailMessage mail = new MailMessage())
				{
					mail.From = new MailAddress((sendMail.From.IsNullOrEmpty()) ? ConstsVar.MAIL_SMTP_ID : sendMail.From);
					mail.To.Add(sendMail.To);
					mail.Subject = sendMail.Subject;
					mail.Body = sendMail.Body;

					//Attachment attachment = new Attachment("");

					SmtpClient smtp = new SmtpClient(ConstsVar.MAIL_SMTP_SERVER, ConstsVar.MAIL_SMTP_PORT)
					{
						EnableSsl = false,
						Credentials = new NetworkCredential(ConstsVar.MAIL_SMTP_ID, ConstsVar.MAIL_SMTP_PW)
					};

					try
					{
						smtp.Send(mail);
					}
					catch(SmtpException ex)
					{
						throw new Exception("메일 전송 중 오류가 발생하였습니다. => " + ex.Message);
					}
				}
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}
	}
}
