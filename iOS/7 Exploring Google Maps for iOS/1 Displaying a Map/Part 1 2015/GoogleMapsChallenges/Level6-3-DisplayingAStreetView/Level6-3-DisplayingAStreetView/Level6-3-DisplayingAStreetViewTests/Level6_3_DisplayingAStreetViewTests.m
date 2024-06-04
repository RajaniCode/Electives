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

#define kDoubleEpsilon (0.000001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}
@interface Level6_3_DisplayingAStreetViewTests : CSRecordingTestCase {}

@property BOOL alreadyRun;

@end

@implementation Level6_3_DisplayingAStreetViewTests

- (void)setUp {
  static dispatch_once_t onceToken;
  dispatch_once(&onceToken, ^{
    [GMSServices provideAPIKey:@"AIzaSyBscqE32ptEsr9Xf5jIzzNpbhjFznjcXZM"];
  });
  [super setUp];
}

- (void)tearDown {
  [super tearDown];

  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  [navVC popToRootViewControllerAnimated:NO];
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  GMSMapView *mapView = (GMSMapView *)mapVC.view.subviews[0];
  mapView.selectedMarker = nil;
  mapVC.navigationItem.rightBarButtonItem = nil;
  
  [mapVC.navigationController popToRootViewControllerAnimated:NO];
}


- (void)testCameraCreatedWithCorrectOptions
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
        
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
        [mapVC.navigationItem.rightBarButtonItem.target performSelector:mapVC.navigationItem.rightBarButtonItem.action withObject:mapVC.navigationItem.rightBarButtonItem];
#pragma clang diagnostic pop
        
        sleep(1);
        
        StreetViewVC *streetViewVC;
        if([navVC.visibleViewController cs_isSameClassAs:[StreetViewVC class]]) {
          streetViewVC = (StreetViewVC *)navVC.visibleViewController;
          
          [streetViewVC viewDidAppear:NO];
          
          [[NSRunLoop currentRunLoop] runUntilDate:[NSDate dateWithTimeIntervalSinceNow:2.0]];
          
          GMSPanoramaCamera *camera1 = appDel.camera;
          
          XCTAssert(doubleCloseTo(camera1.orientation.heading, 210), @"Did not set the right heading");
          XCTAssert(doubleCloseTo(camera1.orientation.pitch, 10.000), @"Did not set the right pitch");
          XCTAssert(doubleCloseTo(camera1.zoom, 2.000), @"Did not set the right zoom");
          XCTAssert(doubleCloseTo(camera1.FOV, 90.000), @"Did not set the right FOV");
        }
      }
    } else {
      XCTFail(@"The show street view button should not be visible until a marker is tapped");
    }
  }
}

- (void)testCreatedPanoramaViewObject
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
        
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
        [mapVC.navigationItem.rightBarButtonItem.target performSelector:mapVC.navigationItem.rightBarButtonItem.action withObject:mapVC.navigationItem.rightBarButtonItem];
#pragma clang diagnostic pop
        
        sleep(1);
        
        StreetViewVC *streetViewVC;
        if([navVC.visibleViewController cs_isSameClassAs:[StreetViewVC class]]) {
          streetViewVC = (StreetViewVC *)navVC.visibleViewController;
          
          [streetViewVC viewDidAppear:NO];
          
          [[NSRunLoop currentRunLoop] runUntilDate:[NSDate dateWithTimeIntervalSinceNow:2.0]];
          
          GMSPanoramaCamera *camera1 = appDel.camera;
          GMSPanorama *panorama1 = appDel.panorama;
          GMSPanoramaView *panoramaView = appDel.panoramaView;
          
          if(panoramaView != nil) {
            XCTAssert(doubleCloseTo(camera1.orientation.heading, panoramaView.camera.orientation.heading) && doubleCloseTo(camera1.orientation.pitch, panoramaView.camera.orientation.pitch) && doubleCloseTo(camera1.zoom, panoramaView.camera.zoom) && doubleCloseTo(camera1.FOV, panoramaView.camera.FOV), @"Did not set the GMSPanoramaCamera property in the GMSPanoramaView object.");
            XCTAssert(panoramaView.panorama == panorama1, @"Did not set the GMSPanorama property in the GMSPanoramaView object.");
          } else {
            XCTFail(@"Did not create a GMSPanoramaView object");
          }
        }
      }
    } else {
      XCTFail(@"The show street view button should not be visible until a marker is tapped");
    }
  }
}

- (void)testViewReplacedWithStreetView
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
        
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Warc-performSelector-leaks"
        [mapVC.navigationItem.rightBarButtonItem.target performSelector:mapVC.navigationItem.rightBarButtonItem.action withObject:mapVC.navigationItem.rightBarButtonItem];
#pragma clang diagnostic pop
        
        sleep(1);
        
        StreetViewVC *streetViewVC;
        if([navVC.visibleViewController cs_isSameClassAs:[StreetViewVC class]]) {
          streetViewVC = (StreetViewVC *)navVC.visibleViewController;
          
          [streetViewVC viewDidAppear:NO];
          
          [[NSRunLoop currentRunLoop] runUntilDate:[NSDate dateWithTimeIntervalSinceNow:2.0]];
          
          XCTAssert([streetViewVC.view cs_isSameClassAs:[GMSPanoramaView class]], @"Did not reset self.view to the GMSPanoramaView");
        }
      }
    } else {
      XCTFail(@"The show street view button should not be visible until a marker is tapped");
    }
  }
}

@end
