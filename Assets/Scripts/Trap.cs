using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    public float rayCast = 10f;
    public LayerMask whatIsPlayer;
    bool trigered = false;



    void FixedUpdate()
    {
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, rayCast, whatIsPlayer);
        if (ground.collider != null)
            trigered = true;
        if (trigered)
            Triggered();
    }

    void Triggered()
    {
        transform.Translate(Vector3.down * 15f * Time.deltaTime);
    }
}
