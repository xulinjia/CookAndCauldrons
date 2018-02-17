using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseLoading : MonoBehaviour
{
    public Slider slider;
    float sum;
    float value;

    void Update()
    {
        sum += Time.deltaTime;
        value = Mathf.Lerp(0, 1, sum/5);
        slider.value = value;
    }

}
