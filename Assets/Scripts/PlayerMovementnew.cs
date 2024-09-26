using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovementnew : MonoBehaviour
{
    public float speedPlayer = 7f;
    public GameObject playerCenter;
    public ParticleSystem weaponParticle;  // Add the particle system reference
    public float fireRate = 0.5f;  // Time between shots
    private float nextFireTime = 0f;

    void Update()
    {
        // Player movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 mouseScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionLook = (mouseScreenPos - (Vector2)transform.position).normalized;
        playerCenter.transform.right = directionLook;

        transform.position += new Vector3(moveX * Time.deltaTime, moveY * Time.deltaTime, 0f) * speedPlayer;

        // Fire weapon when the left mouse button is clicked
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            FireWeapon();
        }
    }

    void FireWeapon()
    {
        // Play particle effect
        weaponParticle.Play();

        // Raycast to detect hit (simulate bullet hit)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            // Deal damage if the hit object has an enemy tag
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);  // Deal 10 damage to the enemy
            }
        }
    }
}