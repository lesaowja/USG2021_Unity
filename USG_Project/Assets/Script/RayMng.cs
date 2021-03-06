using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayMng : MonoBehaviour
{
    [Header("Ray Information")]
    [Range(0.0f, 10.0f)]
    public float HitRange =3f;
    Vector3 MiddlePoint;
    [SerializeField] Camera cam;


    [Header("PickUp Position")]
    public Transform Dest;

    [Header("Seletable Object Renderer")]
    [SerializeField] private GameObject ChileObjects;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string SelectableTag = "Selectable"; 
    [SerializeField] private string SelectableTag2 = "Cutter";
    [SerializeField] private Material defaultMaterial;

    private Transform SelectCheck;
    public bool HaveObject = false;
    public bool HaveCutter = false;
    public bool HavePizza = false;
    void Start()
    {
        MiddlePoint = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);  
    }

    void Update()
    {
        if(SelectCheck != null)
        {
            var selectionRenderer = SelectCheck.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            SelectCheck = null;
        }

        Ray ray = cam.ScreenPointToRay(MiddlePoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, HitRange))
        {
            var selection = hit.transform;
            if(selection.CompareTag(SelectableTag)|| selection.CompareTag(SelectableTag2))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                SelectCheck = selection;
            }
           


            if (Input.GetMouseButtonDown(0))
            {
                if (ChileObjects != null)
                {
                    HaveObject = false;
                    HaveCutter = false;
                    HavePizza = false;
                    ChileObjects.transform.parent = null;
                    ChileObjects.GetComponent<Rigidbody>().useGravity = true;
                    ChileObjects = null;
                }
                else
                {
                    if (hit.transform.CompareTag(SelectableTag))
                    {
                        HaveObject = true;
                        ChileObjects = hit.transform.gameObject;
                        hit.rigidbody.useGravity = false;
                        hit.transform.position = Dest.position;
                        hit.transform.parent = GameObject.Find("PickUpPoition").transform;
                  
                    }
                    if( hit.transform.CompareTag(SelectableTag2))
                    {

                        HaveCutter = true;
                        ChileObjects = hit.transform.gameObject;
                        hit.rigidbody.useGravity = false;
                        hit.transform.position = Dest.position;
                        hit.transform.parent = GameObject.Find("PickUpPoition").transform;
                    }
                    if (hit.transform.CompareTag("Pizza"))
                    {

                        HavePizza = true;
                        ChileObjects = hit.transform.gameObject;
                        hit.rigidbody.useGravity = false;
                        hit.transform.position = Dest.position;
                        hit.transform.parent = GameObject.Find("PickUpPoition").transform;
                    }
                    if (hit.transform.CompareTag("Oven"))
                    {
                        hit.collider.gameObject.GetComponent<OvenMove>().open = !hit.collider.gameObject.GetComponent<OvenMove>().open;
                        hit.collider.gameObject.GetComponent<OvenMove>().setOven();
                    }
                }

              
            }   

        }
            
          
      
        
       
    }
        
    public void DestroyChild()
    {
        Destroy(ChileObjects);
        ChileObjects = null;
    }
}
