namespace SmartGarage.Domain.Transform;

using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

// MT: ガレージ動作を判断する（P4対応）
public class GarageOperationJudge
{
    private readonly IDoorStateStore _doorStateStore;
    private readonly ILockDeviceStateStore _lockDeviceStateStore;

    public GarageOperationJudge(IDoorStateStore doorStateStore, ILockDeviceStateStore lockDeviceStateStore)
    {
        _doorStateStore = doorStateStore;
        _lockDeviceStateStore = lockDeviceStateStore;
    }

    /// <summary>
    /// ロック状態・開閉モード・緊急停止有無とD1/D2の現在状態から、
    /// ガレージ作業指示（上昇・下降・停止）を決定する。これがシステムの最大抽象点。
    /// </summary>
    public GarageWorkInstruction Judge(
        LockDeviceState lockState,
        OpenCloseMode openCloseMode,
        EmergencyStopStatus emergencyStop)
    {
        throw new NotImplementedException();
    }
}
