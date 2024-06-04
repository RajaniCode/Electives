#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>
#import <objc/runtime.h>

#import "CSRecordingTestCase.h"
#import "CSPropertyDefinition.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"
#import "TruckMarker.h"

#import "TruckMapVC+Swizzles.h"

@interface Level3_3_InTheShopTests : CSRecordingTestCase {}

@end

@implementation Level3_3_InTheShopTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  [super tearDown];
}

- (void)testInTheShopProperty
{
  CSPropertyDefinition *inTheShopProp = [CSPropertyDefinition propertyWithTypeEncoding:@encode(BOOL) forClass:[TruckMarker class]];
  
  XCTAssertNotNil(inTheShopProp, @"Did not add a BOOL 'inTheShop' property to the TruckMarker class");
  
  if(inTheShopProp)
  {
    XCTAssert([inTheShopProp.name isEqualToString:@"inTheShop"], @"Did not add a BOOL 'inTheShop' property to the TruckMarker class");
  }
}

- (void)testPopulatingTruckMarkerData
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];

  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;

  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;

  sleep(1);

  NSSet *markers = [mapVC valueForKey:@"markers"];

  XCTAssert(markers.count == 6, @"Did not populate the self.markers set with TruckMarker objects in createMarkerObjectsWithJson:");

  if (markers.count > 0) {
    TruckMarker *first = markers.allObjects.firstObject;

    XCTAssert([first isKindOfClass:[TruckMarker class]], @"The self.markers set should be populated with TruckMarker objects");

    XCTAssert([appDel.inTheShopCount intValue] == 6, @"Did not populate the TruckMarker instances with the inTheStop property");
  }
}

- (void)testOnlyDrawShopMarkers
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];

  UINavigationController *navVC = (UINavigationController *)appDel.window.rootViewController;

  TruckMapVC *mapVC = (TruckMapVC *)navVC.topViewController;

  sleep(1);

  NSSet *markers = [mapVC valueForKey:@"markers"];

  XCTAssert(markers.count == 6, @"Did not populate the self.markers set with TruckMarker objects in createMarkerObjectsWithJson:");

  if (markers.count > 0) {
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wundeclared-selector"
    [mapVC performSelector:@selector(downloadMarkerData:) withObject:nil];
#pragma clang diagnostic pop

    sleep(1);

    markers = [mapVC valueForKey:@"markers"];
    
    NSSortDescriptor *sortDescriptor;
    sortDescriptor = [[NSSortDescriptor alloc] initWithKey:@"objectID"
                                                 ascending:YES];
    NSArray *sortDescriptors = [NSArray arrayWithObject:sortDescriptor];
    NSArray *sortedArray;
    sortedArray = [markers sortedArrayUsingDescriptors:sortDescriptors];

    XCTAssertNil([sortedArray[1] map], @"Markers where inTheShop == YES should not be displayed on the map");
    XCTAssertNotNil([sortedArray[0] map], @"Markers where inTheShop == NO should be displayed on the map");
  }


}

@end
