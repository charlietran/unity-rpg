using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    Camera m_camera;
    PlayerMotor m_motor;

    void Start()
    {
        m_camera = Camera.main;
        m_motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Debug.Log("Hit: " + hit.collider.name + " " + hit.point);
                m_motor.MoveToPoint(hit.point);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check for interactible

            }
        }
    }
}