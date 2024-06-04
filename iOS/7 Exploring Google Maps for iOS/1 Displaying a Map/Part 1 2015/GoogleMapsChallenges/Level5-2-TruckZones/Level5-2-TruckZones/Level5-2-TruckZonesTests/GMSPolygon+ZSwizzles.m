//
//  GMSPolygon+ZSwizzles.m
//  Level5-2-TruckZones
//
//  Created by Jon Friskics on 2/27/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSPolygon+ZSwizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSPolygon (ZSwizzles)

static void CustomSetMap(id, SEL, GMSMapView *);

static void (*CustomSetMapIMP)(id, SEL, GMSMapView *);

static void CustomSetMap(id self, SEL _cmd, GMSMapView *mapView) {
  CustomSetMapIMP(self, _cmd, mapView);

  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];

  if([self title] == nil) {
    NSMutableArray *mutablePolygons = [[NSMutableArray alloc] initWithArray:appDelegate.polygons];
    [mutablePolygons addObject:self];
    appDelegate.polygons = [mutablePolygons copy];
  }
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSPolygon"]
             replaceMethod:@selector(setMap:)
        withImplementation:(IMP)CustomSetMap
                   storeIn:(IMP *)&CustomSetMapIMP];
}

@end
