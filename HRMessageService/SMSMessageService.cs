using biz.biotekno.sms.xml.helper;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMessageService
{
    public class SMSMessageService:IMessageService
    {
        public UnitOfWork _uow;
        public void SendMessage(string TCNo)
        {
            //HRBussiness.UnitOfWork.UnitOfWorkInstance
            var user = _uow.UserInformationRepository.FirstOrDefault(X => X.TCNo.Equals(TCNo));
            if (user != null)
            {
                string tPass = user.Password;
                string tGSMNo = user.MobilePhone;
                if (!string.IsNullOrEmpty(tGSMNo))
                {
                    string tMessage = string.Format(@"Arçelik-LG mavi yaka online başvuru sisteminde kayıtlı kullanıcınızın TC Kimlik Numarası : {0} Şifresi : {1}", TCNo, tPass);

                    ResponseFromBioTekno responseFromBioTekno;
                    SmsToOne smsToOne = new SmsToOne();

                    smsToOne.Username = "ftok";
                    smsToOne.Password = "284050";
                    smsToOne.Originator = "ARCELiK-LG";
                    smsToOne.setMessage(tGSMNo, tMessage);
                    smsToOne.MessageType = "0";
                    smsToOne.MessageHeader = "Arçelik-LG Mavi Yaka";

                    responseFromBioTekno = smsToOne.sendMessage(); 
                }
            }
        }
    }
}
