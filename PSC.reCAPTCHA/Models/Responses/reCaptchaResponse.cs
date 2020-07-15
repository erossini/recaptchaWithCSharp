using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSC.reCAPTCHA.Models.Responses
{
    /// <summary>
    /// Class reCaptchaResponse.
    /// </summary>
    public class reCaptchaResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="reCaptchaResponse"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the challenge ts.
        /// </summary>
        /// <value>The challenge ts.</value>
        [JsonProperty("challenge_ts")]
        public string ChallengeTs { get; set; }

        /// <summary>
        /// Gets or sets the hostname.
        /// </summary>
        /// <value>The hostname.</value>
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets the name of the apk package.
        /// </summary>
        /// <value>The name of the apk package.</value>
        [JsonProperty("apk_package_name")]
        public string APKPackageName { get; set; }

        /// <summary>
        /// Gets or sets the error codes.
        /// </summary>
        /// <value>The error codes.</value>
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}