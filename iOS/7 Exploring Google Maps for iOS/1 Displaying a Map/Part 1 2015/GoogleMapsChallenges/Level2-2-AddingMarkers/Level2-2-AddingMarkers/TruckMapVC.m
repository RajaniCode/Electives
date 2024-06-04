#import "TruckMapVC.h"
#import <GoogleMaps/GoogleMaps.h>

@interface TruckMapVC ()

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

  GMSCameraPosition *camera = [GMSCameraPosition cameraWithLatitude:37.790706
                                                          longitude:-122.434167
                                                               zoom:13
                                                            bearing:0
                                                       viewingAngle:0];

  self.mapView = [GMSMapView mapWithFrame:self.view.frame camera:camera];

  self.mapView.mapType = kGMSTypeTerrain;

  self.mapView.myLocationEnabled = YES;
  self.mapView.settings.compassButton = YES;
  self.mapView.settings.zoomGestures = NO;

  [self.view addSubview:self.mapView];
  
  /* Create and display a marker for the Melt House truck with the following settings:
   * position         37.798505, -122.430562
   * title            Melt House
   * appearAnimation  pop
   * icon             a UIImage named marker-melt-house
   */
  

  /* Create and display a marker for the Taco Gogo truck with the following settings:
   * position         37.791384, -122.439832
   * title            Taco Gogo
   * appearAnimation  pop
   * icon             a UIImage named marker-taco-gogo
   */


}


- (void)viewWillLayoutSubviews {
  [super viewWillLayoutSubviews];

  self.mapView.padding = UIEdgeInsetsMake(self.topLayoutGuide.length, 0, 0, 0);
}

@end
