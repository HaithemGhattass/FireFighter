using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionwf : MonoBehaviour
{
    // Start is called before the first frame update
 
       private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("SS"))
        {
            Destroy(collision.transform.gameObject);
           
           
        }
    }

}
