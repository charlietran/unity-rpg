using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent m_agent;
    Transform target;
    Transform m_transform;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_transform = transform;
    }

    void Update()
    {
        if (target != null)
        {
            m_agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        m_agent.SetDestination(point);
    }

    public void FollowTarget(Interactible newTarget)
    {
        m_agent.stoppingDistance = newTarget.radius * 0.8f;
        m_agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowing()
    {
        m_agent.stoppingDistance = 0;
        m_agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 heightlessDirection = new Vector3(direction.x, 0f, direction.z);
        Quaternion lookRotation = Quaternion.LookRotation(heightlessDirection);
        m_transform.rotation = Quaternion.Slerp(m_transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
