using SmartGarage.App;
using SmartGarage.Domain.Sink;
using SmartGarage.Domain.Source;
using SmartGarage.Domain.Transform;
using SmartGarage.Infrastructure;

// Infrastructure（H/Wアダプター）
var interlockSwitch   = new InterlockSwitchAdapter();
var openCloseButton   = new OpenCloseButtonAdapter();
var emergencyButton   = new EmergencyButtonAdapter();
var ultrasonicSensor  = new UltrasonicSensorAdapter();
var garageMotor       = new GarageMotorAdapter();
var led               = new LedAdapter();
var buzzer            = new BuzzerAdapter();

// Infrastructure（データストア）
var doorStateStore      = new InMemoryDoorStateStore();
var lockDeviceStateStore = new InMemoryLockDeviceStateStore();

// Domain - Source
var lockStateAcquirer      = new LockStateAcquirer(interlockSwitch, lockDeviceStateStore);
var openCloseModeAcquirer  = new OpenCloseModeAcquirer(openCloseButton);
var emergencyStopDetector  = new EmergencyStopDetector(emergencyButton, ultrasonicSensor);
var source                 = new OperationStateSource(lockStateAcquirer, openCloseModeAcquirer, emergencyStopDetector);

// Domain - Transform
var transform = new GarageOperationJudge(doorStateStore, lockDeviceStateStore);

// Domain - Sink
var doorStateNotifier      = new DoorStateNotifier(led, buzzer);
var openCloseCommandSender = new OpenCloseCommandSender(garageMotor, doorStateStore, doorStateNotifier);
var sink                   = new GarageOperationSink(openCloseCommandSender);

// M0: 起動
var controller = new SmartGarageController(source, transform, sink);
controller.Run();
