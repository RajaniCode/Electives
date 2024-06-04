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

- (void)setInTheShopCount:(NSNumber *)inTheShopCount
{
  objc_setAssociatedObject(self, @selector(inTheShopCount), inTheShopCount, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)inTheShopCount
{
  return objc_getAssociatedObject(self, @selector(inTheShopCount));
}

@end
 