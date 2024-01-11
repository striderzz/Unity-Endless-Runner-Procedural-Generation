using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
