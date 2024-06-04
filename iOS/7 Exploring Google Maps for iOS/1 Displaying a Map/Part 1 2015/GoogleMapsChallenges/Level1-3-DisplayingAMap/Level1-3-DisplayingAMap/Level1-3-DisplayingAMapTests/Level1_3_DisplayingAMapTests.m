#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>

#import "CSRecordingTestCase.h"
#import "CSPropertyDefinition.h"

#import "AppDelegate.h"
#import "TruckMapVC.h"

#import "GMSMapView+ZSwizzles.h"
#import "AppDelegate+TestAdditions.h"

#define kDoubleEpsilon (0.001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}

@interface Level1_3_DisplayingAMapTests : CSRecordingTestCase {
  AppDelegate *_appDel;
}

@end

@implementation Level1_3_DisplayingAMapTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  [super tearDown];
}

- (void)testMapViewCreated {
  AppDelegate *appDel =
      (AppDelegate *)[[UIApplication sharedApplication] delegate];

  UINavigationController *navVC =
      (UINavigationController *)appDel.window.rootViewController;

  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];

  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews].firstObject;

  if(appDel.mapView && !(mapView && [mapView isKindOfClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]])) {
    XCTFail(@"You created a GMSMapView object, but you didn't add it as a subview of self.view in TruckMapVC");
  } else if(appDel.mapView && mapView && [mapView isKindOfClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]]) {
    XCTAssert(YES);
  } else {
    XCTFail(@"Did not create and add a GMSMapView to the TruckMapVC view");
  }
}

- (void)testMapViewCamera {
  AppDelegate *appDel =
  (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC =
  (UINavigationController *)appDel.window.rootViewController;
  
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wunused-variable"
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
#pragma clang diagnostic pop
  
  GMSCameraPosition *cameraPosition = appDel.cameraPositionObject;
  
  if (cameraPosition != nil) {
    XCTAssert(doubleCloseTo(cameraPosition.target.latitude, 37.790706), @"Did not set the GMSCameraPosition to the specified latitude");
    XCTAssert(doubleCloseTo(cameraPosition.target.longitude, -122.434167), @"Did not set the GMSCameraPosition to the specified longitude");
    XCTAssert(doubleCloseTo(cameraPosition.zoom, 13), @"Did not set the GMSCameraPosition to the specified zoom");
    XCTAssert(doubleCloseTo(cameraPosition.bearing, 0), @"Did not set the GMSCameraPosition to the specified bearing");
    XCTAssert(doubleCloseTo(cameraPosition.viewingAngle, 0), @"Did not set the GMSCameraPosition to the specified viewing angle");
  } else {
    XCTFail(@"Did not create a GMSCameraPosition object with the correct settings");
  }
}

- (void)testMapViewPadding {
  AppDelegate *appDel =
  (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC =
  (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
  
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews].firstObject;
  
  if (mapView && [mapView isKindOfClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]]) {
    XCTAssert(mapView.padding.top > 0, @"Did not set top map padding");
  } else {
    XCTFail(@"Did not create a GMSMapView object and add it to self.view - try doing that first");
  }
}

- (void)testMapViewType
{
  AppDelegate *appDel =
  (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC =
  (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
  
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews].firstObject;
  
  if (mapView && [mapView isKindOfClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]]) {
    XCTAssert(mapView.mapType == 3, @"Did not set the mapType to kGMSMapTypeTerrain");
  } else {
    XCTFail(@"Did not create a GMSMapView object and add it to self.view - try doing that first");
  }
}

- (void)testMapSettings
{
  AppDelegate *appDel =
  (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC =
  (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
  
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews].firstObject;
  
  if (mapView && [mapView isKindOfClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]]) {
    XCTAssertTrue(mapView.settings.compassButton, @"Did not turn on the compassButton");
    XCTAssertTrue(mapView.myLocationEnabled, @"Did not turn on the user location dot");
    XCTAssertFalse(mapView.settings.zoomGestures, @"Did not turn off zoom gestures");
  } else {
    XCTFail(@"Did not create a GMSMapView object and add it to self.view - try doing that first");
  }
}

@end
