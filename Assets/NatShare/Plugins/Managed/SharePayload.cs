/* 
*   NatShare
*   Copyright (c) 2019 Yusuf Olokoba.
*/

namespace NatShare {

    using UnityEngine;
    using System.Threading.Tasks;
    using Internal;

    /// <summary>
    /// A payload for sharing to available social services
    /// </summary>
    [Doc(@"SharePayload")]
    public sealed class SharePayload : ISharePayload {

        #region --Client API--
        /// <summary>
        /// Create a share payload
        /// </summary>
        /// <param name="subject">Optional. Subject attached to the sharing payload</param>
        [Doc(@"SharePayloadCtor")]
        public SharePayload (string subject = null) {
            switch (Application.platform) {
                case RuntimePlatform.Android:
                    this.payload = new PayloadAndroid(callback => new AndroidJavaObject(@"api.natsuite.natshare.SharePayload", subject ?? "", callback));
                    break;
                case RuntimePlatform.IPhonePlayer:
                    this.payload = new PayloadiOS((callback, context) => PayloadBridge.CreateSharePayload(subject, callback, context));
                    break;
                default:
                    Debug.LogError("NatShare Error: SharePayload is not supported on this platform");
                    this.payload = null; // Self-destruct >:D
                    break;
            }
        }

        /// <summary>
        /// Add plain text
        /// </summary>
        [Doc(@"AddText")]
        public void AddText (string text) => payload.AddText(text);

        /// <summary>
        /// Add an image to the payload
        /// </summary>
        /// <param name="image">Image</param>
        [Doc(@"AddImage")]
        public void AddImage (Texture2D image) => payload.AddImage(image);

        /// <summary>
        /// Add media to the payload
        /// </summary>
        /// <param name="path">Path to local media file to be shared</param>
        [Doc(@"AddMedia")]
        public void AddMedia (string path) => payload.AddMedia(path);

        /// <summary>
        /// Commit the payload and return whether payload was successfully shared
        /// </summary>
        [Doc(@"Commit")]
        public Task<bool> Commit () => payload.Commit();
        #endregion

        private readonly ISharePayload payload;
    }
}