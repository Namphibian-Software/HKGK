using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ashot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestate.state == gamestate.GameState.PressStart)
        {
            Destroy(gameObject);
        }
        int index = Mathf.FloorToInt(Time.time * 12.0f) % 4;
        Vector2 size = new Vector2(0.25f, 1);
        Vector2 offset = new Vector2(index / 4.0f, 0);
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
        if (Mathf.FloorToInt(Random.value * 10000.0f) % 2000 == 0)
        {
            Instantiate(
            ashot,
            new Vector3(transform.position.x, transform.position.y, 5),
            Quaternion.identity
            );
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shot")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoring.score += 10;
        }
    }
}

