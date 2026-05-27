using SmartGarage.Domain.Models;

namespace SmartGarage.Domain.Source;

// MS: 操作状態を取得する（Sourceグループ）
public class OperationStateSource
{
    private readonly LockStateAcquirer _lockStateAcquirer;
    private readonly OpenCloseModeAcquirer _openCloseModeAcquirer;
    private readonly EmergencyStopDetector _emergencyStopDetector;

    public OperationStateSource(
        LockStateAcquirer lockStateAcquirer,
        OpenCloseModeAcquirer openCloseModeAcquirer,
        EmergencyStopDetector emergencyStopDetector)
    {
        _lockStateAcquirer = lockStateAcquirer;
        _openCloseModeAcquirer = openCloseModeAcquirer;
        _emergencyStopDetector = emergencyStopDetector;
    }

    public LockDeviceState AcquireLockState() => _lockStateAcquirer.Acquire();
    public OpenCloseMode AcquireOpenCloseMode() => _openCloseModeAcquirer.Acquire();
    public EmergencyStopStatus DetectEmergencyStop() => _emergencyStopDetector.Detect();
}
