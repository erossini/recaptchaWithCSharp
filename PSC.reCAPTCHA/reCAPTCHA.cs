using Newtonsoft.Json;
using PSC.reCAPTCHA.Models.Responses;
using System.Net;
using System.Net.Http;

namespace PSC.reCAPTCHA
{
    /// <summary>
    /// Class reCAPTCHA.
    /// </summary>
    public class reCAPTCHA
    {
        /// <summary>
        /// Google reCAPTCHA API
        /// </summary>
        private const string apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";

        /// <summary>
        /// Determines whether is reCAPTCHA valid
        /// </summary>
        /// <param name="captchaResponse">The captcha response.</param>
        /// <param name="secretKey">The secret key.</param>
        /// <returns><c>true</c> if the reCAPTCHA is valid, otherwise, <c>false</c>.</returns>
        public bool IsReCaptchaValid(string captchaResponse, string secretKey)
        {
            bool rtn = false;
            HttpClient httpClient = new HttpClient();

            var result = httpClient.GetAsync(string.Format(apiUrl, secretKey, captchaResponse)).Result;

            if (result.StatusCode != HttpStatusCode.OK)
                return false;
            else
            {
                string rsl = result.Content.ReadAsStringAsync().Result;
                reCaptchaResponse reCaptchaResponse = JsonConvert.DeserializeObject<reCaptchaResponse>(rsl);

                rtn = reCaptchaResponse.Success;
            }

            return rtn;
        }
    }
}