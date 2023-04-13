using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorController : MonoBehaviour
{

    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        HandleFloorDropdown(dropdown);
    }


    public void HandleFloorDropdown(Dropdown dropdown)
    {
        int index = dropdown.value;
        string floor = dropdown.options[index].text; 
        Debug.Log(floor);
    }
   
}