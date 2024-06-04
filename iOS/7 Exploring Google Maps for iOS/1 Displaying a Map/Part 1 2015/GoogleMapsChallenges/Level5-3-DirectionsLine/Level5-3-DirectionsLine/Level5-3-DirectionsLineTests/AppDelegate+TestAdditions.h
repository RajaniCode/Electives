#import "AppDelegate.h"
#import <GoogleMaps/GoogleMaps.h>

@class GMSCameraPosition;

@interface AppDelegate (TestAdditions)

@property (strong, nonatomic) NSArray *markers;

@property (strong, nonatomic) GMSPolyline *polyline;

@property (strong, nonatomic) void (^blockName)(void);

@end
