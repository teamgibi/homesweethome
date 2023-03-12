using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
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
            FirebaseFunctions fb = new FirebaseFunctions();
            fb.SignUpWithCredentials(registerEmail, registerPass);
        }
    }

    public void BackToLoginScene() {
        SceneManager.LoadScene("Login Scene");
    }
}
