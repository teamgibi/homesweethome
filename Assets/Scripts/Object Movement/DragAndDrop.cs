using UnityEngine;
using System;
public class DragAndDrop : MonoBehaviour {

    private GameObject[] ground;
    private GameObject selectedObject;
    private float x_size;
    private float y_size;
    private float z_size;
    private float lockPos = 0;

    void Awake(){
        ground = GameObject.FindGameObjectsWithTag("ObjectMovementGround");
    }

    private void Update() {
        ground[0].transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
        ground[0].transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.y, lockPos, lockPos);
        ground[0].transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.z, lockPos, lockPos);
        if (selectedObject != ground[0]){
            if (Input.GetMouseButtonDown(0)) {
                if(selectedObject == null) {
                    RaycastHit hit = CastRay();
                    if(hit.collider != null) {
                        selectedObject = hit.collider.gameObject;
                        Cursor.visible = false;
                        x_size=selectedObject.GetComponent<Renderer>().bounds.size.x;
                        y_size=selectedObject.GetComponent<Renderer>().bounds.size.y;
                        z_size=selectedObject.GetComponent<Renderer>().bounds.size.z;
                    }
                } else {
                    Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                    selectedObject.transform.position = new Vector3(((int)Math.Round(worldPosition.x/x_size))*((int)Math.Round(x_size, 0)), -3f, ((int)Math.Round((worldPosition.z/z_size)*z_size,0)));
                    selectedObject = null;
                    Cursor.visible = true;
                }
            }

            if(selectedObject != null && selectedObject != ground[0]) {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position =new Vector3(((int)Math.Round(worldPosition.x/x_size))*((int)Math.Round(x_size, 0)), -2.75f,((int)Math.Round((worldPosition.z/z_size)*z_size,0)));
                if (Input.GetMouseButtonDown(1)) {
                    selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                        selectedObject.transform.rotation.eulerAngles.x,
                        selectedObject.transform.rotation.eulerAngles.y + 90f,
                        selectedObject.transform.rotation.eulerAngles.z));
                        float temp=z_size;
                        z_size=y_size;
                        y_size=temp;
                }
            }
        }
    }

    private RaycastHit CastRay() {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
