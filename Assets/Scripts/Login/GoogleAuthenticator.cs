using System;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;

/// <summary>
/// Handles calls to the Google provider for authentication
/// </summary>

public static class GoogleAuthenticator
{
    private const string ClientId = "579803631028-oqtmvc82eok4fiig0n3ftflvjod35hip.apps.googleusercontent.com";
    private const string ClientSecret = "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";

    private static string RedirectUri = "urn:ietf:wg:oauth:2.0:oob";

    /// <summary>
    /// Opens a webpage that prompts the user to sign in and copy the auth code 
    /// </summary>
    public static void GetAuthCode()
    {
        Application.OpenURL($"https://accounts.google.com/o/oauth2/v2/auth?client_id={ClientId}&redirect_uri={RedirectUri}&response_type=code&scope=email");
    }
    
    /// <summary>
    /// Exchanges the Auth Code with the user's Id Token
    /// </summary>
    /// <param name="code"> Auth Code </param>
    /// <param name="callback"> What to do after this is successfully executed </param>
    public static void ExchangeAuthCodeWithIdToken(string code, Action<string> callback)
    {
        RestClient.Request(new RequestHelper
        {
            Method = "POST",
            Uri = "https://oauth2.googleapis.com/token",
            Params = new Dictionary<string, string>
            {
                {"code", code},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri},
                {"grant_type","authorization_code"}
            }
            
        }).Then(
            response => {
                var data = StringSerializationAPI.Deserialize(typeof(GoogleIdTokenResponse), response.Text) as GoogleIdTokenResponse;
                callback(data.id_token);
            }).Catch(Debug.Log);
    }
}
