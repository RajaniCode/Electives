#import "AppDelegate+TestAdditions.h"
#import <objc/objc-runtime.h>
#import <GoogleMaps/GoogleMaps.h>

@implementation AppDelegate (TestAdditions)

- (void)setMarkers:(NSArray *)markers
{
    objc_setAssociatedObject(self, @selector(markers), markers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)markers
{
    return objc_getAssociatedObject(self, @selector(markers));
}

- (void)setUserMarkers:(NSArray *)userMarkers
{
  objc_setAssociatedObject(self, @selector(userMarkers), userMarkers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)userMarkers
{
  return objc_getAssociatedObject(self, @selector(userMarkers));
}

- (void)setCallCount:(NSNumber *)callCount
{
  objc_setAssociatedObject(self, @selector(callCount), callCount, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)callCount
{
  return objc_getAssociatedObject(self, @selector(callCount));
}

- (void)setNilCount:(NSNumber *)nilCount
{
  objc_setAssociatedObject(self, @selector(nilCount), nilCount, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)nilCount
{
  return objc_getAssociatedObject(self, @selector(nilCount));
}

- (void)setCamUpdateLat:(NSNumber *)camUpdateLat
{
  objc_setAssociatedObject(self, @selector(camUpdateLat), camUpdateLat, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)camUpdateLat
{
  return objc_getAssociatedObject(self, @selector(camUpdateLat));
}

- (void)setCamUpdateLng:(NSNumber *)camUpdateLng
{
  objc_setAssociatedObject(self, @selector(camUpdateLng), camUpdateLng, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)camUpdateLng
{
  return objc_getAssociatedObject(self, @selector(camUpdateLng));
}

- (void)setAnimateWithCameraUpdateCalled:(NSNumber *)animateWithCameraUpdateCalled
{
  objc_setAssociatedObject(self, @selector(animateWithCameraUpdateCalled), animateWithCameraUpdateCalled, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)animateWithCameraUpdateCalled
{
  return objc_getAssociatedObject(self, @selector(animateWithCameraUpdateCalled));
}

- (void)setMoveCameraArg:(GMSCameraUpdate *)moveCameraArg
{
  objc_setAssociatedObject(self, @selector(moveCameraArg), moveCameraArg, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (GMSCameraUpdate *)moveCameraArg
{
  return objc_getAssociatedObject(self, @selector(moveCameraArg));
}

@end
