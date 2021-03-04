using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour
{
    public int Damage = 1;
    [SerializeField]
    public float Range = 100.5f;
    private float Distance;
    Animator animator;
    public Transform PlayerMelee;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CallAttack();
        }
        if (Input.GetButton("Fire2"))
            CallDefend();
        else
            ResetDefend();
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        animator.SetTrigger("Walk");
    //    }
    //    if (Input.GetKeyUp(KeyCode.LeftShift))
    //        animator.ResetTrigger("Walk");
    }
    void AttackDamage()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerMelee.transform.position, PlayerMelee.transform.TransformDirection(Vector3.forward), out hit))
        {

            Distance = hit.distance;
            if (Distance < Range)
            {
                hit.transform.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
            }

        }
    }
    bool CallAttack()
    {
        animator.SetTrigger("Attack");

        return true;
    }
    void CallDefend()
    {
        animator.SetBool("isGuard", true);
    }
    void ResetDefend()
    {
        animator.SetBool("isGuard", false);
    }

}
