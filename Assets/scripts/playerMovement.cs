using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed = 3.5f;
    private Rigidbody2D _Rigidbody;

    private void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
    }

}
