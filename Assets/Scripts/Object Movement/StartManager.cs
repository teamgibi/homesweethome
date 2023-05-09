using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Button yourButton;
	public GameObject camera;
    public GameObject XR_device_simulator;
    public GameObject complete_XR_origin_setup;
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	void OnClick(){
		Destroy(camera);
        Instantiate(XR_device_simulator, new Vector3(0,0,0), Quaternion.identity);
        Instantiate(complete_XR_origin_setup, new Vector3(0,0,0), Quaternion.identity);
	}

}