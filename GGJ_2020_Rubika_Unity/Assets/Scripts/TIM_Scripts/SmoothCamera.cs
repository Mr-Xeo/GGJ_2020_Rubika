using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    //public float cameraSmooth = 0.125f;
    public bool zoomed;
    private float startingSize = 5;
    private float endSize = 3;
    private float elapsed = 0f;
    private float duration = 0.5f;

    Camera cam;

    /*void Zoom()

    {
        
    }*/
    //(Input.GetButton("Zoom")
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /* Vector2 smoothedPosition = Vector2.Lerp(transform.position, target.position, cameraSmooth);
         transform.position = smoothedPosition;
         transform.LookAt(target);*/
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (zoomed == false)
            StartCoroutine(ZoomCouritine());

            else if (zoomed == true)
            StartCoroutine(DezoomCouritine());
        }
    }

    IEnumerator ZoomCouritine()
    {
        while (cam.orthographicSize > 3)
        {
            cam.orthographicSize -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }

        zoomed = true;
    }

    IEnumerator DezoomCouritine()
    {
        while (cam.orthographicSize < 5)
        {
            cam.orthographicSize += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }

        zoomed = false;
    }
}
