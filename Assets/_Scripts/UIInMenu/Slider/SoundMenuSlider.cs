using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenuSlider : SliderAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        slider.value = DataPlayer.GetSound();
    }
    protected override void OnSliderValueChanged(float value)
    {
        DataPlayer.SetSound(value);
    }
}
