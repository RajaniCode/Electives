#import "AppDelegate+TestAdditions.h"
#import <objc/objc-runtime.h>

@implementation AppDelegate (TestAdditions)

- (void)setMarkers:(GMSCameraPosition *)markers
{
    objc_setAssociatedObject(self, @selector(markers), markers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)markers
{
    return objc_getAssociatedObject(self, @selector(markers));
}

- (void)setPolygons:(NSArray *)polygons
{
  objc_setAssociatedObject(self, @selector(polygons), polygons, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)polygons
{
  return objc_getAssociatedObject(self, @selector(polygons));
}

@end
