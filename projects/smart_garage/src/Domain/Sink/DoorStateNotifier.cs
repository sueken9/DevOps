using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

namespace SmartGarage.Domain.Sink;

// M6: 扉状態を通知する（P6対応）
public class DoorStateNotifier
{
    private readonly ILed _led;
    private readonly IBuzzer _buzzer;

    public DoorStateNotifier(ILed led, IBuzzer buzzer)
    {
        _led = led;
        _buzzer = buzzer;
    }

    /// <summary>
    /// 扉状態をLEDとブザーで通知する。M5から扉状態を受け取る。
    /// </summary>
    public void Notify(DoorState doorState)
    {
        Illuminate(doorState);
        Sound(doorState);
    }

    /// <summary>M6a: 扉状態に応じた点灯指示をLEDに送る。</summary>
    private void Illuminate(DoorState doorState)
    {
        throw new NotImplementedException();
    }

    /// <summary>M6b: 扉状態に応じた鳴動指示をブザーに送る。</summary>
    private void Sound(DoorState doorState)
    {
        throw new NotImplementedException();
    }
}
