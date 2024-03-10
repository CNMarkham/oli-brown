using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem explosion;

    void Start()
    {
        explosion.Stop();
    }

    void FixedUpdate()
    {
        explosion.transform.position = player.transform.position;
    }

    public void GameOver()
    {
        player.SetActive(false);
        Invoke("Reload", 2);
        explosion.Play();
    }

    void Reload()
    {
        SceneManager.LoadScene(1);
    }
}


