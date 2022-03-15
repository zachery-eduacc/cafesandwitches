using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private Camera cam;
    private int zoomspeed = 20;
    private float cammax = 30f;
    private float cammin = 2f;
    private float zoomlevel;

    void Start()
    {
        cam = Camera.main;
        
    }

    void FixedUpdate()
    {
        offset.z = -10;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        

    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            zoomspeed = 200;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            zoomspeed = 20;
        }
        //controls zoom as well as maximum and minumum orthographic size
        if (Input.mouseScrollDelta.y < 0)
        {
            
            zoomlevel = cam.orthographicSize + zoomspeed;
            
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomlevel, Time.deltaTime * 10);
            if(cam.orthographicSize > cammax)
            {
                cam.orthographicSize = cammax;
            }
            
            
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            
            zoomlevel = cam.orthographicSize - zoomspeed;
            
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomlevel, Time.deltaTime * 10);
            if(cam.orthographicSize < cammin)
            {
                cam.orthographicSize = cammin;
            }
            
        }
        
    }

}
