using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalController : MonoBehaviour
{
    public GameObject deleteModal;
    public GameObject colorPickerModal;
    private GameObject selectedObject;
    private FlexibleColorPicker fcp;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = deleteModal.transform.Find("Button").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(deleteObject);

        fcp = colorPickerModal.transform.Find("ColorPicker").gameObject.GetComponent<FlexibleColorPicker>();
        //Button colorChangeBtn = colorPickerModal.transform.Find("ColorPicker").gameObject.transform.Find("ApplyButton").gameObject.GetComponent<Button>();

        fcp.onColorChange.AddListener(OnChangeColor);
        //Debug.Log(colorChangeBtn);
    }

    private void deleteObject()
    {
        //Debug.Log(selectedObject);
        Destroy(selectedObject);
        deleteModal.SetActive(false);
    }

    public void hoverEnter()
    {
        selectedObject = this.gameObject;

        // Get object bounds
        Bounds objectBounds = gameObject.GetComponent<Renderer>().bounds;

        // Calculate modal position
        Vector3 modalPosition = new Vector3(objectBounds.center.x, objectBounds.max.y + 1f, objectBounds.center.z);

        // Set modal position
        deleteModal.transform.position = modalPosition;
        colorPickerModal.transform.position = modalPosition;


        // Show modal
        deleteModal.SetActive(true);
        colorPickerModal.SetActive(true);


    }

    public void hoverExit()
    {
        deleteModal.SetActive(false);
        colorPickerModal.SetActive(false);
    }

    private void OnChangeColor(Color co)
    {
        gameObject.GetComponent<Renderer>().material.color = co;
    }

    private void changeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = fcp.color;
    }
}