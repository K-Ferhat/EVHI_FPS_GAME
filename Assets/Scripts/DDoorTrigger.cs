using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDoorTrigger : MonoBehaviour
{
    public DDoor doubleDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        doubleDoor.OpenDoor();
    }
}
