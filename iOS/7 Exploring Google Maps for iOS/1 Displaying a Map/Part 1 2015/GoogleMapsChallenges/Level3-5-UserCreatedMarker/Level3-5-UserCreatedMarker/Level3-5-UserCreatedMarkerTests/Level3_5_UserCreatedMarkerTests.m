#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>
#import <objc/runtime.h>

#import "CSRecordingTestCase.h"
#import "CSPropertyDefinition.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"
#import "TruckMarker.h"

#import "TruckMapVC+Swizzles.h"

#define kDoubleEpsilon (0.00001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}

@interface Level3_5_UserCreatedMarkerTests : CSRecordingTestCase {}

@end

@implementation Level3_5_UserCreatedMarkerTests

- (void)setUp {
  [super setUp];
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.userMarkers = @[];
  appDelegate.nilCount = @(0);
  appDelegate.callCount = @(0);
  appDelegate.animateWithCameraUpdateCalled = @(0);
  appDelegate.moveCameraArg = nil;
  appDelegate.camUpdateLat = @(0.0);
  appDelegate.camUpdateLng = @(0.0);
}

- (void)tearDown {
  [super tearDown];
}

- (void)testDrawMarkersCalledFromDidTapAtCoordinate
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(1);
  
  GMSMapView *mapView = mapVC.view.subviews[0];

  if(appDel.userMarkers.count == 0) {
    [mapView.delegate mapView:mapView didTapAtCoordinate:CLLocationCoordinate2DMake(1, 1)];
    
    XCTAssert(([appDel.nilCount intValue] == 1 && [appDel.callCount intValue] == 1) || ([appDel.nilCount intValue] == 2 && [appDel.callCount intValue] == 1), @"Did not call the drawMarkers method at the end of the mapView:didTapAtCoordinate: method after the marker was created.");
    
    TruckMarker *marker = [mapVC valueForKey:@"userCreatedMarker"];
    marker = nil;
  }
}

- (void)testReplacingOldMarkerOnCoordinateTap
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];

  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;

  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;

  sleep(1);
  
  GMSMapView *mapView = mapVC.view.subviews[0];
  
  if(appDel.userMarkers.count == 0) {
    [mapView.delegate mapView:mapView didTapAtCoordinate:CLLocationCoordinate2DMake(1, 1)];
    
    if([appDel.nilCount intValue] == 1) {
      [mapView.delegate mapView:mapView didTapAtCoordinate:CLLocationCoordinate2DMake(1, 1)];
      XCTAssert([appDel.nilCount intValue] == 3 || [appDel.nilCount intValue] == 4, @"Did not set the user created marker's map property to nil at the start of the mapView:didTapAtCoordinate: method");
      TruckMarker *marker = [mapVC valueForKey:@"userCreatedMarker"];
      marker = nil;
    }

  } else {
    XCTFail(@"Something went wrong - there shouldn't be any user created markers until the map is tapped!");
  }
}

- (void)testCreatingCameraUpdate
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(1);
  
  GMSMapView *mapView = mapVC.view.subviews[0];
  
  if(appDel.userMarkers.count == 0) {
    [mapView.delegate mapView:mapView didTapAtCoordinate:CLLocationCoordinate2DMake(1, 1)];
  #pragma clang diagnostic push
  #pragma clang diagnostic ignored "-Wundeclared-selector"
    [mapVC performSelector:@selector(drawMarkers)];
  #pragma clang diagnostic pop
    if(appDel.camUpdateLat && appDel.camUpdateLng) {
      XCTAssert(doubleCloseTo([appDel.camUpdateLat doubleValue], 1) && doubleCloseTo([appDel.camUpdateLng doubleValue], 1), @"Did not create a GMSCameraUpdate object targeted at the coordinate of the user created marker");
    }
    
    TruckMarker *marker = [mapVC valueForKey:@"userCreatedMarker"];
    marker = nil;
  } else {
    XCTFail(@"Something went wrong - there shouldn't be any user created markers until the map is tapped!");
  }
}

- (void)testMovingMapAfterCameraUpdate
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(1);
  
  GMSMapView *mapView = mapVC.view.subviews[0];
  
  if(appDel.userMarkers.count == 0) {
    [mapView.delegate mapView:mapView didTapAtCoordinate:CLLocationCoordinate2DMake(1, 1)];
    
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wundeclared-selector"
    [mapVC performSelector:@selector(drawMarkers)];
#pragma clang diagnostic pop

    XCTAssert([appDel.animateWithCameraUpdateCalled boolValue] == YES, @"Did not call the animateWithCameraUpdate: method after creating a GMSCameraUpdate object");
    
    TruckMarker *marker = [mapVC valueForKey:@"userCreatedMarker"];
    marker = nil;

  } else {
    XCTFail(@"Something went wrong - there shouldn't be any user created markers until the map is tapped!");
  }
}

@end
