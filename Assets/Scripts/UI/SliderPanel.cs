using UnityEngine;
using UnityEngine.UI;

public class SliderPanel : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Slider slider;
    [SerializeField] private InputField inputField;

    private Parameter _parameter;

    private void Awake()
    {
        _parameter = new Parameter(_nameText.text);
        _parameter.Value = slider.value;
        SimulationParams.AddParam(_parameter);
        inputField.text = slider.value.ToString();
        slider.onValueChanged.AddListener((value) => inputField.text = value.ToString());
        inputField.onValueChanged.AddListener((fieldValue) => ChangeValue(fieldValue));
    }

    private void ChangeValue(string fieldValue)
    {
        float value;
        var isSuccess = float.TryParse(fieldValue.Replace(".", ","), out value);

        if (!isSuccess)
            return;

        _parameter.Value = value;

        if (value > slider.maxValue)
            value = slider.minValue;
        else if (value < slider.minValue)
            value = slider.minValue;

        slider.value = (float)value;
    }
}
