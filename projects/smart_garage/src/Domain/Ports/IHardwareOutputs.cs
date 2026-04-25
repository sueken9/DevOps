namespace SmartGarage.Domain.Ports;

using SmartGarage.Domain.Models;

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
