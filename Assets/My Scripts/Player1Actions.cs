using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Actions : MonoBehaviour
{
    public float JumpSpeed = 0.5f;
    public GameObject Player1;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            Anim.SetTrigger("LightPunch");
        }
        if(Input.GetButtonDown("Fire2")) 
        {
            Anim.SetTrigger("HeavyPunch");
        }
        if(Input.GetButtonDown("Fire3")) 
        {
            Anim.SetTrigger("LightKick");
        }
        if(Input.GetButtonDown("Jump")) 
        {
            Anim.SetTrigger("HeavyKick");
        }
    }

    public void JumUp()
    {
        Player1.transform.Translate(0, JumpSpeed, 0);
    }

    public void FlipUp()
    {
        Player1.transform.Translate(0, JumpSpeed, 0);
        Player1.transform.Translate(0.5f, 0, 0);
    }

    public void FlipBack()
    {
        Player1.transform.Translate(0, JumpSpeed, 0);
        Player1.transform.Translate(-0.5f, 0, 0);
    }
}
