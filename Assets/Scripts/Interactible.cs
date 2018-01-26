using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    bool hasInteracted = false;
    Transform playerTransform;

    private Transform m_transform;

    public virtual void Interact()
    {
        // Meant to be overridden
        Debug.Log("Interacting with " + transform.name);
    }

    void OnEnable()
    {
        m_transform = transform;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(playerTransform.position, interactionTransform.position);
            if (distance <= radius)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocused(Transform _playerTransform)
    {
        isFocus = true;
        playerTransform = _playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        playerTransform = null;
        hasInteracted = false;
    }
}
