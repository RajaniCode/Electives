#import "AppDelegate+TestAdditions.h"

#import <objc/objc-runtime.h>
#import <GoogleMaps/GoogleMaps.h>

@implementation AppDelegate (TestAdditions)

- (void)setMarkers:(GMSCameraPosition *)markers
{
    objc_setAssociatedObject(self, @selector(markers), markers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)markers
{
    return objc_getAssociatedObject(self, @selector(markers));
}

- (void)setImageNames:(NSArray *)imageNames
{
  objc_setAssociatedObject(self, @selector(imageNames), imageNames, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)imageNames
{
  return objc_getAssociatedObject(self, @selector(imageNames));
}

@end
