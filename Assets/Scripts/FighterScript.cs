using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterScript : MonoBehaviour
{

    public Animator Animator;

    public bool BlockCheck = false;
    public int Chooser;

    public float Cooldown = 0.25f;
    private float CooldownTimer;

    private bool Attacking = false;
    private bool Hit = false;

    public Transform PunchCheck;
    public Transform KickCheck;

    public float Range = 1.75f;

    public LayerMask EnemyLayer;
    public float PunchDamage = 2f;
    public float KickDamage = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Attacking && CooldownTimer <= 0) {
            if (Input.GetButtonDown("Fire1")) {
                Punch();
            }
            if (Input.GetButtonDown("Fire2")) {
                Kick();
            }
        }

        if (Attacking) {
            if (CooldownTimer > 0) {
                CooldownTimer -= Time.deltaTime;
            } else {
                Attacking = false;
            }
        }
        if (Input.GetButtonDown("Fire3")) {
            Block();
        }
        if (Input.GetButtonUp("Fire3")) {
            BlockEnd();
        }
    }

    void Punch() {
        Chooser = Random.Range(0, 2);
        if (Chooser == 0) {
            Animator.SetTrigger("Punch1");
        } else {
            Animator.SetTrigger("Punch2");
        }
        Attack(PunchCheck, PunchDamage);
    }

    void Kick() {
        Chooser = Random.Range(0, 2);
        if (Chooser == 0) {
            Animator.SetTrigger("Kick1");
        } else {
            Animator.SetTrigger("Kick2");
        }
        Attack(KickCheck, KickDamage);

    }

    void Block() {
        Animator.SetTrigger("Block");
        Animator.SetBool("Blocking", true);
        BlockCheck = true;
    }

    void BlockEnd() {
        Animator.SetBool("Blocking", false);
        BlockCheck = false;
    }



    void Attack(Transform Check, float Damage) {
        Collider2D[] EnemyHit = Physics2D.OverlapCircleAll(Check.position, Range, EnemyLayer);

        if (EnemyHit != null) {
            foreach(Collider2D Enemy in EnemyHit) {
                if (Hit == false) {
                    if (Enemy.gameObject != this.gameObject) {
                        // Enemy.GetComponent<HealthScript>().TakeDamage(Damage);
                        Debug.Log("Osuma");
                        Hit = true;
                    }
                }
            }
            Hit = false;
        }
        Attacking = true;
        CooldownTimer = Cooldown;
    }


    void OnDrawGizmosSelected() {
        if (PunchCheck == null) {
            return;
        }
        Gizmos.DrawWireSphere(PunchCheck.position, Range);
        Gizmos.DrawWireSphere(KickCheck.position, Range);
    }

}
