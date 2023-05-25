using Proyecto26;
using UnityEngine;

public static class FirebaseAuthHandler
{
    private const string ApiKey = "<API_KEY>";

    // Unused for now. Manual REST API for Google Authentication, not with Firebase.
    public static void SingInWithToken(string token, string providerId) {
        var payLoad = $"{{\"postBody\":\"id_token={token}&providerId={providerId}\",\"requestUri\":\"http://localhost\",\"returnIdpCredential\":true,\"returnSecureToken\":true}}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={ApiKey}", payLoad)
        .Then(response => {
            Debug.Log(response.Text);
        }).Catch(Debug.Log);    
    }
}
