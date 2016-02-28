using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Media;
using Skybrud.Social.Instagram.Objects.Pagination;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Instagram.Responses.Media {

    /// <summary>
    /// Class representing the response of a call for getting a list of recent media.
    /// </summary>
    public class InstagramRecentMediaResponse : InstagramResponse<InstagramMediasResponseBody> {

        #region Constructors

        private InstagramRecentMediaResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramMediasResponseBody.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramRecentMediaResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramRecentMediaResponse"/>.</returns>
        public static InstagramRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramRecentMediaResponse(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting a list of recent media.
    /// </summary>
    public class InstagramMediasResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Properties

        /// <summary>
        /// Gets pagination information of the response.
        /// </summary>
        public InstagramIdBasedPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the response body.</param>
        protected InstagramMediasResponseBody(JObject obj) : base(obj) {
            Pagination = obj.GetObject("pagination", InstagramIdBasedPagination.Parse);
            Data = obj.GetArray("data", InstagramMedia.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="InstagramMediasResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramMediasResponseBody"/>.</returns>
        public static InstagramMediasResponseBody Parse(JObject obj) {
            return obj == null ? null : new InstagramMediasResponseBody(obj);
        }

        #endregion

    }

}