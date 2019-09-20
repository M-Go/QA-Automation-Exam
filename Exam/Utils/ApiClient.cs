using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Exam.Utils
{
    public class ApiClient
    {
        HttpClient _client;

        public ApiClient(string host)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(host);
            //string token = TokenManager.GetToken();
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJ1NURxdU5XUzc2K1Nxb2U3dm1YQnBDWHB5aUJCbWlSdUh4cVk4aGtWR0JjPSIsInN1YiI6IjE2NjQiLCJuYW1lIjoiYWRtaW5AYmV0bGFiIiwicHJvdmlkZXIiOiJCZXRMYWIiLCJpc1Rlc3QiOmZhbHNlLCJyb2xlcyI6IkZsaXBGbG9wQWRtaW4sUGF5bWVudHNPcGVyYXRvcixQYXltZW50c0FkbWluLEFkbWluLC4sQ1JNX0FsbEN1cnJlbmN5LENvcmVBbnRpRnJhdWRPcGVyYXRvcixGbGlwRmxvcFByb2R1Y3RPd25lcixDb3JlQXVkaXRMb2csU3BvcnRCZXRsYWJBZG1pbixDb3JlTVQsQ29yZVFBdGVzdCxCYWNrb2ZmaWNlUmVsZWFzZU1hbmFnZXIsUGF5bWVudHNBZG1pbjIsRmluQmV0c09wZXJhdG9yLENNU0FkbWluLEZsaXBGbG9wTDFTdXBwb3J0LENvcmVTdXBwb3J0VHJhaW5lZSxTcG9ydEJvb2ssQ21zVXNyNyxDb3JlUGF5bWVudE9wZXJhdG9yLFRyYW5zbGF0b3JEZXZlbG9wZXIsQ01TLENvcmVDYXNpbm9NYW5hZ2VyLEF1ZGlvVmlkZW9BZG1pbixDb3JlU3VwcG9ydE9wZXJhdG9yLFJlcG9ydGluZ01hbmFnZXIsTGl2ZVRyYWRlcixWSVBEYXNoYm9hcmRBZG1pbixDb3JlV2FsbGV0SW50ZWdyYXRpb24sVHJhbnNsYXRvckFkbWluLENyaXN0YXRhQWRtaW4sQXVkaW9WaWRlbyxDb3JlVmlld2VyLENvcmVQbGF5ZXJTZXJ2aWNlLENvcmVTdXBwb3J0TWFuYWdlcixDcm1TdXBwb3J0U3VwZXJ2aXNvcixGbGlwRmxvcERldixDcmlzdGF0YUV2ZW50TWFuYWdlcixTdHJhcGlDb250ZW50TWFuYWdlcixDb3JlSUNETWFuYWdlcixTcG9ydHNib29rTGltaXRzLENybVVzZXIsQ21zVXNyMyxDb3JlUGF5bWVudCxDb3JlLENvcmVSZXN0cmljdG9yLENybVN1cHBvcnRWaXAsVklQRGFzaGJvYXJkLFN1cHBvcnRNYW5hZ2VydGVzdCxTcG9ydE1lc3NlbmdlclNlcnZpY2UsQ29yZVRyYWRlclBNVCxCU1MsRmxpcEZsb3BCZXRib29rLENtc1VzcjQsQ29yZVBheW1lbnRNYW5hZ2VyLENyaXN0YXRhVG9wTGl2ZSxDb3JlV2FsbGV0LFNldHRsZW1lbnRPcGVyYXRvcixVQ1NVc2VyRXZlbnRMb2csU2VydmljZSxBbnRpRnJhdWQsU3BvcnRBZG1pbixTdHJhcGlBZG1pbixCZXRPZmZpY2UsQ01TVmlld2VyLENvcmVCYWNrb2ZmaWNlSG9sZGVyLENybVN1cHBvcnQsUmV0YWlsU2VydmljZSxDb3JlUmlza01hbmFnZXIsUGF5bWVudHNfdGVzdCxGbGlwRmxvcFJlbGVhc2VNYW5hZ2VyLFRyYW5zbGF0b3JNYW5hZ2VyLEdlbmVyYWwsRmxpcEZsb3BDYXNpbm8sVklQRGFzaGJvYXJkTWFuYWdlcixDb3JlQWRtaW5pc3RyYXRvcixTZXR0bGVtZW50LFNwb3J0c0Jvb2tBdXRvVGVzdHMsYmV0c2hvcCxCYWNrb2ZmaWNlLFJlc3VsdEZlZWQsUmVwb3J0aW5nLEJldGdlbml1cyxTZXR0bGVtZW50TW9uaXRvcixVQ1NSb2xlTWFuYWdlcixVQ1NBZG1pbixDcm0sQ29yZVFBLFNlY3VyaXR5T3BlcmF0b3IsQ3JtQWRtaW4sbWltb3Byb2hvZGlsLEJldFBsYWNlbWVudCxCZXRPZmZpY2VBZG1pbixJbnRlZ3JhdGlvblRlc3RPcGVyYXRvclJvbGUsRmxpcEZsb3BDb21wb25lbnRPd25lcixGbGlwRmxvcCxDb3JlQnJhbmQsQ29yZVBsYXllck1hbmFnZXIsQ29yZWwxb3BlcmF0b3IsQ3JtTWFuYWdlcixGbGlwRmxvcFFBLENvcmVUcmFkaW5nTWFuYWdlcixDb3JlUUEyLENvcmVPcGVyYXRvcixDb3JlVGVzdCxTdXBlcnZpc29yLEpvdXJuYWxpc3QsQ3Jpc3RhdGFTdXBlcnZpc29yLEJyYW5kQ3VycmVuY3lUZXN0LFRlY2hXcml0ZXJzLENvcmVGaW5hbmNlLFBheW1lbnRzQW5hbHlzdCxTRU9NYW5hZ2VyLENvcmVTdXBwb3J0U3BlY2lhbGlzdCxMb25nVG9rZW4sVHJhbnNsYXRvclN1cGVydmlzb3IsbWltb3Byb2hvZGlsX3ByZWRlZixDb3JlQkkrUmV0ZW50aW9uT3BlcmF0b3IsUGF5bWVudHMsSW50ZWdyYXRpb25UZXN0QWRtaW5Sb2xlLEFudGlGcmF1ZE9wZXJhdG9yLFNwb3J0c2Jvb2tQbGF5ZXJNYW5hZ2VyLENvcmVCZXRzTWFuYWdlcixQcmVtYXRjaFRyYWRlcixDcm1Ob3RpZmljYXRpb25Pbmx5LENyaXN0YXRhQ29udGVudE1hbmFnZXIsbmV3X3JvbGUsVUNTLEJldE9mZmljZVVzZXIsQ29yZVBheW1lbnRUcmFpbmVlLFVDU1VzZXJNYW5hZ2VyLENtc1VzcjIsRWRpdG9yLENvcmVTcG9ydHNib29rLEV2ZW50Q3JlYXRvcixDbXNVc3I1LEVTcG9ydFRyYWRlciIsImF0dHJpYnV0ZXMiOltbInBlcm0uQ01TIiwie1widmVyXCI6MS4wLFwibGVuXCI6NzQsXCJiaXRzXCI6XCIvLy8vLy8vLy8vLy9Bdz09XCJ9IiwxNzI3XSxbInBlcm0uQ29tbW9uIiwie1widmVyXCI6MS4wLFwibGVuXCI6NTMsXCJiaXRzXCI6XCIvLy8vLy8vL0h3PT1cIn0iLDE3MzFdLFsicGVybS5jb3JlIiwie1widmVyXCI6MS4wLFwibGVuXCI6MTEyLFwiYml0c1wiOlwiLy8vLy8vLy8vLy8vLy8vLy8vOD1cIn0iLDE2NzZdLFsicGVybS5GbGlwRmxvcCIsIntcInZlclwiOjEuMCxcImxlblwiOjM4LFwiYml0c1wiOlwiLy8vLy96OD1cIn0iLDE3MThdLFsicGVybS5pbmZyYS51Y3MiLCJ7XCJ2ZXJcIjoxLjAsXCJsZW5cIjoxMixcImJpdHNcIjpcIi93OD1cIn0iLDE1OTNdLFsicGVybS5QYXltZW50SHViIiwie1widmVyXCI6MS4wLFwibGVuXCI6MzgsXCJiaXRzXCI6XCIvLy8vL3o4PVwifSIsMTY2OV0sWyJwZXJtLnBheW1lbnRzIiwie1widmVyXCI6MS4wLFwibGVuXCI6NCxcImJpdHNcIjpcIkR3PT1cIn0iLDgzMV0sWyJwZXJtLlNwb3J0Ym9vayIsIntcInZlclwiOjEuMCxcImxlblwiOjM1LFwiYml0c1wiOlwiLy8vLy93Yz1cIn0iLDE3MjBdXSwibmJmIjoxNTY4Mjk0MjMxLCJleHAiOjE1OTk4MzAyMzEsImlzcyI6InNzby1iYWNrb2ZmaWNlLnN0YWdlIn0.cPuFurOazr4DKEK0kqwSAl2EfXXIcxWuwPqzMF459iJcKzAZhArw3yMPhwEaANwTrEerlDbLRvZ4V8rI1Our6tl4_T2zjZDfNzWDlTl6ZsV_pt-8thwlHbgDmZad05VuJ8rLqkksXGzUpOqoFZNLmS0cwhDQUH-lstCsZon1ew0ksB5NTmB-YF3idGjs297mzhfmYjELQ2MJylIwSdTAJWZ7xuNaXeLcruIJ33cNJscn29mzOF3U4_Vtf630Glw5fehEnacyQUaidinf5GiJiS6LIwODNSGYmPABqrXBDMXRvbxRxENvv9v0tPhI-FAOT6g2Y_kIFsmria9xU0rV9A");
        }

        public void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public HttpResponseMessage Post(string requestUri, string jsonObject)
        {
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            //
            //var request = new HttpRequestMessage { Content = content, Method = HttpMethod.Post, RequestUri = new Uri(requestUri) };
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");
            //SendAsync(HttpRequestMessage request);
            //
            var result = _client.PostAsync(requestUri, content).GetAwaiter().GetResult();
            return result;
        }

        public HttpResponseMessage Get(string requestUri, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = _client.GetAsync(requestUri).GetAwaiter().GetResult();
            return result;
        }


        //[HttpGet]
        //public async Task<ActionResult<string>> getUseBearerAsync(string token, string baseUrl, string action)
        //{
        //    var callApi = new CallApi(baseUrl);
        //    var client = callApi.getClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //    HttpResponseMessage response = await client.GetAsync(action);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return Ok(await response.Content.ReadAsStringAsync());

        //    }
        //    else
        //        return NotFound();
        //}
    }
}