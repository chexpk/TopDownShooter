using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    GameObject m_player;
    private NavMeshAgent agent;

    // private PlayerHealth playerHealthClass;

    public GameObject animationModel;
    Animator animator;

    float AttackDist = 4f;
    private float distanceToPlayer; // дистанция между игроком и enemy
    private float rotationSpeed = 10f; //скорость поворота к игроку

    [SerializeField]
    private float AttackCooldownTimeMain = 1f; //интервал атаки 
    [SerializeField]
    private float AttackCooldownTime;
    [SerializeField]
    private int ammountDamage = 3;

    private void Awake () {
        m_player = GameObject.Find ("Player");

    }

    // Start is called before the first frame update
    void Start () {
        agent = GetComponent<NavMeshAgent> ();
        animator = animationModel.GetComponent<Animator> ();
        // playerHealthClass = m_player.GetComponent<PlayerHealth> ().TakeDamage (3);
    }

    // Update is called once per frame
    void Update () {
        //
        agent.SetDestination (m_player.transform.position);

        // изменяет перменную, которая отвечает за анимацию в зависимости от скорости 
        animator.SetFloat ("Blend", agent.velocity.magnitude / agent.speed);

        distanceToPlayer = Vector3.Distance (m_player.transform.position, transform.position);

        //вклчение анимации атаки
        if (distanceToPlayer < AttackDist) {
            RotateTowards (m_player.transform);
            animator.SetBool ("isAttack", true);
            // animator.SetTrigger ("Attack");
            Debug.Log ("Attack");
            Attack ();
        } else {
            animator.SetBool ("isAttack", false);
        }

        // Vector3 localPosition = m_player.transform.position - transform.position;
        // localPosition = localPosition.normalized;
        // transform.Translate (localPosition.x * Time.deltaTime * EnemySpeed,
        //     0f,
        //     localPosition.z * Time.deltaTime * EnemySpeed);

        // transform.LookAt (m_player.transform.position);

    }
    //поворот к игроку 
    private void RotateTowards (Transform target) {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.z)); // flattens the vector3
        transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void Attack () {
        if (AttackCooldownTime > 0) {
            AttackCooldownTime -= Time.deltaTime;
        } else {
            AttackCooldownTime = AttackCooldownTimeMain;
            //обращение к методу PlayerHealth
            m_player.GetComponent<PlayerHealth> ().TakeDamage (ammountDamage);
            Debug.Log ("Attack");
        }

    }
}