using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class RegisterValidation : MonoBehaviour
{

    public InputField registerMail;
    public InputField registerPassword;
    public InputField confirmPassword;

    public GameObject[] canvas;

    public void Start(){
        canvas[0].SetActive(true);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Return)){
            Register();
        }
    }

    public void Register(){
        // to-do: support login with google authentication api

        string registerEmail = registerMail.text;
        string registerPass = registerPassword.text;
        string confirmPass = confirmPassword.text;

        if(registerEmail == "" || registerPass == "" || confirmPass == ""){
            Debug.Log("Please fill all the input fields...");
        }
        else if (string.Equals(registerPass, confirmPass)){
            Debug.Log("Confirm is done!");
        }else{
            Debug.Log("Password doesn't match!");
        }

    }

    public void BackToLoginScene(){
        SceneManager.LoadScene("Login Scene");
    }

}
