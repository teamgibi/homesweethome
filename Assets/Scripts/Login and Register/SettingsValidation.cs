using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using EasyUI.Dialogs;

public class SettingsValidation : MonoBehaviour {

    public GameObject[] canvas;

    public void Start() {
        canvas[0].SetActive(true);
    }

    public void BackToLoginScene() {
        SceneManager.LoadScene("Login Scene");
    }
}
