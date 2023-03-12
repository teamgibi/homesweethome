using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
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
            FirebaseFunctions fb = new FirebaseFunctions();
            fb.SignInWithCredentials(mail, pass);
            if(fb.lastnum == -1){
                DialogUI.Instance.SetMessage("An error occured when trying to login!").Show();
            }
            else if(fb.lastnum == 1){
                DialogUI.Instance.SetMessage("Successfully logged in!").Show();
            }
            else if(fb.lastnum == 2){
                DialogUI.Instance.SetMessage("Please verify your email address!").Show();
            }
        }
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
