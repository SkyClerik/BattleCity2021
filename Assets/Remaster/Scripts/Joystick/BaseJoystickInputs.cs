using UnityEngine;

public class BaseJoystickInputs
{
    private bool _lastInputAxisState;
    private string _axisName;

    public BaseJoystickInputs(string axisName)
    {
        _axisName = axisName;
    }

    public bool GetInputDown()
    {
        var currentInputValue = Input.GetAxis(_axisName) != 0f;

        if (currentInputValue && _lastInputAxisState)
        {
            return false;
        }

        _lastInputAxisState = currentInputValue;

        return currentInputValue;
    }
}
