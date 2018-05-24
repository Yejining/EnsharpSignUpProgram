using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

using EnSharpSignUpProgram.Data;

namespace EnSharpSignUpProgram.API
{
    class UsingAPI
    {
        public JObject ConnectToAPI(string searchingKeyword)
        {
            StringBuilder getParameters = new StringBuilder();
            getParameters.Append("?query=" + HttpUtility.UrlEncode(searchingKeyword));

            // API 연결
            string postingId = string.Empty;
            string header = $"KakaoAK {Constant.API_KEY}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constant.API_URL + getParameters);
            request.Headers.Add("Authorization", header);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "GET";
            request.ServicePoint.Expect100Continue = false;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsePostStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responsePostStream, Encoding.GetEncoding("EUC-KR"), true);

            // 검색
            string responseFromServer = reader.ReadToEnd();
            JObject jObject = JObject.Parse(responseFromServer);

            return jObject;
        }
    }
}
