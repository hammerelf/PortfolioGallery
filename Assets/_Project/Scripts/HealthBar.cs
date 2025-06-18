using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider healthSlider;

    private void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    [Button]
    public void TweenHealth(float finalValue, float duration, Ease easeMode)
    {
        healthSlider.DOValue(finalValue, duration).SetEase(easeMode);
    }
}
