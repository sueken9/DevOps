namespace SmartGarage.Infrastructure;

using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

public class GarageMotorAdapter : IGarageMotor
{
    public void Send(OpenCloseCommand command)
    {
        throw new NotImplementedException();
    }
}

public class LedAdapter : ILed
{
    public void Illuminate(LightingCommand command)
    {
        throw new NotImplementedException();
    }
}

public class BuzzerAdapter : IBuzzer
{
    public void Sound(BuzzerCommand command)
    {
        throw new NotImplementedException();
    }
}
