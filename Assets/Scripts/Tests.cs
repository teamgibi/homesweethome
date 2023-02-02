using Proyecto26;
using UnityEngine;

public static class Tests
{
    private const string ApiKey = "AIzaSyCpIcpAABw5swuRMiCBcZ1coZe9fpyqy3M";

    public static void SignUpWithCredentials()
    {
        var payLoad = $"{{\"email\":\"fatih@example.com\",\"password\":\"Passw0rd\",\"returnSecureToken\":true}}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}", payLoad).Then(
            response =>
            {
                Debug.Log(response.Text);
            }).Catch(Debug.Log);    
    }
}

