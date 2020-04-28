using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Camera mainCamera;

    public GameObject[] figures;

    public Text objectNameText, clickCountText;

    
    void Start()
    {
        objectNameText.text = "";
        clickCountText.text = "";
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Ground")
                {
                    Vector3 spawnPos = new Vector3(hit.point.x, hit.point.y + 3, hit.point.z);
                    int figureNumber = Random.Range(0, figures.Length);
                    Instantiate(figures[figureNumber], spawnPos, Quaternion.identity);
                }

                if (hit.transform.tag == "Figure")
                {
                    hit.transform.GetComponent<FiguresScript>().clickCount += 1;
                    objectNameText.text = "Object name: " + hit.transform.GetComponent<FiguresScript>().objectName;
                    clickCountText.text = "Object clicks count: " + hit.transform.GetComponent<FiguresScript>().clickCount;
                }
            }
            
        }
    }

    
}
