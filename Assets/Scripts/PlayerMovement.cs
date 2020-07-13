using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController m_charCont;

    float m_horizontal;
    float m_vertical;

    //тест joystick pack
    public Joystick joystick;

    public float PlayerSpeed = 0.3f;

    public GameObject animationModel;
    Animator animator;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start () {
        m_charCont = GetComponent<CharacterController> ();

        animator = animationModel.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        // m_horizontal = Input.GetAxis ("Horizontal");
        // m_vertical = Input.GetAxis ("Vertical");
        m_horizontal = joystick.Horizontal;
        m_vertical = joystick.Vertical;

        Vector3 m_playerMovement = new Vector3 (m_horizontal, 0f, m_vertical) * PlayerSpeed;

        m_charCont.Move (m_playerMovement);

        MoveAnimation (m_horizontal, m_vertical);
    }

    private void MoveAnimation (float x, float y) {

        // анимация перемещения персонажа относительно локальных координат (куда смотрит), а не глобальных
        moveDirection = new Vector3 (x, 0, y);

        if (moveDirection.magnitude > 1.0f) {
            moveDirection = moveDirection.normalized;
        }

        moveDirection = transform.InverseTransformDirection (moveDirection);

        animator.SetFloat ("VelX", moveDirection.x);
        animator.SetFloat ("VelY", moveDirection.z);
        // animator.SetFloat ("VelX", moveDirection.x, 0.05f, Time.deltaTime);
        // animator.SetFloat ("VelY", moveDirection.z, 0.05f, Time.deltaTime);
    }
}


