#import "TruckMapVC.h"
#import <GoogleMaps/GoogleMaps.h>

@interface TruckMapVC ()<GMSMapViewDelegate>

@property(strong, nonatomic) GMSMapView *mapView;

@end

@implementation TruckMapVC

- (id)initWithNibName:(NSString *)nibNameOrNil
               bundle:(NSBundle *)nibBundleOrNil {
  self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
  if (self) {
    self.title = @"Truck Map";
  }
  return self;
}


- (void)viewDidLoad {
  [super viewDidLoad];

  /* TODO: Create a GMSCameraPosition object with the following properties:
   * latitude     37.790706
   * longitude    -122.434167
   * zoom         13
   * bearing      0
   * viewingAngle 0
   */

  
  // TODO: Create and add a GMSMapView that takes up the entire screen and uses the camera created above
  
  
  // TODO: Set the map type to terrain.

  
  // TODO: Turn on the My Location icon and Compass button, and disable zoom gestures.
  
  
}


- (void)viewWillLayoutSubviews {
  [super viewWillLayoutSubviews];

  // TODO: Set the map padding so that the compass button isn't hidden underneath the navigation bar.
  
  
}

@end
