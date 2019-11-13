using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiple_Target_Camera : MonoBehaviour
{
    public List<Transform> Players;

    public Vector3 Offset;

    public float SmoothTime = .5f;

    Vector3 velocity;

    public float Min_Zoom;
    public float Max_Zoom;

    public float Zoom_Limit;

    private Camera Cam;

    public float Camera_Speed;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    private void Update()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            if (Players[i] == null)
            {
                Players.Remove(Players[i]);
            }
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {

        if(Players.Count == 0)
        {
            return;
        }

        MOve_Cam();
        Zoom();

       
    }

   void MOve_Cam()
    {
        Vector3 Centerpoint = GetCenterPoint();

        Vector3 NewPostiion = Centerpoint + Offset;

        transform.position = Vector3.SmoothDamp(transform.position, NewPostiion, ref velocity, SmoothTime);
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(Max_Zoom, Min_Zoom, Get_Gratest_Distance()/Zoom_Limit);
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, newZoom, Time.deltaTime * Camera_Speed);
     
    }

    float Get_Gratest_Distance()
    {
        var bounds = new Bounds(Players[0].position, Vector3.zero);

        for( int i = 0; i<Players.Count; i++)
        {
            bounds.Encapsulate(Players[i].position);
        }

        if(bounds.size.x > bounds.size.y)
        {
            return bounds.size.x;
        }
        else
        {
            return bounds.size.y;
        }


    }


    Vector3 GetCenterPoint()
    {
        if(Players.Count == 1)
        {
            return Players[0].position;
        }
        var Bounds = new Bounds(Players[0].position,Vector3.zero);

        for (int i = 0; i < Players.Count; i++)
        {
            Bounds.Encapsulate(Players[i].position);
        }

        return Bounds.center;
    }
}
