#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>
#import <objc/runtime.h>

#import "CSRecordingTestCase.h"
#import "CSPropertyDefinition.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"
#import "TruckMarker.h"

#import "XCTestCase+AsyncTesting.h"
#import "TruckMapVC+Swizzles.h"

#define kDoubleEpsilon (0.000001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}
@interface Level5_3_DirectionsLineTests : CSRecordingTestCase {}

@end

@implementation Level5_3_DirectionsLineTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  [super tearDown];
}

- (void)testPolylineDrawnWhenMarkerTapped
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  GMSMapView *mapView = (GMSMapView *)mapVC.view.subviews[0];
  
  sleep(1);
  
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
    
    sleep(2);

    id steps = mapVC.steps;
    
    if(steps == nil) {
      XCTFail(@"The Directions API request failed, so you don't have a way to draw the directions polyline.");
    } else {
      appDel.blockName();
      XCTAssertNotNil(appDel.polyline, @"Did not draw a polyline when a marker was tapped");
      if(appDel.polyline != nil) {
        NSString *directionsExpectedPath = @"__teFp|gjVk@yH_JhAqDb@uDb@e@{Ii@gI}Dj@wJfAwC\\";
        XCTAssert([appDel.polyline.path.encodedPath isEqualToString:directionsExpectedPath], @"Did not use the correct path for Melt House");
        const float* meltHouseStrokeColors = CGColorGetComponents(appDel.polyline.strokeColor.CGColor);
        XCTAssert(doubleCloseTo(meltHouseStrokeColors[0], 0.0862745) && doubleCloseTo(meltHouseStrokeColors[1], 0.584314) && doubleCloseTo(meltHouseStrokeColors[2], 0.929412) && doubleCloseTo(meltHouseStrokeColors[3], 1.00000), @"Did not use the right stroke color for the directions line");
        XCTAssert(appDel.polyline.strokeWidth == 4, @"Did not use the right strokeWidth for the directions line");
      }
    }
  } else {
    XCTFail(@"For some reason the markers weren't created.  The code to create the markers was in this project when you opened it, so if you haven't changed anything it's possible you're having network issues");
  }
}

- (void)testPolylineHiddenWhenMapTapped
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  GMSMapView *mapView = (GMSMapView *)mapVC.view.subviews[0];
  
  sleep(1);
  
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
    
    sleep(2);
    
    id steps = mapVC.steps;
    
    if(steps == nil) {
      XCTFail(@"The Directions API request failed, so you don't have a way to draw the directions polyline.");
    } else {
      appDel.blockName();
      GMSMutablePath *path = [[GMSMutablePath alloc] init];
      [path addLatitude:0 longitude:0];
      [path addLatitude:1 longitude:1];
      mapVC.directionsLine = [GMSPolyline polylineWithPath:[path copy]];
      mapVC.directionsLine.map = mapView;
      
      CLLocationCoordinate2D coord = CLLocationCoordinate2DMake(37, -122);
      
      NSException *e;
      
      @try {
        [mapView.delegate mapView:mapView didTapAtCoordinate:coord];
      }
      @catch (NSException *exception) {
        XCTAssertNil(exception.reason, @"Did not implement the mapView:didTapAtCoordinate: method");
        e = exception;
      }
      @finally {
        if(e == nil) {
          XCTAssertNil(appDel.polyline.map, @"Did not turn off the directionsLine when the was tapped in a non-marker location");
          XCTAssertNil(appDel.polyline, @"Did not nil out the directionsLine when the was tapped in a non-marker location");
        }
      }
      
    }
  } else {
    XCTFail(@"For some reason the markers weren't created.  The code to create the markers was in this project when you opened it, so if you haven't changed anything it's possible you're having network issues");
  }
}

@end
