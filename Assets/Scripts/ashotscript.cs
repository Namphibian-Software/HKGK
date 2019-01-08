using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ashotscript : MonoBehaviour
{
    // Start is called before the first frame update
    public float ashotSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, ashotSpeed * Time.deltaTime, 0);
        if (transform.position.y < -8.0)
            Destroy(gameObject);
    }
}
