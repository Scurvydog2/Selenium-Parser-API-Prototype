using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.IO;
using Newtonsoft.Json;

namespace seleniumPOC
{
    class Program
    {
        class Step{
      public int stepType;
       public string field;
       public string value;
     
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\Evan Cook\selenium\seleniumPOC\test.JSON";
            //Step json_serializer = JsonConvert.DeserializeObject<Step>(jsonString);
   
            if (!File.Exists(path))
            {
                // Create a file to write to.
                // using (StreamWriter sw = File.CreateText(path))
                // {
                //     sw.WriteLine("Hello");
                //     sw.WriteLine("And");
                //     sw.WriteLine("Welcome");
                // }
            }
            string s2="";
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s="";
                
                while ((s= sr.ReadLine()) != null)
                {
                    s2=s2+s;
                    Console.WriteLine(s);
                }
            }
             IWebDriver driver = new InternetExplorerDriver();
            // driver.Url = "http://www.demoqa.com";
            // driver.Close();
            Step[] json = JsonConvert.DeserializeObject<Step[]>(s2);
            Console.WriteLine(json[1].field);
            foreach(Step step in json)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(step.value);
                if (step.stepType==1)
                {
                    driver.Url =step.value;
                }else if(step.stepType==5)
                {
                    IWebElement field = driver.FindElement(By.XPath(step.field));
                    field.Clear();
                    field.SendKeys(step.value);
                }else if(step.stepType==2){
                    IWebElement field = driver.FindElement(By.XPath(step.field));
                    field.Click();
                }
            }
        }
    }
}
