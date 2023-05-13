using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ApartmentSelectionScript : MonoBehaviour {

    public GameObject[] canvas;

    public void Start() {
    }

    public void Apartment1(){
        SceneManager.LoadScene("Apartment1");
    }

    public void Apartment2(){
        SceneManager.LoadScene("Apartment2");
    }

    public void Apartment3(){
        SceneManager.LoadScene("Apartment3");
    }
}
