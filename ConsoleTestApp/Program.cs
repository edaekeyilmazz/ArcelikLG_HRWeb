using DAL;
using DAL.Models;
using HRBussiness;
using HRServiceLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Step> ls = new List<Step>();
            //ls.Add(new Step() { ActionName="tst1", ControllerName = "tst1", ID=1, IsValid=true, StepOrder=1, StepName="test1" });
            //ls.Add(new Step() { ActionName = "tst2", ControllerName = "tst1", ID = 1, IsValid = true, StepOrder = 1, StepName = "test2" });
            //ls.Add(new Step() { ActionName = "tst3", ControllerName = "tst1", ID = 1, IsValid = true, StepOrder = 1, StepName = "test3" });
            //ls.Add(new Step() { ActionName = "tst4", ControllerName = "tst1", ID = 1, IsValid = true, StepOrder = 1, StepName = "test4" });
            //ls.Add(new Step() { ActionName = "tst5", ControllerName = "tst1", ID = 1, IsValid = true, StepOrder = 1, StepName = "test5" });
            //System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(List<DAL.Models.Stepii>));

            //using (StreamReader wrt = new StreamReader(File.Open("Steps.xml", FileMode.Open, FileAccess.Read)))
            //{
            //    object o = xs.Deserialize(wrt);
            //    List<DAL.Models.Stepii> lst1 = (List<DAL.Models.Stepii>) o ;
            //    List<Step> lst = new List<Step>();
            //    lst1.ForEach(X =>
            //    {
            //        X.ID = 0; lst.Add(new Step()
            //        {
            //            ActionName = X.ActionName,
            //            ControllerName = X.ControllerName,
            //            CreatedDate = DateTime.Now,
            //            IsValid = true,
            //            StepOrder = X.Order,
            //            StepName = X.StepName
            //        });
            //    });
            //    using (HRWebContext hr = new HRWebContext())
            //    {
            //        hr.Step.AddRange(lst);
            //        hr.SaveChanges();
            //    }
            //    Console.WriteLine("Tamamdır!!");
            //}

            var result = Helper.Steps.FirstOrDefault(X => X.Value.ControllerName.Equals("test"));
            

            Console.WriteLine(Helper.Steps.Count.ToString());
            foreach (var item in Helper.Steps)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value.StepName);
            }
            Console.WriteLine("\n\r");
            foreach (var item in Helper.NextSteps)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value.StepName);
            }

            byte bVal = (byte)(StatusTypes.Continue | StatusTypes.StepsCompleted | StatusTypes.WaitingForSAP | StatusTypes.AllProccessFinished);

            

            Console.WriteLine("\n" + Helper.GetRedirectAction(new PersonalInformation()));

            StatusTypes o = (StatusTypes)Enum.ToObject(typeof(StatusTypes), bVal);

            Console.WriteLine("\n\r\n\r");
            Console.WriteLine(o);
            Console.WriteLine((byte)o);

            Console.ReadLine();

            Console.WriteLine();

            List<string> lst = new List<string>() { "asd", "qwe", "zxc", "2134" };

            foreach (var item in lst.Select((x, i) => new { name=x, indx = i }))
            {
                Console.WriteLine("{0} - {1}", item.name, item.indx);
            }
            
            getAllAsync();

            var a =new  List<string>(Enumerable.Range(1995, 23).Select(X => X.ToString()));
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static async void getAllAsync()
        {
            PersonalInfoSources pi = PersonalInfoSources.PersonalInfoSourcesInstance;
            List<Task<List<string>>> tasks = new List<Task<List<string>>>();
            tasks.Add(Task<List<string>>.Run(() => { Console.WriteLine("Şehirler Geliyor!"); return pi.GetCities(); }));
            tasks.Add(Task<List<string>>.Run(() => pi.GetDisablityReasons()));
            tasks.Add(Task<List<string>>.Run(() => pi.GetBloodTypes()));
            tasks.Add(Task<List<string>>.Run(() => pi.GetGenders()));
            tasks.Add(Task<List<string>>.Run(() => pi.GetHealthStatus()));
            await Task.WhenAll(tasks);

        }
    }
}
