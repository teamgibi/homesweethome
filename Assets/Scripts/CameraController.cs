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

    public void SwitchCamera(){
        if (isMainCamera){
            isMainCamera = false;
            MainCamera.SetActive(false);
            TopCamera.SetActive(true);
            Destroy(prefab);
        } else {
            isMainCamera = true;
            MainCamera.SetActive(true);
            TopCamera.SetActive(false);
            Destroy(prefab);
        }
    }

    public void StartXR(){
        MainCamera.SetActive(false);
        Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
        canvas.SetActive(false);
    }
 }