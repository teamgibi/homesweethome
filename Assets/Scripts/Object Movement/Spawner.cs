using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject gameObject;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(gameObject, new Vector3(0,0,4), Quaternion.identity);
        }
    }
}