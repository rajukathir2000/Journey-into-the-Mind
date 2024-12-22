using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMove : MonoBehaviour
{
    public GameObject audioMove;

    public void Move()
    {
        audioMove.GetComponent<Move>().enabled = true;
    }
}
