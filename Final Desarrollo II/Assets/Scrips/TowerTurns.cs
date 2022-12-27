using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTurns : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnScreen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));        
        }
        

    }


    void Shoot()
    {

    }

    IEnumerator TurnTower()
    {
        yield return null;
        Shoot();
    }
}
