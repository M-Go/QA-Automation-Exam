using Exam.Models;
using Newtonsoft.Json;

namespace Exam.Utils
{
    public class Localization
    {
        private ApiClient _backoffice;

        public Localization()
        {
            _backoffice = new ApiClient("http://backoffice.kube.private");
            _backoffice.SetToken(TokenManager.GetToken());
        }

        public void SelectLanguage(string language, string user)
        {
            var uri = $"/api/simple-storage-service/api?key=SELECTED_LANGUAGE_KEY_{user}";
            var body = new LanguageRequestModel();
            body.Value = language;
            var jsonBody = JsonConvert.SerializeObject(body);
            var response = _backoffice.Post(uri, jsonBody);
        }
    }
}