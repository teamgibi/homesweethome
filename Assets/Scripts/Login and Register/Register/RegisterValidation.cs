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

public class RegisterValidation : MonoBehaviour {

    public InputField registerMail;
    public InputField registerPassword;
    public InputField confirmPassword;
    public GameObject[] canvas;

    public void Start() {
        canvas[0].SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Register();
        }
    }

    public void Register(){

        string registerEmail = registerMail.text;
        string registerPass = registerPassword.text;
        string confirmPass = confirmPassword.text;

        if(registerEmail == "" || registerPass == "" || confirmPass == "") {
            Debug.Log("Please fill all the input fields...");
            DialogUI.Instance.SetMessage("Please fill all input fields!").Show();
        }
        else if (!string.Equals(registerPass, confirmPass)) {
            Debug.Log("Password doesn't match!");
            DialogUI.Instance.SetMessage("Passwords doesn't match!").Show();
        }
        else {
            SignUpWithCredentials(registerEmail, registerPass);
        }
    }

    private void SignUpWithCredentials(string email, string password) {
        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance; 
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                DialogUI.Instance.SetMessage("Register cancelled!").Show();
                return;
            }
            if (task.IsFaulted) {
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions) {
                    string authErrorCode = "";
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null) {
                        authErrorCode = String.Format("AuthError.{0}: ", ((Firebase.Auth.AuthError)firebaseEx.ErrorCode).ToString());
                        Debug.Log("CreateUserWithEmailAndPasswordAsync encountered an error: " + authErrorCode + exception.ToString());
                        DialogUI.Instance.SetMessage(exception.ToString()).Show();
                        return;
                    }
                }
            }
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
            if (newUser != null) {
                newUser.SendEmailVerificationAsync().ContinueWithOnMainThread(verify => {
                    if (verify.IsCanceled) {
                        Debug.LogError("SendEmailVerificationAsync was canceled.");
                        DialogUI.Instance.SetMessage("Email verification cancelled!").Show();
                        return;
                    }
                    if (verify.IsFaulted) {
                        Debug.LogError("SendEmailVerificationAsync encountered an error: " + verify.Exception);
                        DialogUI.Instance.SetMessage("User successfully registered but verification email can not sent!").Show();
                        return;
                    }
                    Debug.Log("Verification email sent successfully.");
                    DialogUI.Instance.SetMessage("User successfully registered and verification email sent!").Show();
                    SceneManager.LoadScene("Login Scene");
                });
            }
            return;
        });
    }

    public void BackToLoginScene() {
        SceneManager.LoadScene("Login Scene");
    }
}
