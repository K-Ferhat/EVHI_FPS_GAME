using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;
    public float hitForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (currentAmmo == -1) {
            currentAmmo = maxAmmo;
        }
    }

    void onEnable () {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading) {
            return;
        }

        if (currentAmmo <= 0) {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Reload") && !isReloading && currentAmmo < maxAmmo) {
            StartCoroutine(Reload());
            return;
        }
        
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        
    }

    void Shoot(){
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null){
                target.TakeDamage(damage);
            }
            else {
                TargetBoss targetBoss = hit.transform.GetComponent<TargetBoss>();
                if (targetBoss != null) {
                    targetBoss.TakeDamage(damage);
                }
            }
        }

        if (hit.rigidbody != null) {
            hit.rigidbody.AddForce(-hit.normal * hitForce);
        }
    }

    IEnumerator Reload () {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
