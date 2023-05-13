using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnableDisable : MonoBehaviour
{

    public GameObject gameObject;
	void Start () {
	}
	void OnClick(){
		gameObject.SetActive(true);
	}

}