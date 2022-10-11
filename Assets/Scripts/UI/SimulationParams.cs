using System.Collections.Generic;

public static class SimulationParams 
{
    public static readonly float multipler = 50;
    private static Dictionary<string, Parameter> _params = new Dictionary<string, Parameter>();

    public static void AddParam(Parameter parameter)
        => _params.Add(parameter.name, parameter);

    public static Parameter GetParameter(string name)
    {
        if (_params.ContainsKey(name))
            return _params[name];
        throw new System.Exception($"invalid parameter name {name}");
    }
}