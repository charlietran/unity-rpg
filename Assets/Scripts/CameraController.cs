using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float yawSpeed = 10f;


    private float currentZoom = 10f;
    private float currentYaw = 0f;

    private Transform m_transform;

    void OnEnable() {
        m_transform = transform;
    }

    void Update() {
        currentZoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        Vector3 position = target.position;
        m_transform.position = position - offset * currentZoom;
        m_transform.LookAt(position + Vector3.up * pitch);
        m_transform.RotateAround(position, Vector3.up, currentYaw);
    }
}