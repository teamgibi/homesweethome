﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto26;
using UnityEngine;

public static class GoogleAuthenticator
{
    private const string ClientId = "579803631028-6kv3rl2hl8iknd3btussmelvq83sjjfd.apps.googleusercontent.com";
    private const string ClientSecret = "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";
    private static string RedirectUri = "https://us-central1-autonomous-gist-376319.cloudfunctions.net/saveAuthToken"; 
    private static string GetAuthTokenEndpoint = "https://us-central1-autonomous-gist-376319.cloudfunctions.net/getAuthToken";

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
                ExchangeAuthCodeWithIdToken(response.Text, idToken => {FirebaseFunctions.SignUpWithGoogle(idToken, "google.com");});
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