using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItem : MonoBehaviour
{
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

    // Start is called before the first frame update
    void setData(Product p)
    {
        Debug.Log(p);
    }
}
