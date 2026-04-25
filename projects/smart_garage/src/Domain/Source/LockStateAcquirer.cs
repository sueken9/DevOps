namespace SmartGarage.Domain.Source;

using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

// M1: ロック装置状態を取得する（P1対応）
public class LockStateAcquirer
{
    private readonly IInterlockSwitch _interlockSwitch;
    private readonly ILockDeviceStateStore _lockDeviceStateStore;

    public LockStateAcquirer(IInterlockSwitch interlockSwitch, ILockDeviceStateStore lockDeviceStateStore)
    {
        _interlockSwitch = interlockSwitch;
        _lockDeviceStateStore = lockDeviceStateStore;
    }

    /// <summary>
    /// インターロックスイッチの操作許可有無を読み取り、ロック装置状態に変換してD2に保存する。
    /// </summary>
    public LockDeviceState Acquire()
    {
        throw new NotImplementedException();
    }
}
