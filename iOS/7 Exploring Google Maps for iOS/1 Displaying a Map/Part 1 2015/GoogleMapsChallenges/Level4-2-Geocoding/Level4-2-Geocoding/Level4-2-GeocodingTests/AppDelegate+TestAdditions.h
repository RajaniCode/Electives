#import "AppDelegate.h"
#import <GoogleMaps/GoogleMaps.h>

@class GMSCameraPosition;

@interface AppDelegate (TestAdditions)

@property (strong, nonatomic) NSArray *markers;

@property (strong, nonatomic) NSNumber *geocoderCalled;
@property (strong, nonatomic) NSNumber *reverseGeocodeCalled;
@property (strong, nonatomic) NSNumber *latCoordinate;
@property (strong, nonatomic) NSNumber *lngCoordinate;

@property (strong, nonatomic) GMSGeocoder *theGeocoder;
@property (strong, nonatomic) NSArray *geocodeResults;

@end
