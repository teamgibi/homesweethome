using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModalController : MonoBehaviour
{
    private GameObject deleteModal;
    private GameObject colorPickerModal;

    public bool isColorable;
    private GameObject selectedObject;
    private FlexibleColorPicker fcp;

    // Start is called before the first frame update
    void Start()
    {
        deleteModal = GameObject.Find("CameraOffset").transform.Find("DeleteModal").gameObject;
        colorPickerModal = GameObject.Find("CameraOffset").transform.Find("ColorPickerModal").gameObject;

        Button btn = deleteModal.transform.Find("Button").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(deleteObject);

        if (isColorable) {
            fcp = colorPickerModal.transform.Find("ColorPicker").gameObject.GetComponent<FlexibleColorPicker>();
            //Button colorChangeBtn = colorPickerModal.transform.Find("ColorPicker").gameObject.transform.Find("ApplyButton").gameObject.GetComponent<Button>();

            fcp.onColorChange.AddListener(OnChangeColor);
            //Debug.Log(colorChangeBtn);
        }
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
        // Debug.Log(selectedObject.name);
        // Show modal
        deleteModal.SetActive(true);

        if (isColorable) {
            fcp.startingColor = selectedObject.GetComponent<Renderer>().material.color;
            colorPickerModal.SetActive(true);
        }
    }

    public void hoverExit()
    {
        deleteModal.SetActive(false);
        if (isColorable) {
            colorPickerModal.SetActive(false);
        }
        selectedObject = null;
    }

    private void OnChangeColor(Color co)
    {
        if (selectedObject != null && selectedObject.Equals(this.gameObject)) {
            this.gameObject.GetComponent<Renderer>().material.color = co;
        }
    }
}
