using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    [SerializeField] private int Speed = 2;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 position = new Vector3(transform.position.x - Input.GetAxis("Mouse X") * Speed * Time.deltaTime, transform.position.y, transform.position.z - Input.GetAxis("Mouse Y") * Speed * Time.deltaTime);
            transform.position = position;
        }
    }
}