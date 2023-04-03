using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject clickedObject;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // ABSTRACTION
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetClickedObject();
        }
        
    }

    public void GetClickedObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            clickedObject = hit.collider.gameObject;
        } else
        {
            clickedObject = null;
        }
        Debug.Log(clickedObject);
    }
}
