using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ProducerBackToLogin : MonoBehaviour {
    public void BackToLoginScene() {
        SceneManager.LoadScene("Lobby");
    }
}
