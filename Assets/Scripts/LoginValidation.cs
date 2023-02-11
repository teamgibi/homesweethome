using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class LoginValidation : MonoBehaviour
{

    public InputField email;
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
        string mail = email.text;
        string pass = password.text;

        if (mail == "admin" && pass == "admin"){
            Debug.Log("Succesful Login for Producer:)");
            SceneManager.LoadScene("Producer After Login");  
        }
        else if(mail == "user" || pass == "user"){
            Debug.Log("Succesful Login for Consumer:)");
            SceneManager.LoadScene("Customer After Login");  
        }
        else if(mail == "" || pass == ""){
            Debug.Log("Please fill all the input fields...");
        }
        else {
            Debug.Log("Wrong email or password. Try again...");
        }
    }

    public void Register(){
        SceneManager.LoadScene("Register Scene");
    }
}
