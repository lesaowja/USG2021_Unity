using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayMng : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float HitRange =3f;
    public Vector3 MiddlePoint;

    void Start()
    {
        MiddlePoint = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);  
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(MiddlePoint);

            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, HitRange))
            {
                if(hit.transform.gameObject.name == "FoodTest1")
                {
                    Destroy(hit.transform.gameObject);
                } 
            }
        }
    }
}
