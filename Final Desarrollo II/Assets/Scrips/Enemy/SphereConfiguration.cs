
using UnityEngine;


namespace Game
{
    [CreateAssetMenu(fileName = "SphereConfiguration", menuName = "Enemies")]
    public class SphereConfiguration : ScriptableObject
    {
        public float velocity;
        public float jumpForce;
    }
}