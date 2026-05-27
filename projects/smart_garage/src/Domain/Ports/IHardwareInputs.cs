using SmartGarage.Domain.Models;

namespace SmartGarage.Domain.Ports;

public interface IInterlockSwitch
{
    OperationPermission Read();
}

public interface IOpenCloseButton
{
    OpenCloseOperation Read();
}

public interface IEmergencyButton
{
    EmergencyStopInput Read();
}

public interface IUltrasonicSensor
{
    double ReadDistance();
}
