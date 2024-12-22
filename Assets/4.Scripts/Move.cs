using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2.2f;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * new Vector3(0, 0, 1));
    }
}
