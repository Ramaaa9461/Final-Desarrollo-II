using UnityEngine;


namespace Game
{

    public class EnemyBehaviour : MonoBehaviour
    {
        public SphereConfiguration sphereConfiguration;
        private MovementType movementType;

        void Awake()
        {
            if (Random.Range(0, 2) == 0)
            {
                movementType = gameObject.AddComponent<FollowMovement>();
            }
            else
            {
                movementType = gameObject.AddComponent<JumpingMovement>();
            }
        }

        void Update()
        {
            movementType.Move();
        }

        public void setMovementType(MovementType MT)
        {
            movementType = MT;
        }
    }
}