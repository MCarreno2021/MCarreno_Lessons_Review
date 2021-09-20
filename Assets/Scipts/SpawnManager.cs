using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : NetworkBehaviour
{
    public GameObject[] paths = null;
    
    // Start is called before the first frame update
    public override void OnStartServer()
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
            GameObject tempPath = Instantiate(path);
            NetworkServer.Spawn(tempPath);
        }
    }
}
