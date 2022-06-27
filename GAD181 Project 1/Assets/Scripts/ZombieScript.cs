using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player")
        {
            animator.SetBool("attack", true);
        }
        animator.SetBool("attack", false);
    }
}
