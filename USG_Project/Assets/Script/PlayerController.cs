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

    [Header("Animator")]
    Animator ani;
    bool IsMove = false;
    bool isRun = false;

    void Start()
    {
        ani = GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetSpeed(5);
            isRun = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetSpeed(3);
            isRun = false;
        }
        if(Input.GetKeyUp(KeyCode.A) ||Input.GetKeyUp(KeyCode.D))
        {
            horizontal = 0;
        } 
        else
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                horizontal = 0;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                horizontal = -1;
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                horizontal = 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            vertical = 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                vertical = 0;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                vertical = 1;
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                vertical = -1;
            }
        }

        if(vertical == 0 && horizontal == 0)
        {
            IsMove = false;
        }
        else 
        { 
            IsMove = true; 
        }
        
    }
     void FixedUpdate()
    {
        //키보드로 이동 
        Vector3 dir = (Vector3.forward * vertical) + (Vector3.right * horizontal);
        transform.Translate(dir.normalized * Time.deltaTime * Speed);


        //마우스로 카메라와 캐릭터 회전
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * CamSpeed * mouseX, Space.World);
        cam.transform.Rotate(Vector3.left * CamSpeed * mouseY);
        ani.SetBool("IsRun", isRun);
        ani.SetBool("IsMove", IsMove);
    }

    void SetSpeed(int _speed)
    {
        Speed = _speed;
    }
}
