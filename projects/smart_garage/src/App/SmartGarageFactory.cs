using SmartGarage.Domain.Ports;
using SmartGarage.Domain.Sink;
using SmartGarage.Domain.Source;
using SmartGarage.Domain.Transform;
using SmartGarage.Infrastructure;

namespace SmartGarage.App;

public static class SmartGarageFactory
{
    public static SmartGarageController Create()
    {
        // H/W入力
        var interlockSwitch  = new InterlockSwitchAdapter();
        var openCloseButton  = new OpenCloseButtonAdapter();
        var emergencyButton  = new EmergencyButtonAdapter();
        var ultrasonicSensor = new UltrasonicSensorAdapter();

        // H/W出力
        var garageMotor = new GarageMotorAdapter();
        var led         = new LedAdapter();
        var buzzer      = new BuzzerAdapter();

        // データストア
        var doorStateStore       = new InMemoryDoorStateStore();
        var lockDeviceStateStore = new InMemoryLockDeviceStateStore();

        var source    = CreateSource(interlockSwitch, openCloseButton, emergencyButton, ultrasonicSensor, lockDeviceStateStore);
        var transform = CreateTransform(doorStateStore, lockDeviceStateStore);
        var sink      = CreateSink(garageMotor, led, buzzer, doorStateStore);

        return new SmartGarageController(source, transform, sink);
    }

    private static OperationStateSource CreateSource(
        IInterlockSwitch interlockSwitch,
        IOpenCloseButton openCloseButton,
        IEmergencyButton emergencyButton,
        IUltrasonicSensor ultrasonicSensor,
        ILockDeviceStateStore lockDeviceStateStore)
    {
        var lockStateAcquirer     = new LockStateAcquirer(interlockSwitch, lockDeviceStateStore);
        var openCloseModeAcquirer = new OpenCloseModeAcquirer(openCloseButton);
        var emergencyStopDetector = new EmergencyStopDetector(emergencyButton, ultrasonicSensor);
        return new OperationStateSource(lockStateAcquirer, openCloseModeAcquirer, emergencyStopDetector);
    }

    private static GarageOperationJudge CreateTransform(
        IDoorStateStore doorStateStore,
        ILockDeviceStateStore lockDeviceStateStore)
    {
        return new GarageOperationJudge(doorStateStore, lockDeviceStateStore);
    }

    private static GarageOperationSink CreateSink(
        IGarageMotor garageMotor,
        ILed led,
        IBuzzer buzzer,
        IDoorStateStore doorStateStore)
    {
        var doorStateNotifier      = new DoorStateNotifier(led, buzzer);
        var openCloseCommandSender = new OpenCloseCommandSender(garageMotor, doorStateStore, doorStateNotifier);
        return new GarageOperationSink(openCloseCommandSender);
    }
}
