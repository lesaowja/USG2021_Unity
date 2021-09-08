using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody rigid;
    

    private float horizontal = 0f;
    private float vertical =0f;
    [Range(2.0f, 10.0f)]
    public float Speed = 3.0f;
    [Range(2.0f, 10.0f)]
    public float CamSpeed = 0.5f;
    void Start()
    {
        if(cam==null)
        cam = GetComponentInChildren<Camera>();
        if(rigid == null)
        {
            rigid = gameObject.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //키보드로 이동
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical"); 
        Vector3 dir = (Vector3.forward * vertical) + (Vector3.right * horizontal);
        transform.Translate(dir.normalized * Time.deltaTime * Speed);


        //마우스로 카메라와 캐릭터 회전
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * CamSpeed * mouseX, Space.World);
        cam.transform.Rotate(Vector3.left * CamSpeed * mouseY);
    }
     void FixedUpdate()
    { 
    }
}
