using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given tag.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags</cref>
    /// </see>
    public class InstagramTagResponse : InstagramResponse<InstagramTagResponseBody> {

        #region Constructors

        private InstagramTagResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramTagResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramTagResponse</code>.</returns>
        public static InstagramTagResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramTagResponse(response) {
                Body = InstagramTagResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting information about a given tag.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags</cref>
    /// </see>
    public class InstagramTagResponseBody : InstagramResponseBody<InstagramTag> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramTagResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramTagResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramTagResponseBody</code>.</returns>
        public static InstagramTagResponseBody Parse(JsonObject obj) {
            return new InstagramTagResponseBody(obj) {
                Data = obj.GetObject("data", InstagramTag.Parse)
            };
        }

        #endregion

    }

}