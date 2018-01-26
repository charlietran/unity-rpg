using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public Interactible focus;

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
                m_motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactible interactible = hit.collider.GetComponent<Interactible>();
                if (interactible != null)
                    SetFocus(interactible);
            }
        }
    }

    void SetFocus(Interactible newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            m_motor.FollowTarget(newFocus);
        }
        focus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        m_motor.StopFollowing();
    }
}