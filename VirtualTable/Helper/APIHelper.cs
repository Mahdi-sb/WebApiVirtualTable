using System;
using System.Net.Http;

namespace VirtualTable.Helper
{
    public class ApiHelper :IApi
    {

        public HttpClient Initial()
        {

            var client = new HttpClient {BaseAddress = new Uri("http://localhost:50913/")};
            return client;

        }






    }
}
