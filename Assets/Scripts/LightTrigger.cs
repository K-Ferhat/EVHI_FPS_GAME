using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light lightBoss;
    public Button button;
    public GameObject enemy;
    public GameObject enemyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        lightBoss.enabled = true;
        button.ButtonPressed();
        enemy.SetActive(true);
        enemyHealthBar.SetActive(true);
    }
}
