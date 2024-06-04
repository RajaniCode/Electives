#import "AppDelegate+TestAdditions.h"
#import <objc/objc-runtime.h>
#import <GoogleMaps/GoogleMaps.h>

static char mapViewKey;
static char cameraPositionKey;

@implementation AppDelegate (TestAdditions)

- (void)setCameraPositionObject:(GMSCameraPosition *)cameraPositionObject
{
    objc_setAssociatedObject(self, &cameraPositionKey, cameraPositionObject, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)cameraPositionObject
{
    return objc_getAssociatedObject(self, &cameraPositionKey);
}

- (void)setMapView:(GMSMapView *)mapView
{
  objc_setAssociatedObject(self, &mapViewKey, mapView, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (GMSMapView *)mapView
{
  return objc_getAssociatedObject(self, &mapViewKey);
}

@end
 