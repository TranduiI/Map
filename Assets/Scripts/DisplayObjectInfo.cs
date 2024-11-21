using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class DisplayObjectInfo : MonoBehaviour
{
    [SerializeField] private int size = 90;
    public TMP_Text _textInfo;
    public Camera droneCamera; 
    private Ray ray; 
    private RaycastHit hit; 

    public void Update()
    {
        ray = droneCamera.ScreenPointToRay(Input.mousePosition); 

        if (Physics.Raycast(ray, out hit))
        {
            DisplayInfo(hit.collider.gameObject);
        }
        else
        {
            _textInfo.text = ""; 
        }
    }

    public void DisplayInfo(GameObject obj)
    {
        string filePath = null;
        
        if (obj.CompareTag("Ship"))
        {
            filePath = Path.Combine(Application.streamingAssetsPath, $"Info/ship"+obj.GetComponent<ObjectController>().id+".txt");
            
        }
        else if (obj.CompareTag("Base"))
        {
            filePath = Path.Combine(Application.streamingAssetsPath, "Info/base"+ obj.GetComponent<ObjectController>().id+".txt");
            
        }
        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);
            string coordinates = $"X: {obj.transform.position.x:F2}\nY: {obj.transform.position.y:F2}\nZ: {obj.transform.position.z:F2}";
            _textInfo.text = $"{fileContent}\n\n{coordinates}";
            Debug.Log(_textInfo.text);
        }
        else
        {
            _textInfo.text = "";
        }

    }
    
}

