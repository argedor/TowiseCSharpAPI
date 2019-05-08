using System;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace Towise
{
    public class Towise
    {
        private string _appId;
        private string _appKey;
        private Config _config;
        private RestClient _client;

        public Towise(string appId, string appKey)
        {
            _appId = appId;
            _appKey = appKey;
            _config = new Config();
            _client = new RestClient(_config.baseUrl);
        }
        private string checkImage(string image)
        {
            Regex re = new Regex(@"(data:image)");
            Match match = re.Match(image);
            if (match.Success)
            {
                return $@"image_base64={HttpUtility.UrlEncode(image)}";

            }
            return $"image_url={image}";

        }
        private dynamic createRequest(string url, Method method, string data)
        {
            var request = new RestRequest(url, method);

            request.AddHeader("appid", _appId);
            request.AddHeader("appkey", _appKey);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", data, ParameterType.RequestBody);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = _client.Execute(request);
            dynamic content = JsonConvert.DeserializeObject<dynamic>(response.Content);

            return content;
        }

        public dynamic faceDetect(string image)
        {
            dynamic response = createRequest(_config.faceDetect, Method.POST, checkImage(image));
            return response;

        }

        public dynamic bodyDetect(string image)
        {
            dynamic response = createRequest(_config.bodyDetect, Method.POST, checkImage(image));
            return response;

        }

        public dynamic emotionDetect(string image)
        {
            dynamic response = createRequest(_config.emotionDetect, Method.POST, checkImage(image));
            return response;
        }

        public dynamic faceCompare(string image)
        {
            dynamic response = createRequest(_config.faceCompare, Method.POST, checkImage(image));
            return response;
        }

        public dynamic getAllPerson()
        {
            dynamic response = createRequest(_config.persons, Method.GET, null);
            return response;

        }
        public dynamic getPerson(string personId)
        {
            string person = $"?person_id={personId}";
            dynamic response = createRequest(_config.persons + person, Method.GET, null);
            return response;

        }
        public dynamic addPerson(string name)
        {
            string person = $"name={name}";
            dynamic response = createRequest(_config.persons, Method.POST, person);
            return response;

        }
        public dynamic removePerson(string personId)
        {
            string person = $"person_id={personId}";
            dynamic response = createRequest(_config.persons, Method.DELETE, person);
            return response;

        }
        public dynamic getAllFace(string personId)
        {
            string person = $"?person_id={personId}";
            dynamic response = createRequest(_config.faces + person, Method.GET, null);
            return response;

        }
        public dynamic getFace(string faceId)
        {
            string face = $"?face_id={faceId}";
            dynamic response = createRequest(_config.faces + face, Method.GET, null);
            return response;

        }
        public dynamic addFace(string image, string personId, string save)
        {
            string data = $"person_id={personId}&{checkImage(image)}&save_image={save}";
            dynamic response = createRequest(_config.faces, Method.POST, data);
            return response;

        }
        public dynamic removeFace(string faceId)
        {
            string data = $"face_id={faceId}";
            dynamic response = createRequest(_config.faces, Method.DELETE, data);
            return response;

        }

    }
}
