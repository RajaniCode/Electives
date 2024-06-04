#import "AppDelegate.h"
#import <GoogleMaps/GoogleMaps.h>

@class GMSCameraPosition;

@interface AppDelegate (TestAdditions)

@property (strong, nonatomic) NSArray *markers;

@property (strong, nonatomic) NSDictionary *jsonInTests;

@property (strong, nonatomic) NSNumber *directionsViewAppeared;
@property (strong, nonatomic) NSArray *stepsInDirectionsVC;

@end
