using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using EasyUI.Dialogs;

public class ApartmentSelectionScript : MonoBehaviour {

    public GameObject[] canvas;

    public void Start() {
        canvas[0].SetActive(true);
    }

    public void Apartment1(){
        //SceneManager.LoadScene("Apt 1 Scene");
        Debug.Log("1");
    }

    public void Apartment2(){
        //SceneManager.LoadScene("Apt 2 Scene");
        Debug.Log("2");
    }

    public void Apartment3(){
        //SceneManager.LoadScene("Apt 3 Scene");
        Debug.Log("3");
    }

    public void Apartment4(){
        //SceneManager.LoadScene("Apt 4 Scene");
        Debug.Log("4");
    }

    public void Logout() {
        SceneManager.LoadScene("Login Scene");
        //bind with the firebase ops.
    }
}
