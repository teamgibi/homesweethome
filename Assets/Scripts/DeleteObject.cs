using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteObject : MonoBehaviour
{
    public Button yourButton;
    public GameObject modal;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        Destroy(gameObject);
        modal.SetActive(false);
    }

    public void hoverEnter()
    {
        modal.SetActive(true);
        modal.transform.position = gameObject.transform.position;
        modal.transform.position = new Vector3(modal.transform.position.x, modal.transform.position.y + 1, modal.transform.position.z);
    }

    public void hoverExit()
    {
        modal.SetActive(false);
    }
}
