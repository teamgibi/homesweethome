using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class LoginValidation : MonoBehaviour
{

    public InputField username;
    public InputField password;

    public GameObject[] canvas;

    public void Start(){
        canvas[0].SetActive(true);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Return)){
            CheckValidation();
        }
    }

    public void CheckValidation(){
        string uname = username.text;
        string pass = password.text;

        if (uname == "admin" && pass == "admin"){
            Debug.Log("Succesful Login for Producer:)");
            SceneManager.LoadScene("Producer After Login");  
        }
        else if(uname == "user" || pass == "user"){
            Debug.Log("Succesful Login for Consumer:)");
            SceneManager.LoadScene("Customer After Login");  
        }
        else if(uname == "" || pass == ""){
            Debug.Log("Please fill all the input fields...");
        }
        else {
            Debug.Log("Wrong username or password. Try again...");
        }
    }

    public void GoogleAuthentication(){
        // to-do: support login with google authentication api
        SceneManager.LoadScene("Register Scene");
        Debug.Log("google api");
    }
}
