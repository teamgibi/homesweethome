using Proyecto26;
using UnityEngine;
using Firebase;
using Firebase.Auth;

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

    public static void FirebaseSDKSignUpWithCredentials()
    {   
        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        var email = "fatugay@email.com";
        var password = "abcdefgh";
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            return;
        }

        // Firebase user has been created.
        Firebase.Auth.FirebaseUser newUser = task.Result;
        Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
        });
    }
}

