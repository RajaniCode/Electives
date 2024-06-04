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

- (void)setGeocoderCalled:(NSNumber *)geocoderCalled
{
  objc_setAssociatedObject(self, @selector(geocoderCalled), geocoderCalled, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)geocoderCalled
{
  return objc_getAssociatedObject(self, @selector(geocoderCalled));
}

- (void)setReverseGeocodeCalled:(NSNumber *)reverseGeocodeCalled
{
  objc_setAssociatedObject(self, @selector(reverseGeocodeCalled), reverseGeocodeCalled, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)reverseGeocodeCalled
{
  return objc_getAssociatedObject(self, @selector(reverseGeocodeCalled));
}

- (void)setLatCoordinate:(NSNumber *)latCoordinate
{
  objc_setAssociatedObject(self, @selector(latCoordinate), latCoordinate, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)latCoordinate
{
  return objc_getAssociatedObject(self, @selector(latCoordinate));
}

- (void)setLngCoordinate:(NSNumber *)lngCoordinate
{
  objc_setAssociatedObject(self, @selector(lngCoordinate), lngCoordinate, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)lngCoordinate
{
  return objc_getAssociatedObject(self, @selector(lngCoordinate));
}

- (void)setTheGeocoder:(GMSGeocoder *)theGeocoder
{
  objc_setAssociatedObject(self, @selector(theGeocoder), theGeocoder, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (GMSGeocoder *)theGeocoder
{
  return objc_getAssociatedObject(self, @selector(theGeocoder));
}

- (void)setGeocodeResults:(NSArray *)geocodeResults
{
  objc_setAssociatedObject(self, @selector(geocodeResults), geocodeResults, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)geocodeResults
{
  return objc_getAssociatedObject(self, @selector(geocodeResults));
}

@end
