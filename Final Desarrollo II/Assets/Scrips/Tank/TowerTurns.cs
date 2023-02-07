using System.Collections;
using UnityEngine;


namespace Game
{

    public class TowerTurns : MonoBehaviour
    {
        [SerializeField] float duration;
        [SerializeField] Transform initialPositionShooting;
        [SerializeField] GameObject bulletPrefab;

        Coroutine turnTower;
        Camera cam;

        private void Awake()
        {
            cam = Camera.main;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (turnTower == null)
                {
                    turnTower = StartCoroutine(TurnTower());
                }
            }


        }


        void Shoot()
        {
            Instantiate(bulletPrefab, initialPositionShooting.position, transform.rotation);
        }

        IEnumerator TurnTower()
        {
            float timer = 0;

            Quaternion initialRotation = transform.rotation;
            Quaternion newRotation = cam.transform.rotation;
            newRotation.x = 0;
            newRotation.z = 0;

            while (timer <= duration)
            {
                float interpolationValue = timer / duration;

                transform.rotation = Quaternion.Lerp(initialRotation, newRotation, interpolationValue);


                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            transform.rotation = newRotation;
            turnTower = null;
            Shoot();
        }
    }
}