namespace SmartGarage.Domain.Sink;

using SmartGarage.Domain.Models;

// MK: ガレージを動作させる（Sinkグループ）
public class GarageOperationSink
{
    private readonly OpenCloseCommandSender _openCloseCommandSender;

    public GarageOperationSink(OpenCloseCommandSender openCloseCommandSender)
    {
        _openCloseCommandSender = openCloseCommandSender;
    }

    public void Operate(GarageWorkInstruction instruction)
        => _openCloseCommandSender.Send(instruction);
}
