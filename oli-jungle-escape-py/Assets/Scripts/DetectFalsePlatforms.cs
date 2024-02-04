using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    bool hit;
    void Update()
    {
        hit = Physics.Raycast(transform.position, transform.forward, 2f, 1 << 8);
        Debug.DrawRay(transform.position, transform.forward * 2f, Color.red);
        if (hit == true)
        {
            Debug.LogWarning("Be careful!");
        }
        else
        {
            Debug.LogWarning("All clear!");
        }
    }
}
