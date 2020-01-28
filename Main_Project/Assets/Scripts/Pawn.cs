using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public Animator anim;
    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();

    }


    public void Move()
    {
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal", Direction.x * speed));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical", direction.y * speed));
    }


}