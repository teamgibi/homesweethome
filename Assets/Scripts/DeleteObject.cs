using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteObject : MonoBehaviour
{
    public GameObject modal;
    private GameObject objectToDelete;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = modal.transform.Find("Button").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        Destroy(objectToDelete);
        modal.SetActive(false);
    }

    public void hoverEnter()
    {
        //modal.SetActive(true);


        // Get object bounds
        Bounds objectBounds = gameObject.GetComponent<Renderer>().bounds;

        // Calculate modal position
        Vector3 modalPosition = new Vector3(objectBounds.center.x, objectBounds.max.y -0.1f, objectBounds.center.z);

        // Set modal position
        modal.transform.position = modalPosition;

        // Show modal
        modal.SetActive(true);

        //modal.transform.position = gameObject.transform.position;
        //modal.transform.position = new Vector3(modal.transform.position.x, modal.transform.position.y + 1, modal.transform.position.z);
        objectToDelete = this.gameObject;
    }

    public void hoverExit()
    {
        modal.SetActive(false);
    }
}
