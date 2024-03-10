using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject gem;
    public GameObject background;
    public string teleportDestination;
    private void OnCollisionEnter(Collision collision)
    {
        if (gem.activeInHierarchy == false)
        {
            Debug.Log("AYO");
            background.GetComponent<GameManager>().TeleportOpen(teleportDestination);
        }
    }
}
