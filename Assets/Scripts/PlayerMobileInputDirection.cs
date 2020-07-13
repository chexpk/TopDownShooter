using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInputDirection : MonoBehaviour {

    private CharacterController m_charCont;

    float m_horizontal;
    float m_vertical;

    //тест joystick pack
    public Joystick joystickDirection;

    private Vector3 currentPosition;

    void Start () {
        m_charCont = GetComponent<CharacterController> ();

    }

    // Update is called once per frame
    void FixedUpdate () {
        RotatePlayer ();
    }

    void RotatePlayer () {
        m_horizontal = joystickDirection.Horizontal;
        m_vertical = joystickDirection.Vertical;

        // Direction pointing to
        Vector3 newPosition = new Vector3 (m_horizontal, 0, m_vertical);

        // Get the current position of object
        currentPosition = transform.position;

        // Set the current position plus the position targetting
        Vector3 facePosition = currentPosition + newPosition;

        // Set it 
        transform.LookAt (facePosition);
    }
}