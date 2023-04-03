using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject clickedObject;

    public GameObject nameEditor;
    public TMP_InputField nameText;

    private string animalName;

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
            Debug.Log(clickedObject);
            if (clickedObject != null && clickedObject.CompareTag("Animal"))
            {
                // animal clicked
                nameEditor.SetActive(true);
                animalName = clickedObject.GetComponent<Animal>().animalName;
                nameText.text = animalName;
            } else if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                // UI clicked
            } else { 
                // animal not clicked
                nameEditor.SetActive(false);
            }
        }
        
    }

    public void GetClickedObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

        if (isOverUI)
        {
            // Hit UI, don't update object
            return;
        } else if (Physics.Raycast(ray, out hit))
        {
            // Hit animal, update object
            clickedObject = hit.collider.gameObject;
        } else
        {
            // Hit non-animal, update object
            clickedObject = null;
        }
    }

    public void UpdateAnimalName()
    {
        clickedObject.GetComponent<Animal>().animalName = nameText.text;
    }
}
