using UnityEngine;
using UnityEngine.UI;

public class OrderBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxOrder(int order)
    {
        slider.maxValue = order;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetOrder(int order)
    {
        slider.value = order;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
