using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Rotation : MonoBehaviour {
	float rotationSpeed = 1f;
    
    void OnMouseDrag(){
        float X = Input.GetAxis("Mouse X")*rotationSpeed;
        float Y = Input.GetAxis("Mouse Y")*rotationSpeed;
        transform.Rotate(Vector3.down,X);
        transform.Rotate(Vector3.right,Y);
    }
}