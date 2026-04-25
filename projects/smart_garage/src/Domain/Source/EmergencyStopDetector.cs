namespace SmartGarage.Domain.Source;

using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

// M3: 緊急停止有無を取得する（P3対応）
public class EmergencyStopDetector
{
    private readonly IEmergencyButton _emergencyButton;
    private readonly IUltrasonicSensor _ultrasonicSensor;

    public EmergencyStopDetector(IEmergencyButton emergencyButton, IUltrasonicSensor ultrasonicSensor)
    {
        _emergencyButton = emergencyButton;
        _ultrasonicSensor = ultrasonicSensor;
    }

    /// <summary>
    /// 緊急停止ボタンと超音波センサーの2系統を統合し、緊急停止有無を判定する。
    /// </summary>
    public EmergencyStopStatus Detect()
    {
        var buttonInput = ReadEmergencyStopInput();
        var distance    = ReadObjectDistance();
        throw new NotImplementedException();
    }

    /// <summary>M3a: 緊急停止ボタンの押下状態を読み取る。</summary>
    private EmergencyStopInput ReadEmergencyStopInput()
    {
        throw new NotImplementedException();
    }

    /// <summary>M3b: 超音波センサーから物体距離を読み取る。</summary>
    private double ReadObjectDistance()
    {
        throw new NotImplementedException();
    }
}
