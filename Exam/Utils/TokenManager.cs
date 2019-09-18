using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Exam.DataProvider;
using Exam.Models;
using Exam.BackendSide;

namespace Exam.Utils
{
    public static class TokenManager
    {
        private static string _token;

        public static string GetToken()
        {
            if (string.IsNullOrEmpty(_token))
            {

                _token = new SsoClient().GetSsoResponse().Token;
                return _token;
            }
            return _token;
        }
    }
}