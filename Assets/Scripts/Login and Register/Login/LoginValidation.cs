using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

using EasyUI.Dialogs;

public class LoginValidation : MonoBehaviour {

    public InputField email;
    public InputField password;
    public GameObject[] canvas;

    public void Start() {
        canvas[0].SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Login();
        }
    }

    public void Login() {
        string mail = email.text;
        string pass = password.text;
        if(mail == "" || pass == "") {
            Debug.Log("Please fill all the input fields...");
            DialogUI.Instance.SetMessage("Please fill all input fields!").Show();
        }
        else {
            SignInWithCredentials(mail, pass);
        }
    }

    private void SignInWithCredentials(string email, string password) { 
        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance; 
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                DialogUI.Instance.SetMessage("Login cancelled!").Show();
                return;
            }
            if (task.IsFaulted) {
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions) {
                    string authErrorCode = "";
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null) {
                        authErrorCode = String.Format("AuthError.{0}: ",
                        ((Firebase.Auth.AuthError)firebaseEx.ErrorCode).ToString());
                        Debug.Log("SignInWithEmailAndPasswordAsync encountered an error: " + authErrorCode + exception.ToString());
                        DialogUI.Instance.SetMessage(exception.ToString()).Show();
                        return;
                    }
                }
            }
            Firebase.Auth.FirebaseUser user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1} {2})", user.DisplayName, user.UserId, user.IsEmailVerified);
            if (user.IsEmailVerified){
                DialogUI.Instance.SetMessage("Successfully logged in!").Show();
                SceneManager.LoadScene("Apartment Selection Scene");
            } else{
                DialogUI.Instance.SetMessage("Please verify your email address!").Show();
            }
            return;
        });
    }

    public void Register() {
        SceneManager.LoadScene("Register Scene");
    }

    public void Settings() {
        SceneManager.LoadScene("Settings Scene");
    }

    public void OnClickGetGoogleCode() {
        GoogleAuthenticator.SignInWithGoogle();
    }
}
