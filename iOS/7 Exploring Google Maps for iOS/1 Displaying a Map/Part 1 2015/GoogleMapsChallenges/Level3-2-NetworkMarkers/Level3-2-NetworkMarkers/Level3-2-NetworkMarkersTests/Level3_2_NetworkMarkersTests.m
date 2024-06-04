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

@interface Level3_2_NetworkMarkersTests : CSRecordingTestCase {}

@end

@implementation Level3_2_NetworkMarkersTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  [super tearDown];
}

- (void)testDownloadMarkerData
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(1);
  
  XCTAssertNotNil(mapVC.downloadedMarkers, @"Did not download the marker data and send the parsed JSON to the createMarkerObjectsWithJson: method");
  
  NSArray *downloadedMarkers = (NSArray *)mapVC.downloadedMarkers;
  
  if (downloadedMarkers) {
    
    XCTAssertEqual(mapVC.calledQueue, [NSOperationQueue mainQueue], @"Make sure to call the createMarkerObjectsWithJson: in the main queue");
    XCTAssert([downloadedMarkers isKindOfClass:[NSArray class]], @"The marker data sent to createMarkerObjectsWithJson: should be an NSArray");
    
  }
}

- (void)testCreateMarkerObjects
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;
  
  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;
  
  sleep(1);
  
  NSSet *markers = [mapVC valueForKey:@"markers"];
  
  XCTAssert(markers.count == 6, @"Did not populate the self.markers set with TruckMarker objects in createMarkerObjectsWithJson:");
  
  if (markers.count > 0) {
    NSSortDescriptor *sortDescriptor;
    sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                 ascending:YES];
    NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
    NSArray *sortedArray;
    sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];
    
    TruckMarker *first = sortedArray.firstObject;
    TruckMarker *last = sortedArray.lastObject;
    
    XCTAssert([first isKindOfClass:[TruckMarker class]], @"The self.markers set should be populated with TruckMarker objects");
    
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wundeclared-selector"
    [mapVC performSelector:@selector(downloadMarkerData:) withObject:nil];
#pragma clang diagnostic pop
    
    sleep(0.5);
    
    markers = [mapVC valueForKey:@"markers"];
    
    sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                 ascending:YES];
    sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
    sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];

    XCTAssert(sortedArray.count == 6, @"Did not populate the self.markers set with TruckMarker objects in createMarkerObjectsWithJson:");
    
    XCTAssertEqualObjects(first.map, [mapVC valueForKey:@"mapView"], @"Did not set the map property of all the truck markers to the mapView");
    XCTAssertEqualObjects(last.map, [mapVC valueForKey:@"mapView"], @"Did not set the map property of all the truck markers to the mapView");
    
    XCTAssert([first.objectID isEqualToString:@"1"],@"Error");
    XCTAssert(doubleCloseTo(first.position.latitude, 37.798505), @"Did not set the correct latitude for the Melt House marker");
    XCTAssert(doubleCloseTo(first.position.longitude, -122.430562), @"Did not set the correct longitude for the Melt House marker");
    XCTAssert([first.title isEqualToString:@"Melt House"], @"Did not set the correct title text for the Melt House marker");
    XCTAssert(first.snippet == nil, @"Did not set the correct snippet text for the Melt House marker");
    XCTAssert(first.appearAnimation == 1, @"Did not set the correct animation constant for the Melt House marker");
    XCTAssert([appDel.markerImageNames[0] isEqualToString:@"marker-melt-house"], @"Did not set the correct icon for the Melt House marker");
    XCTAssert([appDel.logoImageNames[0] isEqualToString:@"melt-house"], @"Did not set the correct logo image for the Melt House marker");
    XCTAssert(first.map == mapVC.view.subviews[0], @"Did not display the Melt House marker with the correct map object");

    XCTAssert([last.objectID isEqualToString:@"6"],@"Error");
    XCTAssert(doubleCloseTo(last.position.latitude, 37.789666), @"Did not set the correct latitude for the Burger Bros marker");
    XCTAssert(doubleCloseTo(last.position.longitude, -122.418814), @"Did not set the correct longitude for the Burger Bros marker");
    XCTAssert([last.title isEqualToString:@"Burger Bros"], @"Did not set the correct title text for the Burger Bros marker");
    XCTAssert(last.snippet == nil, @"Did not set the correct snippet text for the Melt House marker");
    XCTAssert(last.appearAnimation == 1, @"Did not set the correct animation constant for the Burger Bros marker");
    XCTAssert([appDel.markerImageNames[5] isEqualToString:@"marker-burger-bros"], @"Did not set the correct icon for the Burger Bros marker");
    XCTAssert([appDel.logoImageNames[5] isEqualToString:@"burger-bros"], @"Did not set the correct logo image for the Burger Bros marker");
    XCTAssert(first.map == mapVC.view.subviews[0], @"Did not display the Burger Bros marker with the correct map object");
}
}

@end
