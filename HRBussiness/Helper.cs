using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.IO;
using DAL.Models;

namespace HRBussiness
{
    public class Helper
    {
        //public static UnitOfWork _uow;
        //public Helper(IUnitOfWork uow)
        //{
        //    _uow = (UnitOfWork)uow;
        //}
        private static readonly Lazy<Dictionary<string, Step>> lazyStepList = new Lazy<Dictionary<string, Step>>(() =>
        {
            Dictionary<string, Step> dicSteps = null;
            using (HRWebContext hrcon=new HRWebContext())
            {
                dicSteps = hrcon.Step.Where(X => X.IsValid).OrderBy(X => X.StepOrder).ToDictionary(y => y.StepName, y => y);
            }
            return dicSteps;
        });

        public static Dictionary<string, Step> Steps { get { return Helper.lazyStepList.Value; } }

        private static readonly Lazy<Dictionary<string, Step>> lazyNextStepList = new Lazy<Dictionary<string, Step>>(() =>
        {
            Dictionary<string, Step> nextstps = new Dictionary<string, Step>();
            string[] keys = Steps.Select(X => X.Key).ToArray();
            Step[] stps = Steps.Select(X => X.Value).ToArray();

            for (int i = 0; i < stps.Length - 1; i++)
                nextstps.Add(keys[i], stps[i + 1]);

            nextstps.Add(keys[keys.Length - 1], stps[stps.Length - 1]);
            return nextstps;
        });

        private static readonly Lazy<Dictionary<string, Step>> lazyPreviousStepList = new Lazy<Dictionary<string, Step>>(() =>
        {
            Dictionary<string, Step> preStps = new Dictionary<string, Step>();
            string[] keys = Steps.Select(X => X.Key).ToArray();
            Step[] stps = Steps.Select(X => X.Value).ToArray();
            preStps.Add(keys[0], Steps[keys[0]]);

            for (int i = 1; i < stps.Length; i++)
                preStps.Add(keys[i], stps[i -1]);

            return preStps;
        });

        public static Dictionary<string, Step> NextSteps { get { return Helper.lazyNextStepList.Value; } }
        public static Dictionary<string, Step> PreviousSteps { get { return Helper.lazyPreviousStepList.Value; } }

        public static Transaction GetStep(IStepable ent, HRWebContext hrCon)
        {
            long uiId = 0;
            if (ent.UserInformation == null) uiId = ent.UserInfoId;
            else uiId = ent.UserInformation.UserID;

            var ui = hrCon.UserInformation.SingleOrDefault(X => X.UserID == uiId);
            Transaction trnObj = new Transaction() { CreatedDate = DateTime.Now, IsValid = true, UserID = uiId };
            //.UserInformationRepository.GetById(ent.UserInfoId);

            //trnObj.UserInformation = ent.UserInformation;
            //trnObj.UserID = ent.UserInformation.UserID;

            string typ = ent.GetType().Name;
            //ent.UserInformation = ui;
            //ent.UserInfoId = uiId;
            //trnObj.UserInformation.StatusType = Steps.Last().Key.Equals(typ) ? (byte)(StatusTypes.StepsCompleted) : (byte)(StatusTypes.Continue | StatusTypes.StepsCompleted);
            //ent.UserInformation 
            ui.StatusType = Steps.Last().Key.Equals(typ) ? (byte)(StatusTypes.StepsCompleted) : (byte)(StatusTypes.Continue | StatusTypes.StepsCompleted);
            hrCon.Entry<UserInformation>(ui).State = System.Data.Entity.EntityState.Modified;


            trnObj.FromStepId = Steps[typ].ID;
            trnObj.ToStepId = NextSteps[typ].ID;

            return trnObj;
        }
        public static Step GetStepByControllerName(string controllerName)
        {
            controllerName = controllerName.Replace("Controller", string.Empty);
            var result = Steps.FirstOrDefault(X => X.Value.ControllerName.Equals(controllerName));
            if (!string.IsNullOrEmpty(result.Key))
                return Steps[result.Key];
            return null;
        }


        public static string GetRedirectAction(IStepable ent)
        {
            return string.Format("~/{0}/{1}", NextSteps[ent.GetType().Name].ControllerName, NextSteps[ent.GetType().Name].ActionName);
        }

    }

}
