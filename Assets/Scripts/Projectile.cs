using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 1f;
    void Update()
    {
        transform.position += speed;
    }
}
