using System.ComponentModel;

public class Parameter
{
    public readonly string name;
    private float _value;

    public event PropertyChangedEventHandler PropertyChanged;

    public Parameter(string _name)
    {
        name = _name;
    }

    public float Value
    {
        get => _value;
        set
        {
            _value = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
        }
    }
}