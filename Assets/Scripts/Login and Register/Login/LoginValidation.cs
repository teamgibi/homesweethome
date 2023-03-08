using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class LoginValidation : MonoBehaviour {

    public InputField email;
    public InputField password;
    public GameObject[] canvas;

    public void Start() {
        canvas[0].SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            CheckValidation();
        }
    }

    public void CheckValidation() {
        string mail = email.text;
        string pass = password.text;
        FirebaseFunctions.SignInWithCredentials(mail, pass);
    }

    public void Register() {
        SceneManager.LoadScene("Register Scene");
    }

    public void OnClickGetGoogleCode() {
        GoogleAuthenticator.SignInWithGoogle();
    }
}
