using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator anim;
    private Animator attackAnimator;
    public float attackTime;
    public float startTimeAttack;
    //public float atkRange;

    public Transform attackLocation;
    public float attackRange;
    public float attackRadius;
    public LayerMask enemies;
    public bool isAttacking;

    public float swingCooldown = 0.1f;
    private float atkStamp = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        attackAnimator = attackLocation.GetComponent<Animator>();
    }

    void Update()
    {

        if (PauseMenu.GameIsPaused)
            return;


        Vector3 atkCenter = (this.gameObject.transform.position);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((mousePos - atkCenter));
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        direction.Normalize();

        if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
            attackAnimator.SetBool("isAttacking", false);
            attackAnimator.SetInteger("AttackType", 0);
        }





        if (Input.GetMouseButtonDown(0))
        {
            if (!isAttacking && atkStamp < Time.time)
            {
                isAttacking = true;
                atkStamp = Time.time + swingCooldown;
                attackLocation.transform.position = (Vector2)this.transform.position + direction * attackRange;
                attackLocation.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                attackAnimator.SetBool("isAttacking", true);
                attackAnimator.SetInteger("AttackType", 1);
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRadius, enemies);



                for (int i = 0; i < damage.Length; i++)
                {
                    //Destroy(damage[i].gameObject);
                }
            }
            else
            {
                isAttacking = false;
                attackAnimator.SetBool("isAttacking", false);
                attackAnimator.SetInteger("AttackType", 0);
            }
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}













