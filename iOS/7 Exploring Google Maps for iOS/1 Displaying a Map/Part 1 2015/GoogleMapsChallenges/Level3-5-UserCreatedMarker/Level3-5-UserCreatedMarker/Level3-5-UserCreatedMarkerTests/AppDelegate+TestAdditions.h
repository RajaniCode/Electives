#import "AppDelegate.h"

@class TruckMarker;
@class GMSCameraUpdate;

@interface AppDelegate (TestAdditions)

@property (strong, nonatomic) NSArray *markers;
@property (strong, nonatomic) NSNumber *callCount;
@property (strong, nonatomic) NSNumber *nilCount;
@property (strong, nonatomic) NSArray *userMarkers;
@property (strong, nonatomic) NSNumber *camUpdateLat;
@property (strong, nonatomic) NSNumber *camUpdateLng;
@property (strong, nonatomic) NSNumber *animateWithCameraUpdateCalled;
@property (strong, nonatomic) GMSCameraUpdate *moveCameraArg;

@end
