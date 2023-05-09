using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Siccity.GLTFUtility;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModelLoader : MonoBehaviour
{
    GameObject wrapper;
    string filePath;
    public Button downloadButton;
    public string url;

    private void Start()
    {
        filePath = $"{Application.persistentDataPath}/Files/";
        wrapper = new GameObject
        {
            name = "Model",
            transform = { position = new Vector3(0f, 0f, 0f) }
        };
        downloadButton.onClick.AddListener(OnDownloadButtonClick);
    }

    void OnDownloadButtonClick()
    {
        Debug.Log(this.url);

        this.DownloadFile(this.url);
    }

    public void DownloadFile(string url)
    {
        string path = GetFilePath(url);
        if (File.Exists(path))
        {
            Debug.Log("Found file locally, loading...");
            LoadModel(path);
            return;
        }

        StartCoroutine(GetFileRequest(url, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                // Log any errors that may happen
                Debug.Log($"{req.error} : {req.downloadHandler.text}");
            }
            else
            {
                // Save the model into a new wrapper
                LoadModel(path);
            }
        }));
    }

    string GetFilePath(string url)
    {
        string[] pieces = url.Split('/');
        string filename = pieces[pieces.Length - 1];

        return $"{filePath}{filename}";
    }

    void LoadModel(string path)
    {
        ResetWrapper();
        GameObject model = Importer.LoadFromFile(path);
        model.transform.SetParent(wrapper.transform);
        GameObject origin = GameObject.Find("XR Origin");
        model.transform.position = new Vector3(origin.transform.position.x+2, origin.transform.position.y, origin.transform.position.z);
        model.AddComponent<BoxCollider>();
        model.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
        ModalController modalController = model.AddComponent<ModalController>();

        UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable xrInteraction = model.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();

        xrInteraction.firstHoverEntered.AddListener((UnityEngine.XR.Interaction.Toolkit.HoverEnterEventArgs arg0) => {
            modalController.hoverEnter();
        });
    }

    IEnumerator GetFileRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(url))
        {
            req.downloadHandler = new DownloadHandlerFile(GetFilePath(url));
            yield return req.SendWebRequest();
            callback(req);
        }
    }

    void ResetWrapper()
    {
        if (wrapper != null)
        {
            foreach (Transform trans in wrapper.transform)
            {
                Destroy(trans.gameObject);
            }
        }
    }
}