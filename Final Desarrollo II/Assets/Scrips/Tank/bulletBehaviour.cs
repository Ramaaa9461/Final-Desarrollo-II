using UnityEngine;
using UnityEngine.Events;


namespace Game
{

    public class bulletBehaviour : MonoBehaviour
    {
        [SerializeField] float velocity;
        public UnityEvent enemyEliminated;

        private void Start()
        {
            enemyEliminated.AddListener(GameObject.FindObjectOfType<DeadEnemiesAccountant>().addToDeadEnemiesAccountant);
            Destroy(gameObject, 5.0f);
        }

        void Update()
        {
            transform.position += transform.forward * velocity * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //Intancias particulas
                Destroy(collision.gameObject);
                enemyEliminated.Invoke();
            }

            Destroy(gameObject);
        }
    }
}