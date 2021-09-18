using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenMove : MonoBehaviour
{
    Animator ani;
    public bool open= false;
    private void Start()
    {
        ani = GetComponent<Animator>();        
    }
    public void setOven()
    {
        ani.SetBool("IsOpen", open);
    }
}
