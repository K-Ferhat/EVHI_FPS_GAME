using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor () {
        animator.SetBool("Open", true);
    }

    public void CloseDoor () {
        animator.SetBool("Open", false);
    }
}
