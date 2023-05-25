using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto26;
using UnityEngine;

public static class GoogleAuthenticator {
    private const string ClientId = "<CLIENT_ID>";
    private const string ClientSecret = "<CLIENT_SECRET>";
    private static string RedirectUri = "<PROJECT_URL>/saveAuthToken"; 
    private static string GetAuthTokenEndpoint = "<PROJECT_URL>/getAuthToken";

    public static void SignInWithGoogle() {
        var guid = Guid.NewGuid().ToString();
        Application.OpenURL($"https://accounts.google.com/o/oauth2/v2/auth?client_id={ClientId}&redirect_uri={RedirectUri}&response_type=code&scope=email&state={guid}");
        WaitForCode(guid);
    }

    private static void WaitForCode(string guid) {
        RestClient.Request(new RequestHelper{
            Method = "GET",
            Uri = GetAuthTokenEndpoint,
            Params = new Dictionary<string, string>{
                {"state", guid}
            }
        }).Then(async response =>{
            var success = response.Text != "";
            if (success) {
                FirebaseFunctions fb = new FirebaseFunctions();
                ExchangeAuthCodeWithIdToken(response.Text, idToken => {fb.SignUpWithGoogle(idToken, "google.com");});
            }
            else {
                await Task.Delay(3000);
                WaitForCode(guid);
            }
        }).Catch(Debug.Log);
    }
    
    private static void ExchangeAuthCodeWithIdToken(string code, Action<string> callback) {
        RestClient.Request(new RequestHelper{
            Method = "POST",
            Uri = "https://oauth2.googleapis.com/token",
            Params = new Dictionary<string, string> {
                {"code", code},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri},
                {"grant_type", "authorization_code"}
            }
        }).Then(response => {
            var data = StringSerializationAPI.Deserialize(typeof(GoogleIdTokenResponse), response.Text) as GoogleIdTokenResponse;
            callback(data.id_token);
        }).Catch(Debug.Log);
    }
}
