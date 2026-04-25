namespace SmartGarage.Domain.Sink;

using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

// M5: 開閉指示を送る（P5対応）
public class OpenCloseCommandSender
{
    private readonly IGarageMotor _garageMotor;
    private readonly IDoorStateStore _doorStateStore;
    private readonly DoorStateNotifier _doorStateNotifier;

    public OpenCloseCommandSender(
        IGarageMotor garageMotor,
        IDoorStateStore doorStateStore,
        DoorStateNotifier doorStateNotifier)
    {
        _garageMotor = garageMotor;
        _doorStateStore = doorStateStore;
        _doorStateNotifier = doorStateNotifier;
    }

    /// <summary>
    /// ガレージ作業指示を開閉指示に変換してモータへ送り、扉状態をD1に保存する。
    /// 完了後にM6（扉状態を通知する）を呼ぶ。
    /// </summary>
    public void Send(GarageWorkInstruction instruction)
    {
        throw new NotImplementedException();
    }
}
