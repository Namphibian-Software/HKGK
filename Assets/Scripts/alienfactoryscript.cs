using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienfactoryscript : MonoBehaviour
{
    public GameObject alien;
    // Start is called before the first frame update
    void Start()
    {
        //MakeAlien();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeAlien()
    {
        GameObject al;
        for(int i=0; i < 15; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                al = Instantiate(
                alien,
                new Vector3((i - 7f) * 0.4f, (j - 1f) * 0.6f, 5),
                Quaternion.identity);
            }
        }
    }
}
