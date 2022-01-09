using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targets : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="wall")
        {
            move();
        }
    }

    public void move()
    {

        float z = Random.Range(-10.0f, 10.0f);
        float x = Random.Range(-13.0f, 13.0f);
        transform.position = new Vector3(x, 2.0f, z);

    }
}
