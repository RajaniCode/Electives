#import "AppDelegate.h"

@class GMSMapView;
@class GMSCameraPosition;

@interface AppDelegate (TestAdditions)

@property (strong, nonatomic) GMSMapView *mapView;
@property (strong, nonatomic) GMSCameraPosition *cameraPositionObject;

@end
