using SmartGarage.Domain.Models;

namespace SmartGarage.Domain.Ports;

public interface IGarageMotor
{
    void Send(OpenCloseCommand command);
}

public interface ILed
{
    void Illuminate(LightingCommand command);
}

public interface IBuzzer
{
    void Sound(BuzzerCommand command);
}
