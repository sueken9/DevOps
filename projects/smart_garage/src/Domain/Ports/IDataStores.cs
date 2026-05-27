using SmartGarage.Domain.Models;

namespace SmartGarage.Domain.Ports;

// D1 扉状態
public interface IDoorStateStore
{
    DoorState Load();
    void Save(DoorState state);
}

// D2 ロック装置状態
public interface ILockDeviceStateStore
{
    LockDeviceState Load();
    void Save(LockDeviceState state);
}
