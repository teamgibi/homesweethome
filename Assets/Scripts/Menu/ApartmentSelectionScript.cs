using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ApartmentSelectionScript : MonoBehaviour {

    public GameObject[] canvas;

    public void Start() {
        canvas[0].SetActive(true);
    }

    public void Apartment1(){
        SceneManager.LoadScene("Apartment-1");
    }

    public void Apartment2(){
        SceneManager.LoadScene("Apartment2");
    }

    public void Apartment3(){
        SceneManager.LoadScene("Apartment3");
    }

    public void Apartment4(){
        SceneManager.LoadScene("Lobby");
    }

    public void Logout() {
        SceneManager.LoadScene("Login Scene");
        //bind with the firebase ops.
    }
}
