using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FiguresScript : MonoBehaviour
{
    public ObjectColor color;
    public int clickCount = 0;
    int nextChangeColorClick;
    public float time;
    public string objectName;

    string json;

    // Start is called before the first frame update
    void Start()
    {
        nextChangeColorClick = color.clickCount;
        StartCoroutine(ChangeColor());

        json = File.ReadAllText("Assets/Names.json");
        ClassName name = JsonUtility.FromJson<ClassName>(json);
        objectName = name.Name[Random.Range(0, name.Name.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (clickCount >= nextChangeColorClick)
        {
            ColorChoose();
            nextChangeColorClick += color.clickCount;
        }
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(time);
        ColorChoose();
        StartCoroutine(ChangeColor());
    }

    void ColorChoose()
    {
        this.gameObject.GetComponent<Renderer>().material.color = color.colores[Random.Range(0, color.colores.Length)];
    }

    public class ClassName
    {
        public string[] Name;
    }
}
