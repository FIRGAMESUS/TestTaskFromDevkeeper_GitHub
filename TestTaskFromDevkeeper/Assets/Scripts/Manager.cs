using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject FullObject;
    private Transform currentObject, anotherObject;
    private int currentIdObject;
    private float step = 0.1f;

    public Text SwitchObjectText, SwitchDirectionText;
    private bool scaleUp;

    void Start()
    {
        currentIdObject = 0;
        SetObject(currentIdObject);
        scaleUp = true;
        SetDirection();
    }

    
    void Update()
    {
        
    }

    public void SwitchObjectButtonPressed()
    {
        currentIdObject = 1 - currentIdObject;
        SetObject(currentIdObject);
    }
    private void SetObject(int id)
    {
        currentObject = FullObject.transform.GetChild(id);
        anotherObject = FullObject.transform.GetChild(1 - id);
        SwitchObjectText.text = "Сейчас выбран Объект №" + (id + 1) + ". Нажмите для выбора другого.";
    }
    public void SwitchDirectionButtonPressed()
    {
        scaleUp = !scaleUp;
        SetDirection();
    }
    private void SetDirection()
    {
        if (scaleUp) SwitchDirectionText.text = "+";
        else  SwitchDirectionText.text = "-";
    }

    public void ScaleObject(int axis)
    {
        //scaleUp: false - minus, true - plus
        //axis: 0 - все оси, 1 - x, 2 - y, 3 - z

        if (scaleUp == true)
        {
            if (axis == 0 || axis == 1)
            {
                currentObject.localScale += new Vector3(step, 0, 0);
            }
            if (axis == 0 || axis == 2)
            {
                currentObject.localScale += new Vector3(0, step, 0);
                if (anotherObject.localPosition.y < currentObject.localPosition.y) anotherObject.localPosition -= new Vector3(0, step / 2, 0);
                else anotherObject.localPosition += new Vector3(0, step / 2, 0);
            }
            if (axis == 0 || axis == 3)
            {
                currentObject.localScale += new Vector3(0, 0, step);
            }
        }
        if (scaleUp == false)
        {
            if (axis == 0 || axis == 1)
            {
                currentObject.localScale -= new Vector3(step, 0, 0);
            }
            if (axis == 0 || axis == 2)
            {
                currentObject.localScale -= new Vector3(0, step, 0);
                if (anotherObject.localPosition.y < currentObject.localPosition.y) anotherObject.localPosition += new Vector3(0, step / 2, 0);
                else anotherObject.localPosition -= new Vector3(0, step / 2, 0);
            }
            if (axis == 0 || axis == 3)
            {
                currentObject.localScale -= new Vector3(0, 0, step);
            }
        }
        
    }
}
