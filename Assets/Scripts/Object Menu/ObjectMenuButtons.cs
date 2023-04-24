using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectMenuButtons : MonoBehaviour {

    public Button button;
	public GameObject prefab;

    public GameObject camera;

    void Start () {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick(){
		Instantiate(prefab, new Vector3(camera.transform.position.x+2,camera.transform.position.y,camera.transform.position.z), Quaternion.identity);
	}

}
