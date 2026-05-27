using SmartGarage.Domain.Models;
using SmartGarage.Domain.Ports;

namespace SmartGarage.Domain.Source;

// M2: 開閉モードを取得する（P2対応）
public class OpenCloseModeAcquirer
{
    private readonly IOpenCloseButton _openCloseButton;

    public OpenCloseModeAcquirer(IOpenCloseButton openCloseButton)
    {
        _openCloseButton = openCloseButton;
    }

    /// <summary>
    /// 開閉ボタンの押下内容（開閉操作）を読み取り、内部モード（開閉モード）に変換する。
    /// </summary>
    public OpenCloseMode Acquire()
    {
        throw new NotImplementedException();
    }
}
