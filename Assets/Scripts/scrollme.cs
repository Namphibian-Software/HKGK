using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollme : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    

    void Update()
    {
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, scrollSpeed * Time.time));
        //renderer.material.SetTextureOffset(
        //"_MainTex",
        //Vector2(0, scrollSpeed * Time.time)
        //);
    }
}
