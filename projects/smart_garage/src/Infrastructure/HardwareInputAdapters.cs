using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

namespace SmartGarage.Infrastructure;

public class InterlockSwitchAdapter : IInterlockSwitch
{
    public OperationPermission Read()
    {
        throw new NotImplementedException();
    }
}

public class OpenCloseButtonAdapter : IOpenCloseButton
{
    public OpenCloseOperation Read()
    {
        throw new NotImplementedException();
    }
}

public class EmergencyButtonAdapter : IEmergencyButton
{
    public EmergencyStopInput Read()
    {
        throw new NotImplementedException();
    }
}

public class UltrasonicSensorAdapter : IUltrasonicSensor
{
    public double ReadDistance()
    {
        throw new NotImplementedException();
    }
}
