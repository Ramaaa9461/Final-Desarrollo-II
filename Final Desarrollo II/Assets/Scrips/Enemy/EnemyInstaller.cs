using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class EnemyInstaller : MonoBehaviour
    {

        [SerializeField] Transform player;
        [SerializeField] GameObject enemyPrefab;


        [SerializeField] int numberOfEnemies;
        [SerializeField] float circleRadius;
        Vector3 offSet;

        void Awake()
        {
            GameObject newEnemy;
            float angle = (2 * Mathf.PI) / numberOfEnemies;
            float x, z;
            float y = 1;
            for (int i = 0; i < numberOfEnemies; i++)
            {
                x = Mathf.Cos(angle * i);
                z = Mathf.Sin(angle * i);

                offSet = new Vector3(x * circleRadius, y, z * circleRadius);
                y += 0.25f;

                newEnemy = Instantiate(enemyPrefab, player.position + offSet, Quaternion.identity);


                if (Random.Range(0, 2) == 0)
                {
                     newEnemy.GetComponent<EnemyBehaviour>().setMovementType(newEnemy.AddComponent<FollowMovement>());
                }
                else
                {
                    newEnemy.GetComponent<EnemyBehaviour>().setMovementType(newEnemy.AddComponent<JumpingMovement>());
                }

            }
        }

    }
}