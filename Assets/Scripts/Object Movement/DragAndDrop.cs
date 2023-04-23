using UnityEngine;
using System;
public class DragAndDrop : MonoBehaviour {

    private GameObject selectedObject;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if(selectedObject == null) {
                RaycastHit hit = CastRay();

                if(hit.collider != null) {
                   

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            } else {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(((int)Math.Round(worldPosition.x/selectedObject.GetComponent<Renderer>().bounds.size.x))*((int)Math.Round(selectedObject.GetComponent<Renderer>().bounds.size.x, 0)), 0f, ((int)Math.Round(worldPosition.z/selectedObject.GetComponent<Renderer>().bounds.size.z))*((int)Math.Round(selectedObject.GetComponent<Renderer>().bounds.size.z, 0)));
                selectedObject = null;
                Cursor.visible = true;
            }
        }

        if(selectedObject != null) {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position =new Vector3(((int)Math.Round(worldPosition.x/selectedObject.GetComponent<Renderer>().bounds.size.x))*((int)Math.Round(selectedObject.GetComponent<Renderer>().bounds.size.x, 0)), .25f,((int)Math.Round(worldPosition.z/selectedObject.GetComponent<Renderer>().bounds.size.z))*((int)Math.Round(selectedObject.GetComponent<Renderer>().bounds.size.z, 0)));
            if (Input.GetMouseButtonDown(1)) {
                selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                    selectedObject.transform.rotation.eulerAngles.x,
                    selectedObject.transform.rotation.eulerAngles.y + 90f,
                    selectedObject.transform.rotation.eulerAngles.z));
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
