using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Google.MiniJSON;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DynamicListView : MonoBehaviour
{
    public GameObject listItemPrefab;
    public Transform listItemHolder;

    class Product
    {
        public string sku;
        public string product_name;
        public string product_description;
        public string product_page_url;
        public string class_name;
        public decimal sale_price;
        public string thumbnail_image_url;
        public Model model;
    }

    class Model
    {
        public Dimensions dimensions_inches;
        public string glb;
        public string obj;
    }

    class Dimensions
    {
        public decimal x;
        public decimal y;
        public decimal z;
    }

    private void Start()
    {
        StartCoroutine(GetRequest("https://api.wayfair.com/v1/3dapi/models"));     
    }

    IEnumerator GetRequest(string uri)
    {
        string authorization = authenticate("abugraokkali@outlook.com", "6447d9e10da93");

        UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        webRequest.SetRequestHeader("AUTHORIZATION", authorization);

        using (webRequest)
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Product[] products = JsonConvert.DeserializeObject<Product[]>(webRequest.downloadHandler.text);

                    foreach (Product product in products)
                    {
                        if(product.model.glb != null)
                        {
                            GameObject prefab = Instantiate(listItemPrefab, listItemHolder);
                            prefab.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = product.product_name + "\n\n$" + product.sale_price;
                            ModelLoader modelLoader = prefab.GetComponent<ModelLoader>();
                            modelLoader.url = product.model.glb;
                            StartCoroutine(DownloadImage(product.thumbnail_image_url, prefab));
                        }
                    }
                    break;
            }
        }
    }

    IEnumerator DownloadImage(string MediaUrl, GameObject prefab)
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(MediaUrl);
        using (webRequest)
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = MediaUrl.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    prefab.transform.Find("Image").GetComponent<Image>().sprite = Sprite.Create(
                        ((DownloadHandlerTexture)webRequest.downloadHandler).texture,
                        new Rect(0, 0, ((DownloadHandlerTexture)webRequest.downloadHandler).texture.width, ((DownloadHandlerTexture)webRequest.downloadHandler).texture.height),
                        new Vector2(0.5f, 0.5f)
                    );
                    break;
            }
        }

    }

    string authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }
}
