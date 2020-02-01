using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
  //  public Transform target;
    public bool zoomed;
  public Player castPlayerScript;
    
    Camera cam;
    Vector3 DezoomedPos;


    void Start()
    {
        cam = GetComponent<Camera>();
        DezoomedPos = cam.transform.position;
    }

    void Update()
    {
        if (castPlayerScript.playerBindCamera)
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
