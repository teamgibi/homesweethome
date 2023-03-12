using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClick : MonoBehaviour {
	public Button yourButton;
	public GameObject prefab;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
		Instantiate(prefab, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
	}
}