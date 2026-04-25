namespace SmartGarage.App;

using SmartGarage.Domain.Source;
using SmartGarage.Domain.Transform;
using SmartGarage.Domain.Sink;

// M0: スマートガレージ制御（エントリーポイント）
public class SmartGarageController
{
    private readonly OperationStateSource _source;
    private readonly GarageOperationJudge _transform;
    private readonly GarageOperationSink _sink;

    public SmartGarageController(
        OperationStateSource source,
        GarageOperationJudge transform,
        GarageOperationSink sink)
    {
        _source = source;
        _transform = transform;
        _sink = sink;
    }

    /// <summary>
    /// STS構造のメインループ。
    /// Source で入力を収集 → Transform で動作を判断 → Sink で出力を届ける。
    /// </summary>
    public void Run()
    {
        // Source: H/W入力をシステム内部の概念に変換して収集する
        var lockState     = _source.AcquireLockState();
        var openCloseMode = _source.AcquireOpenCloseMode();
        var emergencyStop = _source.DetectEmergencyStop();

        // Transform: 収集した状態からガレージの動作指示を判断する（最大抽象点）
        var instruction = _transform.Judge(lockState, openCloseMode, emergencyStop);

        // Sink: 判断結果をH/W出力として届ける
        _sink.Operate(instruction);
    }
}
