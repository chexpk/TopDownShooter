using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {
    GameObject player;

    public GameObject animationModel;
    Animator animator;

    float minAttackAnimDist = 0f, maxAttackAnimDist = 5f;
    private float distance; // дистанция между игроком и enemy

    private void Awake () {
        player = GameObject.Find ("Player");

    }

    // Start is called before the first frame update
    void Start () {
        animator = animationModel.GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update () {
        distance = Vector3.Distance (player.transform.position, transform.position);

        //вклчение анимации атаки
        if (distance > minAttackAnimDist && distance < maxAttackAnimDist) {
            animator.SetBool ("isAttack", true);
            Debug.Log ("Attack");
        } else {
            animator.SetBool ("isAttack", false);
        }
    }
}