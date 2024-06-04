#import "TruckMapVC.h"
#import <GoogleMaps/GoogleMaps.h>
#import "TruckMarker.h"

@interface TruckMapVC ()<GMSMapViewDelegate>

@property(strong, nonatomic) GMSMapView *mapView;
@property(strong, nonatomic) NSURLSession *markerSession;
@property(copy, nonatomic) NSSet *markers;

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
  CLLocationCoordinate2D fakeCoordinate = CLLocationCoordinate2DMake(0, 0);
  
  /* TODO: Update the geocoder and call the reverseGeocodeCoordinate:completionHandler: method when the marker is tapped.
   *       Use the tapped marker's coordinate as the first parameter in the method instead of the fake coordinate that's 
   *       there now.
   */
  GMSGeocoder *geocoder = [GMSGeocoder geocoder];
  [geocoder reverseGeocodeCoordinate:fakeCoordinate
                   completionHandler:^(GMSReverseGeocodeResponse *response, NSError *error) {
    TruckMarker *truckMarker = (TruckMarker *)marker;
                     
    // TODO: Update these three string variables to the appropriate data from the geocoder response
    NSString *streetAddress = nil;
    NSString *city = nil;
    NSString *state = nil;
                     
    truckMarker.snippet = [NSString stringWithFormat:@"%@, %@, %@",
                           streetAddress,
                           city,
                           state];
    
    // TODO: Call updateMarkerData and pass in the updated truckMarker

                     
    self.mapView.selectedMarker = truckMarker;
  }];
  
  return NO;
}

/* ********
 * you can call this method to update the self.markers array after you have the new geocoded address
 *   in the marker.snippet property
 */
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

@end
