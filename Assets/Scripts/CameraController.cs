using UnityEngine;
using UnityEngine.UI;
using System.Collections;

 public class CameraController : MonoBehaviour
 {
     
    public bool isMainCamera = true; 
    public GameObject MainCamera;
    public GameObject TopCamera;
    public GameObject prefab;

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
        Instantiate(prefab, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
    }

 }