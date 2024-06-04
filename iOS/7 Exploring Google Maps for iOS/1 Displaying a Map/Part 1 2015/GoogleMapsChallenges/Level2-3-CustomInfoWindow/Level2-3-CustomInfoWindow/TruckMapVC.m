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

  GMSCameraPosition *camera = [GMSCameraPosition cameraWithLatitude:37.790706
                                                          longitude:-122.434167
                                                               zoom:13
                                                            bearing:0
                                                       viewingAngle:0];

  self.mapView = [GMSMapView mapWithFrame:self.view.frame camera:camera];
  self.mapView.delegate = self;

  self.mapView.mapType = kGMSTypeTerrain;

  self.mapView.myLocationEnabled = YES;
  self.mapView.settings.compassButton = YES;
  self.mapView.settings.zoomGestures = NO;

  [self.view addSubview:self.mapView];
  
  GMSMarker *meltHouseMarker = [[GMSMarker alloc] init];
  meltHouseMarker.position = CLLocationCoordinate2DMake(37.798505, -122.430562);
  meltHouseMarker.title = @"Melt House";
  meltHouseMarker.appearAnimation = kGMSMarkerAnimationPop;
  meltHouseMarker.icon = [UIImage imageNamed:@"marker-melt-house"];
  meltHouseMarker.userData = [UIImage imageNamed:@"melt-house"];
  meltHouseMarker.map = self.mapView;
  
  GMSMarker *tacoGogoMarker = [[GMSMarker alloc] init];
  tacoGogoMarker.position = CLLocationCoordinate2DMake(37.791384, -122.439832);
  tacoGogoMarker.title = @"Taco Gogo";
  tacoGogoMarker.appearAnimation = kGMSMarkerAnimationPop;
  tacoGogoMarker.icon = [UIImage imageNamed:@"marker-taco-gogo"];
  tacoGogoMarker.userData = [UIImage imageNamed:@"taco-gogo"];
  tacoGogoMarker.map = self.mapView;
}


- (void)viewWillLayoutSubviews {
  [super viewWillLayoutSubviews];

  self.mapView.padding = UIEdgeInsetsMake(self.topLayoutGuide.length, 0, 0, 0);
}


- (UIView *)mapView:(GMSMapView *)mapView markerInfoWindow:(GMSMarker *)marker
{
  UIView *infoWindow = [[UIView alloc] init];
  infoWindow.frame = CGRectMake(0, 0, 260, 86);
  
  /* TODO: Create and add a UIImageView as a subview of infoWindow.
   * Display the image named @"info-window" in this image view
   * Set the frame of this image view equal to the frame of the infoWindow
   * Set the alpha of this image view to 0.85 so the info window will be slightly transparent
   */
  
  
  UIImageView *truckLogoImage = [[UIImageView alloc] init];
  truckLogoImage.frame = CGRectMake(17, 17, 52, 52);
  [infoWindow addSubview:truckLogoImage];

  /* TODO: Set the image that truckLogoImage displays to the UIImage contained in the passed in marker object's userData */
  

  
  UILabel *truckNameLabel = [[UILabel alloc] init];
  truckNameLabel.frame = CGRectMake(CGRectGetMaxX(truckLogoImage.frame) + 15, CGRectGetMinY(truckLogoImage.frame), 165, 28);
  truckNameLabel.font = [UIFont fontWithDescriptor:[UIFontDescriptor fontDescriptorWithFontAttributes:@{NSFontAttributeName: @"Arial", NSForegroundColorAttributeName: [UIColor colorWithWhite:0.0 alpha:1.0]}] size:19.0f];
  [infoWindow addSubview:truckNameLabel];
  
  /* TODO: Set the text that truckNameLabel displays to the string contained in the passed in marker object's title */
  
  
  return infoWindow;
}

@end
