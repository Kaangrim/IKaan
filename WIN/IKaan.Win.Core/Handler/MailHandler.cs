﻿using System;
using IKaan.Model.Common.UserModels .Mail;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.Core.Handler
{
	public static class MailHandler
	{
		public static void Send(string to, string subject, string body)
		{
			try
			{
				USendMail mail = new USendMail()
				{
					To = to,
					Subject = subject,
					Body = body
				};
				mail.From = "alex.woo@ikaan.net";
				using (var res = WasHandler.Execute<USendMail>("Email", "Send", null, mail))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
