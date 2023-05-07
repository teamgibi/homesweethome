 using UnityEngine;
 
 public class CameraController : MonoBehaviour
 {
     
    public bool isMainCamera = true; 
    public GameObject MainCamera;
    public GameObject TopCamera;

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

 }