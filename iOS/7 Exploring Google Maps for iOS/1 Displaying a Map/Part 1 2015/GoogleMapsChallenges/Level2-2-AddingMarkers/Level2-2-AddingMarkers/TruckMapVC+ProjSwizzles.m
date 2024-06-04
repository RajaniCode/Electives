#import "TruckMapVC+ProjSwizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import <GoogleMaps/GoogleMaps.h>

@interface TruckMapVC ()
@property (strong, nonatomic) GMSMapView *mapView;
@end

@implementation TruckMapVC (ProjSwizzles)

+ (void) load
{
  [CSSwizzler swizzleClass:[TruckMapVC class]
             replaceMethod:@selector(viewDidLoad)
                withMethod:@selector(cs_viewDidLoad)];
}

- (void)cs_viewDidLoad
{
  [self cs_viewDidLoad];
  
  GMSMarker *truck3 = [[GMSMarker alloc] init];
  truck3.position = CLLocationCoordinate2DMake(37.786297, -122.452964);
  truck3.title = @"B'klyn Buggy Bowl";
  truck3.appearAnimation = kGMSMarkerAnimationPop;
  truck3.icon = [UIImage imageNamed:@"marker-brooklyn-buggy-bowl"];
  truck3.userData = [UIImage imageNamed:@"brooklyn-buggy-bowl"];
  truck3.map = self.mapView;

  GMSMarker *truck4 = [[GMSMarker alloc] init];
  truck4.position = CLLocationCoordinate2DMake(37.799319, -122.415713);
  truck4.title = @"King Cupcake";
  truck4.appearAnimation = kGMSMarkerAnimationPop;
  truck4.icon = [UIImage imageNamed:@"marker-king-cupcake"];
  truck4.userData = [UIImage imageNamed:@"king-cupcake"];
  truck4.map = self.mapView;

  GMSMarker *truck5 = [[GMSMarker alloc] init];
  truck5.position = CLLocationCoordinate2DMake(37.773362, -122.433988);
  truck5.title = @"Let's Roll";
  truck5.appearAnimation = kGMSMarkerAnimationPop;
  truck5.icon = [UIImage imageNamed:@"marker-lets-roll"];
  truck5.userData = [UIImage imageNamed:@"lets-roll"];
  truck5.map = self.mapView;

  GMSMarker *truck6 = [[GMSMarker alloc] init];
  truck6.position = CLLocationCoordinate2DMake(37.789666, -122.418814);
  truck6.title = @"Burger Bros";
  truck6.appearAnimation = kGMSMarkerAnimationPop;
  truck6.icon = [UIImage imageNamed:@"marker-burger-bros"];
  truck6.userData = [UIImage imageNamed:@"burger-bros"];
  truck6.map = self.mapView;
}

@end
