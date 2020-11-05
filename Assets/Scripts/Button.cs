using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed () {
        animator.SetBool("Pressed", true);
    }

    public void ButtonReleased () {
        animator.SetBool("Pressed", false);
    }
}
