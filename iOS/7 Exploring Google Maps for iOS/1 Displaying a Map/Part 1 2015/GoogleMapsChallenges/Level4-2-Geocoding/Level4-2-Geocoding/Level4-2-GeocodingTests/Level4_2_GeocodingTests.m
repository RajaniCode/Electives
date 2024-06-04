#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>
#import <objc/runtime.h>

#import "CSRecordingTestCase.h"
#import "CSPropertyDefinition.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"
#import "TruckMarker.h"

#import "TruckMapVC+Swizzles.h"
#import "XCTestCase+AsyncTesting.h"

#define kDoubleEpsilon (0.0001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}

@interface Level4_2_GeocodingTests : CSRecordingTestCase {}

@end

@implementation Level4_2_GeocodingTests

- (void)setUp {
  [super setUp];
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.markers = nil;
  appDelegate.geocodeResults = nil;
  appDelegate.geocoderCalled = nil;
  appDelegate.reverseGeocodeCalled = nil;
}

- (void)tearDown {
  [super tearDown];
}

- (void)testGeocodingHappensWhenMarkerTapped
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(1);
  
  NSSet *markers = [mapVC valueForKey:@"markers"];
  
  XCTAssert(markers.count == 6, @"You don't have the right number of marker objects - did you accidentally delete some code from this project, because they were there when you opened it!");
  
  NSSortDescriptor *sortDescriptor;
  sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                               ascending:YES];
  NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
  NSArray *sortedArray;
  sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];
  
  if (markers.count > 0) {
    TruckMarker *first = sortedArray.firstObject;
    
    XCTAssert([first isKindOfClass:[TruckMarker class]], @"The self.markers set should be populated with TruckMarker objects.  It was when you opened this project - did you accidentally delete some code?");
    
    GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
    
    [mapView.delegate mapView:mapView didTapMarker:first];
    
    if(appDel.geocoderCalled) {
    
      XCTAssert(appDel.reverseGeocodeCalled, @"Did not call the reverse geocode method");
      XCTAssert(doubleCloseTo([appDel.latCoordinate doubleValue], first.position.latitude) && doubleCloseTo([appDel.lngCoordinate doubleValue], first.position.longitude), @"Did not send the right coordinate into the reverse geocode method");
      
    } else {
      XCTFail(@"Did not create a GMSGeocoder object");
    }
  }
}

- (void)testCorrectAddressStrings
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(1);
  
  NSSet *markers = [mapVC valueForKey:@"markers"];
  
  XCTAssert(markers.count == 6, @"You don't have the right number of marker objects - did you accidentally delete some code from this project, because they were there when you opened it!");
  
  NSSortDescriptor *sortDescriptor;
  sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                               ascending:YES];
  NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
  NSArray *sortedArray;
  sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];
  
  if (markers.count > 0) {
    TruckMarker *first = sortedArray.firstObject;
    
    XCTAssert([first isKindOfClass:[TruckMarker class]], @"The self.markers set should be populated with TruckMarker objects.  It was when you opened this project - did you accidentally delete some code?");
    
    GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
    
    [mapView.delegate mapView:mapView didTapMarker:first];
    sleep(2);
    
    if(appDel.geocoderCalled) {
      
      NSString *firstSnippetExpected = @"2960 Laguna St, San Francisco, California";
      
      [appDel.theGeocoder reverseGeocodeCoordinate:first.position completionHandler:^(GMSReverseGeocodeResponse *response, NSError *error) {
        appDel.geocodeResults = response.results;
        [self notify:XCTAsyncTestCaseStatusSucceeded];
      }];

      [self waitForStatus:XCTAsyncTestCaseStatusSucceeded timeout:4.0];

      NSString *firstSnippetAfter = first.snippet;
      if(appDel.reverseGeocodeCalled && firstSnippetAfter.length > 0) {
        BOOL snippetsEqual = [firstSnippetExpected isEqualToString:firstSnippetAfter];
        XCTAssert(snippetsEqual, @"Did not update the marker with the first result from the GMSReverseGeocodeResponse object");
      } else {
        XCTFail(@"Did not update the marker with the first result from the GMSReverseGeocodeResponse object");
      }
      
    } else {
      XCTFail(@"Did not create a GMSGeocoder object");
    }
  }
}

- (void)testMarkerDataUpdatedAfterGeocoding
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(1);
  
  NSSet *markers = [mapVC valueForKey:@"markers"];
  
  XCTAssert(markers.count == 6, @"You don't have the right number of marker objects - did you accidentally delete some code from this project, because they were there when you opened it!");
  
  NSSortDescriptor *sortDescriptor;
  sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                               ascending:YES];
  NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
  NSArray *sortedArray;
  sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];
  
  if (markers.count > 0) {
    TruckMarker *first = sortedArray.firstObject;
    
    XCTAssert([first isKindOfClass:[TruckMarker class]], @"The self.markers set should be populated with TruckMarker objects.  It was when you opened this project - did you accidentally delete some code?");
    
    GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
    
    [mapView.delegate mapView:mapView didTapMarker:first];
    
    [appDel.theGeocoder reverseGeocodeCoordinate:first.position completionHandler:^(GMSReverseGeocodeResponse *response, NSError *error) {
      appDel.geocodeResults = response.results;
      [self notify:XCTAsyncTestCaseStatusSucceeded];
    }];
    
    [self waitForStatus:XCTAsyncTestCaseStatusSucceeded timeout:4.0];
    
    if(mapVC.calledUpdateMarkers) {
      XCTAssert([mapVC.markerToUpdate.snippet isEqualToString:first.snippet], @"Did not send the right marker to updateMarkerData");
    } else {
      XCTFail(@"Did not call the updateMarkerData method after updating the snippet property");
    }
  }
}

@end
