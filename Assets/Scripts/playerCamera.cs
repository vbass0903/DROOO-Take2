using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Camera))]
public class playerCamera : MonoBehaviour
{
    public GameObject[] players;
    public Vector3 offset;
    private Vector3 velocity;
    public float smoothTime = 0.5f;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 10f;
    public float minY = 2.2f;
    public float maxY = 13f;

    private Camera cam;
    private Scene scene;
    private string scene_name;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        cam = GetComponent<Camera>();
        scene = SceneManager.GetActiveScene();
        scene_name = scene.name;
    }

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
    }


    void LateUpdate()
    {
        if (players.Length == 0)
        {
            return;
        }

        Move();
        Zoom();
        switch (scene_name) {
            case "SampleScene":
                if (cam.transform.position.y >= 13)
                {
                    cam.transform.position = new Vector3(cam.transform.position.x, 13f, cam.transform.position.z);
                }
                if (cam.transform.position.y <= 2.2)
                {
                    cam.transform.position = new Vector3(cam.transform.position.x, 2.2f, cam.transform.position.z);
                }break;
            case "BossScene":
                if (cam.transform.position.y >= 46f)
                {
                    cam.transform.position = new Vector3(cam.transform.position.x, 46f, cam.transform.position.z);
                }
                if (cam.transform.position.y <= -33f)
                {
                    cam.transform.position = new Vector3(cam.transform.position.x, -33f, cam.transform.position.z);
                }break;
            case "Tutorial1":
                if (cam.transform.position.y >= 30f)
                {
                    cam.transform.position = new Vector3(cam.transform.position.x, 30f, cam.transform.position.z);
                }
                if (cam.transform.position.y <= -34f)
                {
                    cam.transform.position = new Vector3(cam.transform.position.x, -34f, cam.transform.position.z);
                }break;
        }
    }

    void Move()
    {
        offset = new Vector3(0f, 0f, -10f);
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPoint = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPoint, ref velocity, smoothTime);
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }

    Vector3 GetCenterPoint()
    {
        if (players.Length == 1)
        {
            return players[0].transform.position;
        }

        var bounds = new Bounds(players[0].transform.position, Vector3.zero);
        for (int i = 0; i < players.Length; i++)
        {
            bounds.Encapsulate(players[i].transform.position);
        }

        return bounds.center;
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);
        for (int i = 0; i < players.Length; i++)
        {
            bounds.Encapsulate(players[i].transform.position);
        }

        return Mathf.Max(bounds.size.x, bounds.size.y);
    }
}
