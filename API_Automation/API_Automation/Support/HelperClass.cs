using APITesting.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation.Support
{
    public static class HelperClass
    {

        public static RequestData GetRequestData(int age, string name, int salary)
        {
            RequestData requestData = new RequestData()
            {
                Age = age,
                Name = name,
                Salary = salary
            };
            return requestData;

        }


    }
}
