using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Models.Tags;

namespace Skybrud.Social.Instagram.Responses.Tags {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given tag.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags</cref>
    /// </see>
    public class InstagramGetTagResponse : InstagramResponse<InstagramTagEnvelope> {

        #region Constructors

        private InstagramGetTagResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, InstagramTagEnvelope.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="InstagramGetTagResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="InstagramGetTagResponse"/>.</returns>
        public static InstagramGetTagResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new InstagramGetTagResponse(response);

        }

        #endregion

    }
}