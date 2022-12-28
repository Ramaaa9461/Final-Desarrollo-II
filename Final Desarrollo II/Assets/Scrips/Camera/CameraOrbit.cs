
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [Header("Setting values")]
    [SerializeField] float currentDistance = 10.0f;
    [SerializeField] float minDistance = 4.0f;
    [SerializeField] float maxDistance = 25.0f;
    [Space(10)]
    [SerializeField] Vector2 sensitivity = new Vector2(200.0f, 200.0f);

    [Header("References")]
    [SerializeField] Transform follow;

    new Camera camera;
    Vector2 angle;
    Vector2 nearPlaneSize;

    [SerializeField] LayerMask cameraCollisionLayer;

	void Awake()
	{
        angle = new Vector2(90 * Mathf.Deg2Rad, 0);
        camera = GetComponent<Camera>();
    }

	void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        CalculateNearPlaneSize();
    }

    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");


        if (hor != 0)
        {
            angle.x += hor * Mathf.Deg2Rad * sensitivity.x * Time.deltaTime;
        }

        if (ver != 0)
        {
            angle.y += ver * Mathf.Deg2Rad * sensitivity.y * Time.deltaTime;
            angle.y = Mathf.Clamp(angle.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);
        }

        HandleCameraZoom();
    }

    void LateUpdate()
    {
        Vector3 direction = new Vector3(
            Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
            -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)
            );

        RaycastHit hit;
        float distance = currentDistance;
        Vector3[] points = GetCameraCollisionPoints(direction);

        foreach (Vector3 point in points)
        {
            if (Physics.Raycast(point, direction, out hit, currentDistance, cameraCollisionLayer))
            {
                distance = Mathf.Min((hit.point - follow.position).magnitude, distance);
                //distance = Mathf.Clamp(distance, minDistance, maxDistance);
            }
            Debug.DrawLine(point, transform.position, Color.white);
        }


        transform.position = follow.position + direction * distance;
        //  transform.position = Vector3.Lerp(transform.position, follow.position + direction * distance, .9f);

        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }

    Vector3[] GetCameraCollisionPoints(Vector3 direction)
    {
        Vector3 position = follow.position;
        Vector3 center = position + direction * (camera.nearClipPlane + 0.1f); //Originalmente en .2

        Vector3 right = transform.right * nearPlaneSize.x;
        Vector3 up = transform.up * nearPlaneSize.y;

        Debug.DrawLine(center - right + up, center + right + up, Color.blue);
        Debug.DrawLine(center + right + up, center - right - up, Color.blue);
        Debug.DrawLine(center - right - up, center + right - up, Color.blue);
        Debug.DrawLine(center + right - up, center - right + up, Color.blue);


        return new Vector3[]
        {
            center - right + up,
            center + right + up,
            center - right - up,
            center + right - up
        };
    }

    void CalculateNearPlaneSize()
    {
        float height = Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2) * camera.nearClipPlane;
        float width = height * camera.aspect;

        nearPlaneSize = new Vector2(width, height);
    }

    void HandleCameraZoom()
    {
        //Zoom de la camara segun la rueda del mouse

            if (Input.GetAxis("Mouse ScrollWheel") > 0 && currentDistance > minDistance) //4
            {
               currentDistance -= 1f;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && currentDistance < maxDistance) 
            {
                currentDistance += 1f;
            }
    }
}


//  https://www.youtube.com/watch?v=ffs_dI6gzyQ