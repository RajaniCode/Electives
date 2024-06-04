#import "TruckMapVC.h"
#import <GoogleMaps/GoogleMaps.h>
#import "TruckMarker.h"
#import "DirectionsVC.h"

@interface TruckMapVC ()<GMSMapViewDelegate>

@property(strong, nonatomic) GMSMapView *mapView;
@property(strong, nonatomic) NSURLSession *markerSession;
@property(copy, nonatomic) NSSet *markers;
@property(copy, nonatomic) NSArray *steps;

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
  
  self.mapView.delegate = self;

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
  truckNameLabel.font = [UIFont fontWithDescriptor:[UIFontDescriptor fontDescriptorWithFontAttributes:@{NSFontAttributeName: @"Arial"}] size:19.0f];
  truckNameLabel.textColor = [UIColor blackColor];
  [infoWindow addSubview:truckNameLabel];
  truckNameLabel.text = marker.title;
  
  UILabel *truckAddressLabel = [[UILabel alloc] init];
  truckAddressLabel.numberOfLines = 0;
  truckAddressLabel.lineBreakMode = NSLineBreakByWordWrapping;
  truckAddressLabel.frame = CGRectMake(CGRectGetMinX(truckNameLabel.frame), CGRectGetMaxY(truckNameLabel.frame), 165, 32);
  truckAddressLabel.font = [UIFont fontWithDescriptor:[UIFontDescriptor fontDescriptorWithFontAttributes:@{NSFontAttributeName: @"Arial"}] size:13.0f];
  truckAddressLabel.textColor = [UIColor grayColor];
  [infoWindow addSubview:truckAddressLabel];
  truckAddressLabel.text = marker.snippet;
  
  return infoWindow;
}


- (void)downloadMarkerData:(id)sender
{
  NSURL *trucksURL = [NSURL URLWithString:trucksURLString];
  
  NSURLSessionDataTask *task = [self.markerSession dataTaskWithURL:trucksURL completionHandler:^(NSData *data, NSURLResponse *response, NSError *error)
  {
    NSArray *json = [NSJSONSerialization JSONObjectWithData:data options:0 error:nil];
    
    [[NSOperationQueue mainQueue] addOperationWithBlock:^{
      [self createMarkerObjectsWithJson:json];
    }];
  }];
  
  [task resume];
}


- (void)createMarkerObjectsWithJson:(NSArray *)markers
{
  NSMutableSet *mutableMarkers = [NSMutableSet setWithSet:self.markers];
  
  for (NSDictionary *markerData in markers) {
    
    TruckMarker *newMarker = [[TruckMarker alloc] init];
    newMarker.objectID = [markerData[@"id"] stringValue];
    newMarker.appearAnimation = [markerData[@"appearAnimation"] integerValue];
    newMarker.position = CLLocationCoordinate2DMake([markerData[@"lat"] doubleValue], [markerData[@"lng"] doubleValue]);
    newMarker.title = markerData[@"title"];
    newMarker.icon = [UIImage imageNamed:markerData[@"marker-icon"]];
    newMarker.userData = [UIImage imageNamed:markerData[@"logo-image"]];
    newMarker.inTheShop = [markerData[@"inTheShop"] boolValue];
    newMarker.map = nil;
    
    [mutableMarkers addObject:newMarker];
  }
  
  self.markers = [mutableMarkers copy];
  
  [self drawMarkers];
}


- (void)drawMarkers
{
  for (TruckMarker *marker in self.markers) {
    if (marker.map == nil && marker.inTheShop == NO) {
      marker.map = self.mapView;
    }
  }
}


- (BOOL)mapView:(GMSMapView *)mapView didTapMarker:(GMSMarker *)marker
{
  GMSGeocoder *geocoder = [GMSGeocoder geocoder];
  [geocoder reverseGeocodeCoordinate:marker.position
                   completionHandler:^(GMSReverseGeocodeResponse *response, NSError *error) {
    TruckMarker *truckMarker = (TruckMarker *)marker;
    
    NSString *streetAddress = response.firstResult.thoroughfare;
    NSString *city = response.firstResult.locality;
    NSString *state = response.firstResult.administrativeArea;

    truckMarker.snippet = [NSString stringWithFormat:@"%@, %@, %@",
                                                      streetAddress,
                                                      city,
                                                      state];
    
    [self updateMarkerData:truckMarker];

    self.mapView.selectedMarker = truckMarker;
  }];
  
  if(mapView.myLocation != nil) {
    NSURL *directionsURL = [NSURL URLWithString:
                            [NSString stringWithFormat:
                             @"%@?origin=%f,%f&destination=%f,%f&sensor=false",
                             @"http://maps.googleapis.com/maps/api/directions/json",
                             mapView.myLocation.coordinate.latitude,
                             mapView.myLocation.coordinate.longitude,
                             marker.position.latitude,
                             marker.position.longitude
                             ]];
    
    NSURLSessionDataTask *directionsTask = [self.markerSession dataTaskWithURL:directionsURL completionHandler:^(NSData *data, NSURLResponse *response, NSError *e) {
      
      NSError *error = nil;
      NSDictionary *json =
      [NSJSONSerialization JSONObjectWithData:data
                                      options:NSJSONReadingMutableContainers
                                        error:&error];
      
      // TODO: If the error object is nil, set the self.steps array equal to the steps returned in the JSON response dictionary, which can be accessed here: [@"routes"][0][@"legs"][0][@"steps"]

      
      
    }];
    
    [directionsTask resume];
  }

  return NO;
}


- (void)updateMarkerData:(TruckMarker *)marker
{
  NSMutableSet *mutableMarkers = [self.markers mutableCopy];
  
  TruckMarker *truckMarker = [mutableMarkers member:marker];
  
  if(truckMarker) {
    [mutableMarkers removeObject:truckMarker];
    [mutableMarkers addObject:truckMarker];

    self.markers = [mutableMarkers copy];
  }
}


- (void)mapView:(GMSMapView *)mapView didTapInfoWindowOfMarker:(GMSMarker *)marker
{
  DirectionsVC *directionsVC = [[DirectionsVC alloc] init];
  
  // TODO: Pass the contents of the self.steps array into the directionsVC

  
  // TODO: Present the directionsVC in a modal popup

  
}


@end
