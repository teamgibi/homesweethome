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
    public GameObject canvas;
	void Start () {
        XR_device_simulator.SetActive(false);
        complete_XR_origin_setup.SetActive(false);
	}

    void Update(){
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
    }

	void OnClick(){
		Destroy(camera);
        Destroy(canvas);
        XR_device_simulator.SetActive(true);
        complete_XR_origin_setup.SetActive(true);
	}

}