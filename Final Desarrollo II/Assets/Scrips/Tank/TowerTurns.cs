using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTurns : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] Transform initialPositionShooting;
    [SerializeField] GameObject bulletPrefab;

    Coroutine turnTower;

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

        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 direction = mouseOnScreen - positionOnScreen;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;

        Quaternion initialRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(new Vector3(0, -angle, 0)) * transform.parent.transform.rotation;

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
