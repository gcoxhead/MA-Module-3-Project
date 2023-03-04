using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    Camera _cam;

    [SerializeField]
    LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = _cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Debug.Log(hit.collider.name);
                hit.transform.GetComponent<Renderer>().material.color = Color.red;
            }
        }

    }
}
