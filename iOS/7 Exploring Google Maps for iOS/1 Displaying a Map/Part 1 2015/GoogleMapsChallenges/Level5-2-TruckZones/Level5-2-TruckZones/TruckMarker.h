#import <GoogleMaps/GoogleMaps.h>

@interface TruckMarker : GMSMarker

@property (nonatomic, copy) NSString *objectID;
@property (nonatomic, assign) BOOL inTheShop;

@end
