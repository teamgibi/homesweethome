using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class RegisterValidation : MonoBehaviour
{

    public InputField registerUsername;
    public InputField registerPassword;
    public InputField confirmPassword;

    public GameObject[] canvas;

    public void Start(){
        canvas[0].SetActive(true);
    }

    public void Register(){
        // to-do: support login with google authentication api

        string registerUname = registerUsername.text;
        string registerPass = registerPassword.text;
        string confirmPass = confirmPassword.text;

        if (string.Equals(registerPass, confirmPass)){
            Debug.Log("Confirm is done!");
        }else{
            Debug.Log("Password doesn't match!");
        }

    }

    public void BackToLoginScene(){
        SceneManager.LoadScene("Login Scene");
    }

}
