using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddingObject : MonoBehaviour {
	public Button yourButton;
	public GameObject prefab;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Instantiate(prefab, new Vector3(0,-3f,4), Quaternion.identity);
	}
}