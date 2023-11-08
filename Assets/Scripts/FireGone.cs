using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGone : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("SS"))
        {
            Destroy(collision.transform.gameObject); // destroy spider
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        }
    }

}
