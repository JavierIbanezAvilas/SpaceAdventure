using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerPosition;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    [SerializeField] private float rotX;
    [SerializeField] private float rotY;
    [SerializeField] private float rotZ;
    [SerializeField] private float rotW;
    private Vector3 offset;
    void Start()
    {
        playerPosition = GameObject.Find("T.R.O.N.").transform;
        offset = new Vector3(offsetX,offsetY, offsetZ);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(offsetX, offsetY, offsetZ);
        transform.position = playerPosition.position + offset;
        transform.rotation = new Quaternion(rotX, rotY, rotZ,rotW);
    }
}
