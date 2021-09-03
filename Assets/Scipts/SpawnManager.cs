using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] paths = null;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPath", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPath()
    {
        foreach (GameObject path in paths)
        {
            Instantiate(path);

        }
    }
}
