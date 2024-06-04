#import "AppDelegate.h"
#import <GoogleMaps/GoogleMaps.h>

@class GMSCameraPosition;

@interface AppDelegate (TestAdditions)

@property (strong, nonatomic) NSArray *markers;

@property (strong, nonatomic) GMSPanorama *panorama;
@property (strong, nonatomic) GMSPanoramaCamera *camera;
@property (strong, nonatomic) GMSPanoramaView *panoramaView;

@end
