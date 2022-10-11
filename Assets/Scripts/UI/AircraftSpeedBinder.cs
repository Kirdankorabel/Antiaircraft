using UnityEngine;
using UnityEngine.UI;

public class AircraftSpeedBinder : MonoBehaviour
{
    [SerializeField] private Slider maxSpeedSlider;
    [SerializeField] private Slider minSpeedSlider;

    void Start()
    {
        maxSpeedSlider.onValueChanged.AddListener((value) => minSpeedSlider.maxValue = value - 0.01f);
        minSpeedSlider.onValueChanged.AddListener((value) => maxSpeedSlider.minValue = value);
    }
}