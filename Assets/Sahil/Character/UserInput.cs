using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    public bool Fire1;
    public bool Fire2;
    public Vector3 inputVector;
    public Transform Maincam;
    CameraController camcom;

    void Awake()
    {
        camcom = FindObjectOfType<CameraController>();
        Maincam = camcom.transform.GetChild(0);
    }

    void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Fire1 = Input.GetButton("Fire1");
        Fire2 = Input.GetButton("Fire2");
        inputVector = GetAxisVector(Vertical, Horizontal, Maincam.forward, Maincam.right, Vector3.up);
    }

    Vector3 GetAxisVector(float v,float h,Vector3 forward, Vector3 right, Vector3 planetomap)
    {
        Vector3 contextualX = forward * v;
        Vector3 contextualY = right * h;
        return Vector3.ProjectOnPlane((contextualX + contextualY).normalized, planetomap).normalized;
    }
}
