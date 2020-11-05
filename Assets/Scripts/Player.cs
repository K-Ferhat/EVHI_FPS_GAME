using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainHealth(int amount) {
        currentHealth += amount;

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage (int amount) {
        currentHealth -= amount;

        if (currentHealth <= 0) {
            healthBar.SetHealth(0);
            Die();
        }
        else
            healthBar.SetHealth(currentHealth);
    }

    private void Die() {
        Debug.Log("Game over, You died..");
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void Hit(int damage) {
        TakeDamage(damage);
    }
}
