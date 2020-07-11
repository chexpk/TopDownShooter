using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarScript healthBar;

    public GameObject animationModel;
    Animator animator;

    // Start is called before the first frame update
    void Start () {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);

        animator = animationModel.GetComponent<Animator> ();
    }

    void Update () {
        if (currentHealth <= 0) {
            animator.SetBool ("Died", true);
            Destroy (gameObject, 4f);
        }
    }
    private void OnTriggerEnter (Collider other) {

        if (other.tag == "Enemy") {
            TakeDamage (3);
        }
    }

    public void TakeDamage (int damage) {
        currentHealth -= damage;
        // тут будет анимация получения урона
        healthBar.SetHealth (currentHealth);
    }
}