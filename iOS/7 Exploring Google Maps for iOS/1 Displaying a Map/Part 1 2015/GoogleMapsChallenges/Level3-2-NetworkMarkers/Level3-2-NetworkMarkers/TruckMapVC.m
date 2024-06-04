#import "TruckMapVC.h"
#import <GoogleMaps/GoogleMaps.h>
#import "TruckMarker.h"

@interface TruckMapVC ()<GMSMapViewDelegate>

@property(strong, nonatomic) GMSMapView *mapView;
@property(strong, nonatomic) NSURLSession *markerSession;
@property(strong, nonatomic) NSSet *markers;

@end

static NSString *trucksURLString = @"http://googlemaps.codeschool.com/trucks.json";

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
    
  NSURLSessionConfiguration *config = [NSURLSessionConfiguration defaultSessionConfiguration];
  config.URLCache = [[NSURLCache alloc] initWithMemoryCapacity:2 * 1024 * 1024
                                                    diskCapacity:10 * 1024 * 1024
                                                        diskPath:@"MarkerData"];
    
  self.markerSession = [NSURLSession sessionWithConfiguration:config];

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
  
  [self downloadMarkerData:nil];
}


- (void)viewWillLayoutSubviews {
  [super viewWillLayoutSubviews];

  self.mapView.padding = UIEdgeInsetsMake(self.topLayoutGuide.length, 0, 0, 0);
}


- (UIView *)mapView:(GMSMapView *)mapView markerInfoWindow:(GMSMarker *)marker
{
  UIView *infoWindow = [[UIView alloc ] init];
  infoWindow.frame = CGRectMake(0, 0, 260, 86);
  
  UIImageView *backgroundImage = [[UIImageView alloc] init];
  backgroundImage.frame = infoWindow.frame;
  backgroundImage.image = [UIImage imageNamed:@"info-window"];
  backgroundImage.alpha = 0.85;
  [infoWindow addSubview:backgroundImage];
  
  UIImageView *truckLogoImage = [[UIImageView alloc] init];
  truckLogoImage.image = marker.userData;
  truckLogoImage.frame = CGRectMake(17, 17, 52, 52);
  [infoWindow addSubview:truckLogoImage];
  
  UILabel *truckNameLabel = [[UILabel alloc] init];
  truckNameLabel.frame = CGRectMake(CGRectGetMaxX(truckLogoImage.frame) + 15, CGRectGetMinY(truckLogoImage.frame), 165, 28);
  truckNameLabel.font = [UIFont fontWithDescriptor:[UIFontDescriptor fontDescriptorWithFontAttributes:@{NSFontAttributeName: @"Arial", NSForegroundColorAttributeName: [UIColor colorWithWhite:0.0 alpha:1.0]}] size:19.0f];
  [infoWindow addSubview:truckNameLabel];
  truckNameLabel.text = marker.title;
  
  return infoWindow;
}


- (void)downloadMarkerData:(id)sender
{
  // TODO: Modify this trucksURL to use the trucksURLString constant defined at the top of this file
  NSURL *trucksURL = nil;
  
  NSURLSessionDataTask *task = [self.markerSession dataTaskWithURL:trucksURL completionHandler:^(NSData *data, NSURLResponse *response, NSError *error)
  {
    NSArray *json = [NSJSONSerialization JSONObjectWithData:data options:0 error:nil];
    
    // TODO: Call the createMarkerObjectsWithJson method on the main thread, and pass it the json response array
    
    
    
  }];
  
  [task resume];
}


- (void)createMarkerObjectsWithJson:(NSArray *)markers
{
  NSMutableSet *mutableMarkers = [NSMutableSet setWithSet:self.markers];
  
  for (NSDictionary *markerData in markers) {
    
    /* TODO: Create a TruckMarker object for each of the markerData dictionaries in this loop 
     *       Set the following properties of each new marker object to the corresponding dictionary value:
     *
     *       TruckMarker property----- markerData key------
     *       objectID                  id
     *       appearAnimation           appearAnimation
     *       position                  lat and lng (need to create a CLLocationCoordinate2D struct)
     *       title                     title
     *       icon                      a UIImage with the key marker-icon
     *       userData                  a UIImage with the key logo-image
     *
     *       Don't forget to use or convert to the correct data format that the marker property is expecting
     */
    
    
    // TODO: Add the new marker object you created above to the mutableMarkers set
    
    
  }
  
  self.markers = [mutableMarkers copy];
  
  [self drawMarkers];
}


- (void)drawMarkers
{
  for (TruckMarker *marker in self.markers) {
    if (marker.map == nil) {
      marker.map = self.mapView;
    }
  }
}

@end
