using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorController : MonoBehaviour
{
    public GameObject terrain;

    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
    }


    public void HandleFloorDropdown(Dropdown dropdown)
    {
        int index = dropdown.value;
        terrain.transform.position = new Vector3(terrain.transform.position.x, -3 * index, terrain.transform.position.z);
    }
   
}