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

- (void)setJsonInTests:(NSDictionary *)jsonInTests
{
  objc_setAssociatedObject(self, @selector(jsonInTests), jsonInTests, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSDictionary *)jsonInTests
{
  return objc_getAssociatedObject(self, @selector(jsonInTests));
}

- (void)setDirectionsViewAppeared:(NSNumber *)directionsViewAppeared
{
  objc_setAssociatedObject(self, @selector(directionsViewAppeared), directionsViewAppeared, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)directionsViewAppeared
{
  return objc_getAssociatedObject(self, @selector(directionsViewAppeared));
}

- (void)setStepsInDirectionsVC:(NSArray *)stepsInDirectionsVC
{
  objc_setAssociatedObject(self, @selector(stepsInDirectionsVC), stepsInDirectionsVC, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)stepsInDirectionsVC
{
  return objc_getAssociatedObject(self, @selector(stepsInDirectionsVC));
}


@end
