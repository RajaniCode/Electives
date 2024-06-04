#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>
#import <objc/runtime.h>

#import "CSRecordingTestCase.h"
#import "CSPropertyDefinition.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"
#import "TruckMarker.h"
#import "StreetViewVC.h"

#import "XCTestCase+AsyncTesting.h"
#import "TruckMapVC+Swizzles.h"
#import "NSObject+StringClassComparison.h"
#import "StreetViewVC+Swizzles.h"

#define kDoubleEpsilon (0.001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}
@interface Level6_2_StreetViewSetupTests : CSRecordingTestCase {}

@end

@implementation Level6_2_StreetViewSetupTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  [navVC popToRootViewControllerAnimated:NO];
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  GMSMapView *mapView = (GMSMapView *)mapVC.view.subviews[0];
  mapView.selectedMarker = nil;
  mapVC.navigationItem.rightBarButtonItem = nil;

  [super tearDown];
}

- (void)testStreetViewButtonShownOnMarkerTap
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  GMSMapView *mapView = (GMSMapView *)mapVC.view.subviews[0];
  
  sleep(1);
  
  if(mapVC.navigationItem.rightBarButtonItem == nil) {
    NSSet *markers = [mapVC valueForKey:@"markers"];
    
    NSSortDescriptor *sortDescriptor;
    sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                 ascending:YES];
    NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
    NSArray *sortedArray;
    sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];

    if(markers.count > 0) {
      TruckMarker *first = sortedArray.firstObject;
      [mapView.delegate mapView:mapView didTapMarker:first];
      
      XCTAssertNotNil(mapVC.navigationItem.rightBarButtonItem, @"Did not set the navigation item's rightBarButtonItem after a marker is tapped");
    }
  } else {
    XCTFail(@"The show street view button should not be visible until a marker is tapped");
  }
}


- (void)testStreetViewButtonHiddenOnMapTap
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  GMSMapView *mapView = (GMSMapView *)mapVC.view.subviews[0];
  
  sleep(1);
  
  if(mapVC.navigationItem.rightBarButtonItem == nil) {
    NSSet *markers = [mapVC valueForKey:@"markers"];
    
    NSSortDescriptor *sortDescriptor;
    sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                 ascending:YES];
    NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
    NSArray *sortedArray;
    sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];

    if(markers.count > 0) {
      TruckMarker *first = sortedArray.firstObject;
      [mapView.delegate mapView:mapView didTapMarker:first];
      
      XCTAssertNotNil(mapVC.navigationItem.rightBarButtonItem, @"Did not set the navigation item's rightBarButtonItem after a marker is tapped");
      
      [mapView.delegate mapView:mapView didTapAtCoordinate:CLLocationCoordinate2DMake(0, 0)];
      
      XCTAssertNil(mapVC.navigationItem.rightBarButtonItem, @"Did not remove the navigation item's rightBarButtonItem after the map is tapped at a location without a marker");
    }
  } else {
    XCTFail(@"The show street view button should not be visible until a marker is tapped");
  }
}


- (void)testCorrectActiveMarkerCoordinateSet
{
  {
    AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
    
    UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
    
    TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
    
    GMSMapView *mapView = (GMSMapView *)mapVC.view.subviews[0];
    
    sleep(1);
    
    if(mapVC.navigationItem.rightBarButtonItem == nil) {
      NSSet *markers = [mapVC valueForKey:@"markers"];
      
      NSSortDescriptor *sortDescriptor;
      sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                   ascending:YES];
      NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
      NSArray *sortedArray;
      sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];

      if(markers.count > 0) {
        TruckMarker *first = sortedArray.firstObject;
        [mapView.delegate mapView:mapView didTapMarker:first];
        
        XCTAssertNotNil(mapVC.navigationItem.rightBarButtonItem, @"Did not set the navigation item's rightBarButtonItem after a marker is tapped");
        XCTAssert([NSStringFromSelector(mapVC.navigationItem.rightBarButtonItem.action) isEqualToString:@"showStreetView:"], @"Did not set the rightBarButtonItem's action to showStreetView:");
        
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
        [mapVC.navigationItem.rightBarButtonItem.target performSelector:mapVC.navigationItem.rightBarButtonItem.action withObject:mapVC.navigationItem.rightBarButtonItem];
#pragma clang diagnostic pop
        
        sleep(1);
        
        StreetViewVC *streetViewVC;
        if([navVC.visibleViewController cs_isSameClassAs:[StreetViewVC class]]) {
          streetViewVC = (StreetViewVC *)navVC.visibleViewController;
        }
        
        BOOL activeMarkerCoordinateCorrectlySet = doubleCloseTo([mapVC.latitude floatValue], 37.798505) && doubleCloseTo([mapVC.longitude floatValue], -122.430562);
        
        XCTAssert(activeMarkerCoordinateCorrectlySet, @"Did not set self.activeMarkerCoordinate to the currently tapped marker's coordinate");
      }
    } else {
      XCTFail(@"The show street view button should not be visible until a marker is tapped");
    }
  }
}


- (void)testCorrectCoordinateSentToStreetView
{
  {
    AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
    
    UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
    
    TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
    
    GMSMapView *mapView = (GMSMapView *)mapVC.view.subviews[0];
    
    sleep(1);
    
    if(mapVC.navigationItem.rightBarButtonItem == nil) {
      NSSet *markers = [mapVC valueForKey:@"markers"];
      
      NSSortDescriptor *sortDescriptor;
      sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                   ascending:YES];
      NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
      NSArray *sortedArray;
      sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];

      if(markers.count > 0) {
        TruckMarker *first = sortedArray.firstObject;
        [mapView.delegate mapView:mapView didTapMarker:first];
        
        XCTAssertNotNil(mapVC.navigationItem.rightBarButtonItem, @"Did not set the navigation item's rightBarButtonItem after a marker is tapped");
        XCTAssert([NSStringFromSelector(mapVC.navigationItem.rightBarButtonItem.action) isEqualToString:@"showStreetView:"], @"Did not set the rightBarButtonItem's action to showStreetView:");

#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
        [mapVC.navigationItem.rightBarButtonItem.target performSelector:mapVC.navigationItem.rightBarButtonItem.action withObject:mapVC.navigationItem.rightBarButtonItem];
#pragma clang diagnostic pop
        
        sleep(1);
        
        StreetViewVC *streetViewVC;
        if([navVC.visibleViewController cs_isSameClassAs:[StreetViewVC class]]) {
          streetViewVC = (StreetViewVC *)navVC.visibleViewController;
          BOOL streetViewCoordinateCorrectlySet = doubleCloseTo([streetViewVC.latitude floatValue], 37.798505) && doubleCloseTo([streetViewVC.longitude floatValue], -122.430562);
          
          XCTAssert(streetViewCoordinateCorrectlySet, @"Did not pass the activeMarkerCoordinate to the StreetViewVC when the street view bar button was tapped.");
        }
      }
    } else {
      XCTFail(@"The show street view button should not be visible until a marker is tapped");
    }
  }
}

@end
