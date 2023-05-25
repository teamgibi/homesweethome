using Proyecto26;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using System.Threading.Tasks;

public class FirebaseFunctions {

    public int lastnum = 0;

    /* Unused for now. Manual REST API for Sign Up, not with Firebase.
    private const string ApiKey = "<API_KEY>";
    public void SignUpWithCredentials(string email, string password) {
        var payLoad = $"{{\"email\":\"${email}\",\"password\":\"${password}\",\"returnSecureToken\":true}}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}", payLoad).Then(
            response =>
            {
                Debug.Log(response.Text);
            }).Catch(Debug.Log);    
    }
    */
    
    public void SignUpWithGoogle(string googleIdToken, string googleAccessToken) {
        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Firebase.Auth.Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(googleIdToken, googleAccessToken);
        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }
            
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });
    }
}

