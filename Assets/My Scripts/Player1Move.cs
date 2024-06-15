using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    private Animator Anim;
    public float WalkSpeed = 0.001f;
    private bool IsJumping = false;
    private AnimatorStateInfo Player1Layer0;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        // Walking left and right
        if(Player1Layer0.IsTag("Motion"))
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                Anim.SetBool("Forward", true);
                transform.Translate(WalkSpeed,0,0);
            }
            if(Input.GetAxis("Horizontal") < 0)
            {
                Anim.SetBool("Backward", true);
                transform.Translate(-WalkSpeed,0,0);
            }
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("Forward", false);
            Anim.SetBool("Backward", false);
        }
        // Jumping and Crouching
        if(Input.GetAxis("Vertical") > 0)
        {
            if(!IsJumping)
            {
                IsJumping = true;
                Anim.SetTrigger("Jump");
                StartCoroutine(JumpPause());
            }
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("Crouch", true);
        }
        if(Input.GetAxis("Vertical") == 0)
        {
            Anim.SetBool("Crouch", false);
        }
    }

    IEnumerator JumpPause()
    {
        yield return new WaitForSeconds(1.0f);
        IsJumping = false;
    }
}
