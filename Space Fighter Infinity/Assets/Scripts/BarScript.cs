using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField] private float fillAmount;
    [SerializeField] private Image content;

    public float MaxVal { get; set; }

    public float Val
    {
        set
        {
            fillAmount = Translate(value, MaxVal);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        if(fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    private float Translate(float val, float max)
    {
        if(val <= max)
        {
            return val / max;
        }
        else
        {
            return 0f;
        }
    }
}
