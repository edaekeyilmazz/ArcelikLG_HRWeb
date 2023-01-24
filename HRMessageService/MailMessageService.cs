﻿using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HRMessageService
{
    public class MailMessageService:IMessageService
    {
        public UnitOfWork _uow;
        public void SendMessage(string TCNo)
        {
           //UnitOfWork.UnitOfWorkInstance
            var user = _uow.UserInformationRepository.FirstOrDefault(X => X.TCNo.Equals(TCNo));
            if (user != null)
            {
                string tMail = user.Email;
                string tFirstNameSurName = string.Format("{0} {1}", user.Name, user.Surname);
                string tPass = user.Password;

                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.Host = TrnEncryption.decrypt(@"jp2GX4Kq05rrBDfTzB/sjWjjYd1ZL+PCBjg/ZYU+a3s=", @"@Hv43s12efc4+_23tgvG", @"250E23DE-4198-F0D6-B2F1-123D8E3B9EA9");
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("user", "Password");
                objeto_mail.From = new MailAddress("noreplay@arcelik-lg.com");
                objeto_mail.To.Add(new MailAddress(tMail));
                objeto_mail.Subject = "Arçelik-LG şifre hatırlatma";

                objeto_mail.IsBodyHtml = true;

                objeto_mail.Body = string.Format(@"<HTML><BODY>Sistemimize hatalı E-Posta adresiyle kayıtlı kullanıcı şifre hatırlatma istedi. Telefonla irtibat kurması istendi. İlgili kişinin bilgileri aşağıdaki gibidir.<br /><br />
                    TC Kimlik No : {0}<br / >Adı Soyadı : {1}<br />Şifresi : {2}<br /><br />http://www.arcelik-lg.com.tr/HRWEB/<BR><BR></BODY></HTML>", TCNo, tFirstNameSurName, tPass);

                client.Send(objeto_mail);
            }
        }
    }
}
