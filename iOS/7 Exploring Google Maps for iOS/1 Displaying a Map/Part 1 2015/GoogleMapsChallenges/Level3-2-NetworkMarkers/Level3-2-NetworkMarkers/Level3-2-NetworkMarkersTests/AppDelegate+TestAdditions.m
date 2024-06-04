#import "AppDelegate+TestAdditions.h"
#import <objc/objc-runtime.h>
#import <GoogleMaps/GoogleMaps.h>

@implementation AppDelegate (TestAdditions)

- (void)setMarkers:(GMSCameraPosition *)markers
{
    objc_setAssociatedObject(self, @selector(markers), markers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)markers
{
    return objc_getAssociatedObject(self, @selector(markers));
}

- (void)setMarkerImageNames:(NSArray *)markerImageNames
{
  objc_setAssociatedObject(self, @selector(markerImageNames), markerImageNames, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)markerImageNames
{
  return objc_getAssociatedObject(self, @selector(markerImageNames));
}

- (void)setLogoImageNames:(NSArray *)logoImageNames
{
  objc_setAssociatedObject(self, @selector(logoImageNames), logoImageNames, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)logoImageNames
{
  return objc_getAssociatedObject(self, @selector(logoImageNames));
}

@end
