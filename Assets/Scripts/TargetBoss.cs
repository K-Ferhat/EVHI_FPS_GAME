using UnityEngine;
using UnityEngine.UI;

public class TargetBoss : MonoBehaviour
{
    public Enemy enemy;
    public int health = 100;
    public Slider slider;

    public void TakeDamage (int amount){
        health -= amount;
        slider.value = health;
        if (health <= 0){
            Die();
        }
    }

    void Die (){
        enemy.Die();
    }
}
