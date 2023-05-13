using UnityEngine;
using UnityEngine.UI;
using System.Collections;

 public class CameraController : MonoBehaviour
 {
     
    public bool isMainCamera = true; 
    public GameObject MainCamera;
    public GameObject TopCamera;
    public GameObject prefab;
    public GameObject canvas;
    public GameObject eventSystem;

    public void SwitchCamera(){
        if (isMainCamera){
            isMainCamera = false;
            MainCamera.SetActive(false);
            TopCamera.SetActive(true);
        } else {
            isMainCamera = true;
            MainCamera.SetActive(true);
            TopCamera.SetActive(false);
        }
    }

    public void StartXR(){
        MainCamera.SetActive(false);
        GameObject clonePrefab = Instantiate(prefab, new Vector3(0,-3,0), Quaternion.identity);
        clonePrefab.SetActive(true);
        eventSystem.SetActive(false);
        canvas.SetActive(false);
    }
 }