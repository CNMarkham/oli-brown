using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentPlayerHealth = 150;
    public int enemyDamage = 10;

    public PlayerExplosionParticles particles;

    private Animator playerAnimator;
   
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        particles = GetComponent<PlayerExplosionParticles>();
    }
    
    public void HurtPlayer()
    {
        currentPlayerHealth -= enemyDamage;
        playerAnimator.SetTrigger("Hit");

        if (currentPlayerHealth <= 0)
        {
            particles.Explode();
            Invoke("ReloadScene", 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HitCollider")
        {
            HurtPlayer();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("CyberFu");
    }
}
