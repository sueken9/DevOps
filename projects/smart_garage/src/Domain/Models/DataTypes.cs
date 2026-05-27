namespace SmartGarage.Domain.Models;
// 操作許可有無
public enum OperationPermission { Lock, Release }

// ロック装置状態（D2データストア）
public enum LockDeviceState { Locked, Unlocked }

// 開閉操作
public enum OpenCloseOperation { Open, Close, Pause }

// 開閉モード
public enum OpenCloseMode { Open, Close, Stop }

// 緊急停止操作
public enum EmergencyStopInput { Pressed, NotPressed }

// 緊急停止有無
public enum EmergencyStopStatus { Normal, Emergency }

// ガレージ作業指示
public enum GarageWorkInstruction { Ascend, Descend, Stop }

// 開閉指示
public enum OpenCloseCommand { Open, Close, Stop }

// 表示色
public enum DisplayColor { Red, Green, Blue }

// 点灯パターン
public enum LightingPattern { Off, Blink, Continuous }

// 鳴動指示
public enum BuzzerCommand { Accept, Warning, Melody }

// 扉動作状態
public enum DoorOperationState { Ascending, Descending, Stopped }

// 扉停止理由
public enum DoorStopReason { Normal, Paused, ObjectDetected, EmergencyButton }

// 点灯指示（表示色 ＋ 点灯パターン）
public record LightingCommand(DisplayColor Color, LightingPattern Pattern);

// 扉状態（D1データストア：扉動作状態 ＋ 扉停止理由）
public record DoorState(DoorOperationState OperationState, DoorStopReason StopReason);
