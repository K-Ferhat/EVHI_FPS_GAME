using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Player player;
    public GameObject GFX;
    public int amount = 10;

    public void OnTriggerEnter(Collider other) {
        Debug.Log("+10 health");
        player.GainHealth(amount);
        Destroy(GFX);
    }
}
