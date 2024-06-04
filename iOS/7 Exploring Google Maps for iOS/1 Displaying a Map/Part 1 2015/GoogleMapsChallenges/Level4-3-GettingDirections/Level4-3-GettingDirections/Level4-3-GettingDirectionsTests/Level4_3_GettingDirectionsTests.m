#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>
#import <objc/runtime.h>

#import "CSRecordingTestCase.h"
#import "CSPropertyDefinition.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"
#import "TruckMarker.h"
#import "DirectionsVC.h"

#import "XCTestCase+AsyncTesting.h"
#import "TruckMapVC+Swizzles.h"


#define kDoubleEpsilon (0.001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}
@interface Level4_3_GettingDirectionsTests : CSRecordingTestCase {}

@end

@implementation Level4_3_GettingDirectionsTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  [super tearDown];
}

- (void)testGetDirectionsSteps
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;

  sleep(2);

  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
  
  NSSet *markers = [mapVC valueForKey:@"markers"];
  XCTAssert(markers.count == 6, @"You don't have the right number of marker objects - did you accidentally delete some code from this project, because they were there when you opened it!");
  
  if (markers.count > 0) {
    NSSortDescriptor *sortDescriptor;
    sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                 ascending:YES];
    NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
    NSArray *sortedArray;
    sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];

    TruckMarker *first = sortedArray[0];
    
    XCTAssert([first isKindOfClass:[TruckMarker class]], @"The self.markers set should be populated with TruckMarker objects.  It was when you opened this project - did you accidentally delete some code?");
    
    // tap the marker to start the directions request
    [mapView.delegate mapView:mapView didTapMarker:first];
    
    // wait for the directions response to come back
    sleep(2);
    
    id steps = mapVC.steps;
    if(steps == nil) {
      XCTFail(@"The Directions API request failed");
    } else {
      NSURLSessionConfiguration *config = [NSURLSessionConfiguration defaultSessionConfiguration];
      NSURLSession *markerSession = [NSURLSession sessionWithConfiguration:config];
      
      NSURL *directionsURL = [NSURL URLWithString:
                              [NSString stringWithFormat:
                               @"%@?origin=%f,%f&destination=%f,%f&sensor=false",
                               @"http://maps.googleapis.com/maps/api/directions/json",
                               37.790706,
                               -122.434167,
                               37.798505,
                               -122.430562
                               ]];
      
      NSURLSessionDataTask *task = [markerSession dataTaskWithURL:directionsURL completionHandler:^(NSData *data, NSURLResponse *response, NSError *error) {
        [self notify:XCTAsyncTestCaseStatusSucceeded];
        NSError *e = nil;
        appDel.jsonInTests = [NSJSONSerialization JSONObjectWithData:data
                                                             options:NSJSONReadingMutableContainers
                                                               error:&e];
      }];
      [task resume];
      
      [self waitForStatus:XCTAsyncTestCaseStatusSucceeded timeout:3.0];
      [self notify:XCTAsyncTestCaseStatusUnknown];
      
      // first check if the number of steps is right
      NSUInteger stepsInTruckMapVC = [mapVC.steps count];
      NSUInteger stepsInJsonResponse = [appDel.jsonInTests[@"routes"][0][@"legs"][0][@"steps"] count];
      
      if(stepsInJsonResponse != stepsInTruckMapVC) {
        XCTFail(@"The directions API request did not return the right amount of steps");
      } else {
        
        // then, check the first step's start/end coordinates.  We can be pretty sure they used the right start/end coordinates if these match
        double directionsStartLocationLat = [appDel.jsonInTests[@"routes"][0][@"legs"][0][@"steps"][0][@"start_location"][@"lat"] doubleValue];
        double truckMapStartLocationLat = [mapVC.steps[0][@"start_location"][@"lat"] doubleValue];
        
        double directionsStartLocationLng = [appDel.jsonInTests[@"routes"][0][@"legs"][0][@"steps"][0][@"start_location"][@"lng"] doubleValue];
        double truckMapStartLocationLng = [mapVC.steps[0][@"start_location"][@"lng"] doubleValue];
        
        double directionsEndLocationLat = [appDel.jsonInTests[@"routes"][0][@"legs"][0][@"steps"][0][@"end_location"][@"lat"] doubleValue];
        double truckMapEndLocationLat = [mapVC.steps[0][@"end_location"][@"lat"] doubleValue];
        
        double directionsEndLocationLng = [appDel.jsonInTests[@"routes"][0][@"legs"][0][@"steps"][0][@"end_location"][@"lng"] doubleValue];
        double truckMapEndLocationLng = [mapVC.steps[0][@"end_location"][@"lng"] doubleValue];
        
        XCTAssert(doubleCloseTo(directionsStartLocationLat, truckMapStartLocationLat), @"start lats don't match");
        XCTAssert(doubleCloseTo(directionsStartLocationLng, truckMapStartLocationLng), @"start lngs don't match");
        XCTAssert(doubleCloseTo(directionsEndLocationLat, truckMapEndLocationLat), @"end lats don't match");
        XCTAssert(doubleCloseTo(directionsEndLocationLng, truckMapEndLocationLng), @"end lngs don't match");
      }
    }
  } else {
    XCTFail(@"No markers");
  }
}

- (void)testDirectionsDisplayedOnInfoWindowTap
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(2);
  
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
  
  NSSet *markers = [mapVC valueForKey:@"markers"];
  XCTAssert(markers.count == 6, @"You don't have the right number of marker objects - did you accidentally delete some code from this project, because they were there when you opened it!");
  
  if (markers.count > 0) {
    NSSortDescriptor *sortDescriptor;
    sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                 ascending:YES];
    NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
    NSArray *sortedArray;
    sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];
    
    TruckMarker *first = sortedArray[0];
    
    XCTAssert([first isKindOfClass:[TruckMarker class]], @"The self.markers set should be populated with TruckMarker objects.  It was when you opened this project - did you accidentally delete some code?");
    
    [mapView.delegate mapView:mapView didTapInfoWindowOfMarker:first];
      
    XCTAssert([appDel.directionsViewAppeared boolValue], @"Did not open directionsVC when the mapView was tapped");
  } else {
    XCTFail(@"No markers");
  }
}

- (void)testStepsPassedToDirectionsVC
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(2);
  
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
  
  NSSet *markers = [mapVC valueForKey:@"markers"];
  XCTAssert(markers.count == 6, @"You don't have the right number of marker objects - did you accidentally delete some code from this project, because they were there when you opened it!");
  
  if (markers.count > 0) {
    NSSortDescriptor *sortDescriptor;
    sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                 ascending:YES];
    NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
    NSArray *sortedArray;
    sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];
    
    TruckMarker *first = sortedArray[0];
    
    XCTAssert([first isKindOfClass:[TruckMarker class]], @"The self.markers set should be populated with TruckMarker objects.  It was when you opened this project - did you accidentally delete some code?");
    
    // tap the marker to start the directions request
    [mapView.delegate mapView:mapView didTapMarker:first];
    
    // wait for the directions response to come back
    sleep(2);
    
    id steps = mapVC.steps;
    if(steps == nil) {
      XCTFail(@"The Directions API request failed.  Get that working before you attempt to pass steps to the DirectionsVC");
    } else {
      [mapView.delegate mapView:mapView didTapInfoWindowOfMarker:first];
      sleep(1);
      XCTAssert([appDel.stepsInDirectionsVC isEqualToArray:steps], @"you didn't pass DirectionsVC the steps array");
    }
  } else {
    XCTFail(@"No markers");
  }
}

@end
