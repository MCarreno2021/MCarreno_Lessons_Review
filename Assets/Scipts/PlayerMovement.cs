using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerMovement : NetworkBehaviour
{
    private Rigidbody rigbody;
    private Vector3 direction = Vector3.zero;
    public float speed = 20.0f;
    public GameObject[] spawnPoints = null;
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        rigbody = GetComponent<Rigidbody>();
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        
    }
   
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");
        direction = new Vector3(hmove, 0, vmove);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, direction * 10);
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, rigbody.velocity * 5);
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        rigbody.AddForce(direction * speed, ForceMode.Force);

        if(transform.position.z > 40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,40);
        }
        else if (transform.position.z < -40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        }
    }
    private void Respawn()
    {
        int index = 0;
        while(Physics.CheckBox(spawnPoints[index].transform.position, new Vector3(1.5f, 1.5f, 1.5f)))
        {
            index++;
        }
        
        rigbody.MovePosition(spawnPoints[index].transform.position);
        rigbody.velocity = Vector3.zero;
    }
 
    

    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }
    }

}

