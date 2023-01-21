using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SphereConfiguration", menuName = "Enemies")]
public class SphereConfiguration : ScriptableObject
{
    public float velocity;
    public float jumpForce;
}
