using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Vector3 positionOfCamera;

    public GameObject needsToBeFollow;

    void Start()
    {
        positionOfCamera = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        positionOfCamera = followAnObject(needsToBeFollow);
    }

    private Vector3 followAnObject(GameObject obj)
    {
        Vector3 positionOfObject = obj.transform.position;

        float x = positionOfObject.x;
        float y = positionOfObject.y - 2;
        float z = positionOfObject.z - 2;

        Vector3 cameraPosition = new Vector3(x, y, z);

        return cameraPosition;

    }
}
