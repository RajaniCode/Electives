//
//  TruckMarker+Swizzles.m
//  Level3-5-UserCreatedMarker
//
//  Created by Jon Friskics on 3/19/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMarker+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

#define kDoubleEpsilon (0.00001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}

@implementation TruckMarker (Swizzles)

static void CustomSetMap(id, SEL, GMSMapView *);

static void (*CustomSetMapIMP)(id, SEL, GMSMapView *);

static void CustomSetMap(id self, SEL _cmd, GMSMapView *mapView) {
  CustomSetMapIMP(self, _cmd, mapView);
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  
  if([[(TruckMarker *)self title] isEqualToString:@"User marker"]) {
    if(mapView == nil) {
      appDelegate.nilCount = @([appDelegate.nilCount intValue] + 1);
    } else if(mapView != nil) {
      appDelegate.callCount = @([appDelegate.callCount intValue] + 1);
    }
    
    NSMutableArray *mutableMarkers = [[NSMutableArray alloc] initWithArray:appDelegate.userMarkers];
    if(mutableMarkers.count > 0) {
      if(doubleCloseTo([(TruckMarker *)self position].latitude, [(TruckMarker *)mutableMarkers[0] position].latitude) &&
         doubleCloseTo([(TruckMarker *)self position].longitude, [(TruckMarker *)mutableMarkers[0] position].longitude)) {
      } else {
        [mutableMarkers addObject:self];
      }
    } else {
      [mutableMarkers addObject:self];
    }
    appDelegate.userMarkers = [mutableMarkers copy];
  }
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"TruckMarker"]
             replaceMethod:@selector(setMap:)
        withImplementation:(IMP)CustomSetMap
                   storeIn:(IMP *)&CustomSetMapIMP];
}

@end
