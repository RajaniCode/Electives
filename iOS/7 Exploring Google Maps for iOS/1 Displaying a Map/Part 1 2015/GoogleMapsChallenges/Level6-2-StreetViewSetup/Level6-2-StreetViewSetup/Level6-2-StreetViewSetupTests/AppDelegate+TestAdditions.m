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

- (void)setPolyline:(GMSPolyline *)polyline
{
  objc_setAssociatedObject(self, @selector(polyline), polyline, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)polyline
{
  return objc_getAssociatedObject(self, @selector(polyline));
}

- (void)setBlockName:(void (^)(void))blockName
{
  objc_setAssociatedObject(self, @selector(blockName), blockName, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (void (^)(void))blockName
{
  return objc_getAssociatedObject(self, @selector(blockName));
}

@end
