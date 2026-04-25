namespace SmartGarage.Domain.Ports;

using SmartGarage.Domain.Models;

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
