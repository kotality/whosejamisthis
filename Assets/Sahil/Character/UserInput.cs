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
    // Update is called once per frame
    public Transform Maincam;

    void Awake()
    {
        Maincam = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Fire1 = Input.GetButton("Fire1");
        Fire2 = Input.GetButton("Fire2");
        inputVector = GetAxisVector(Vertical, Horizontal, Maincam.forward, Maincam.right, Vector3.up);
    }

    /// <summary>
    /// Gets Two Inputs and maps them on a plane and returns a vector
    /// especially useful in Camera based movement
    /// </summary>
    /// <param name="v">Forward input float</param>
    /// 
    /// <param name="h">Right Input float</param>
    /// 
    /// <param name="forward">The Forward Vector on which axes are mapped</param>
    /// 
    /// <param name="right">The Right Vector on which axes are mapped </param>
    /// 
    /// <param name="planetomap">Plane On Which Axis are mapped</param>
    /// 
    /// <returns>"Vector3"</returns>

    Vector3 GetAxisVector(float v,float h,Vector3 forward, Vector3 right, Vector3 planetomap)
    {
        Vector3 contextualX = forward * v;
        Vector3 contextualY = right * h;
        return Vector3.ProjectOnPlane((contextualX + contextualY).normalized, planetomap).normalized;
    }
}
