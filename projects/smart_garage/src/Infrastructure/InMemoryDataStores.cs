using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

namespace SmartGarage.Infrastructure;

public class InMemoryDoorStateStore : IDoorStateStore
{
    private DoorState _state = new(DoorOperationState.Stopped, DoorStopReason.Normal);

    public DoorState Load() => _state;
    public void Save(DoorState state) => _state = state;
}

public class InMemoryLockDeviceStateStore : ILockDeviceStateStore
{
    private LockDeviceState _state = LockDeviceState.Unlocked;

    public LockDeviceState Load() => _state;
    public void Save(LockDeviceState state) => _state = state;
}
