#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>

#import "CSRecordingTestCase.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"
#import "TruckMapVC.h"

#define kDoubleEpsilon (0.00001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}

@interface Level2_2_AddingMarkersTests : CSRecordingTestCase {
  AppDelegate *_appDel;
}

@end

@implementation Level2_2_AddingMarkersTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  [super tearDown];
}

- (void)testAddedMeltHouseMarker {
  AppDelegate *appDel =
  (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC =
  (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
  
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
  
  GMSMarker *marker;
  if(appDel.markers.count == 2) {
    if([[appDel.markers[0] title] isEqualToString:@"Melt House"]) {
      marker = appDel.markers[0];
    } else if([[appDel.markers[1] title] isEqualToString:@"Melt House"]) {
      marker = appDel.markers[1];
    }
  } else if(appDel.markers.count == 1) {
    marker = appDel.markers[0];
  } else {
    marker = [[GMSMarker alloc] init];
  }
  
  XCTAssert(doubleCloseTo(marker.position.latitude, 37.798505), @"Did not set the correct latitude for the Melt House marker");
  XCTAssert(doubleCloseTo(marker.position.longitude, -122.430562), @"Did not set the correct longitude for the Melt House marker");
  XCTAssert([marker.title isEqualToString:@"Melt House"], @"Did not set the correct title text for the Melt House marker");
  XCTAssert(marker.snippet == nil, @"Did not set the correct snippet text for the Melt House marker");
  XCTAssert(marker.appearAnimation == 1, @"Did not set the correct animation constant for the Melt House marker");
  XCTAssert([appDel.imageNames[0] isEqualToString:@"marker-melt-house"], @"Did not set the correct icon for the Melt House marker");
  XCTAssert(marker.map == mapView, @"Did not display the Melt House marker with the correct map object");
}

- (void)testAddedTacoGogoMarker {
  AppDelegate *appDel =
  (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC =
  (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
  
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
  
  GMSMarker *marker;
  if(appDel.markers.count == 2) {
    if([[appDel.markers[0] title] isEqualToString:@"Taco Gogo"]) {
      marker = appDel.markers[0];
    } else if([[appDel.markers[1] title] isEqualToString:@"Taco Gogo"]) {
      marker = appDel.markers[1];
    }
  } else if(appDel.markers.count == 1) {
    marker = appDel.markers[0];
  } else {
    marker = [[GMSMarker alloc] init];
  }

  XCTAssert(doubleCloseTo(marker.position.latitude, 37.791384), @"Did not set the correct latitude for the Taco Gogo truck marker");
  XCTAssert(doubleCloseTo(marker.position.longitude, -122.439832), @"Did not set the correct longitude for the Taco Gogo truck marker");
  XCTAssert([marker.title isEqualToString:@"Taco Gogo"], @"Did not set the correct title text for the Taco Gogo truck marker");
  XCTAssert(marker.snippet == nil, @"Did not set the correct snippet text for the Taco Gogo truck marker");
  XCTAssert(marker.appearAnimation == 1, @"Did not set the correct animation constant for the Taco Gogo truck marker");
  XCTAssert([appDel.imageNames[1] isEqualToString:@"marker-taco-gogo"], @"Did not set the correct icon for the Melt House marker");
  XCTAssert(marker.map == mapView, @"Did not display the Taco Gogo truck marker with the correct map object");
}

@end
