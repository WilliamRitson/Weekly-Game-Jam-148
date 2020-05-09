using UnityEngine;
using System.Collections;

public class CameraCenter : MonoBehaviour
{

    private Camera followingCamera;

    void Awake()
    {
        followingCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        followingCamera.transform.position = new Vector3(pos.x, pos.y, followingCamera.transform.position.z);
    }

}
