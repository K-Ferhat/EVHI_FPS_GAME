using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent navMeshAgent;

    public GameObject Player;

    [SerializeField]
    private Player PlayerScript;

    public float attackDistance = 10f;
    public float followDistance = 20f;

    [Range(0.0f, 1.0f)]
    public float attackProbability = 0.5f;
    [Range(0.0f, 1.0f)]
    public float hitAccuracy = 0.5f;

    public int damagePoints = 5;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.enabled) {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);
            bool shoot = false;
            bool run = false;
            bool follow = (dist < followDistance);

            if (follow) {
                float random = Random.Range(0.0f, 1.0f);
                if (random > (1.0f - attackProbability) && dist < attackDistance) {
                    shoot = true;
                    navMeshAgent.SetDestination(this.transform.position);
                }
                else {
                    navMeshAgent.SetDestination(Player.transform.position);
                    run = true;
                }
            }
            else if (dist < attackDistance) {
                float random = Random.Range(0.0f, 1.0f);
                if (random > (1.0f - attackProbability) && dist < attackDistance) {
                    shoot = true;
                    navMeshAgent.SetDestination(this.transform.position);
                }
            }
            else
                navMeshAgent.SetDestination(this.transform.position);

            animator.SetBool("Shoot", shoot);
            animator.SetBool("Run", run); 

        }
    }

    public void ShootEvent () {
        float random = Random.Range(0.0f, 1.0f);
        

        this.transform.LookAt(Player.transform);
                    
        bool isHit = random > 1.0 - hitAccuracy;

        if (isHit){
            PlayerScript.Hit(damagePoints);
            Player.SendMessage("Damage", damagePoints, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Die (){
        navMeshAgent.enabled = false;

        animator.SetTrigger("Die");

        Destroy(GetComponent<GameObject>(), 10f);
    }
}
