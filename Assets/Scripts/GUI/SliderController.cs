using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public bool actionIsRuning {private set; get;} = false;
    /// <summary>
    /// When true you can override the Value even while a Action is runing.
    /// </summary>
    public bool allowValueOverrideOnAction = false;

    public float Value
    {
        set
        {
            if(!allowValueOverrideOnAction && actionIsRuning)
                return;

            slider.value = value;
        }
        get => slider.value;
    }

    public void KillSliderAction()
    {
        actionIsRuning = false;
    }

    /// <summary>
    /// Fills the slider in a pasivic time
    /// </summary>
    /// <param name="startVal"> 0f-1f</param>
    /// <param name="endVal">0f-1f</param>
    /// <param name="fixTime">Seconds to fill the slider</param>
    public void FillSlider(float startVal, float endVal,float fixTime = 1,float startDelay = 0)
    {
        actionIsRuning = true;
        StartCoroutine(FillAnimation(startVal,endVal,fixTime,startDelay));
    }

    IEnumerator FillAnimation(float startVal, float endVal,float fixTime = 1,float startDelay = 0)
    {
        float plusTime = fixTime / ((endVal - startVal)*100);
        WaitForSeconds wait = new(plusTime);

        if(startDelay != 0)
            yield return new WaitForSeconds(startDelay);


        for(float f = startVal; f < endVal; f+= 0.01f)
        {
            if(!actionIsRuning)
                break;

            if(slider.value >= 1)
                slider.value = 0;

            slider.value += 0.01f;
            yield return wait;

        }
        actionIsRuning = false;
    }
    
}
