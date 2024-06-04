//
//  GMSMarker+ZSwizzles.m
//  Level2-3-CustomInfoWindow
//
//  Created by Jon Friskics on 2/17/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSMarker+ZSwizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSMarker (ZSwizzles)

static void CustomSetMap(id, SEL, GMSMapView *);

static void (*CustomSetMapIMP)(id, SEL, GMSMapView *);

static void CustomSetMap(id self, SEL _cmd, GMSMapView *mapView) {
  CustomSetMapIMP(self, _cmd, mapView);
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];

  if([[self title] compare:@"melt house" options:NSCaseInsensitiveSearch] == 0 || [[self title] compare:@"taco gogo" options:NSCaseInsensitiveSearch] == 0) {
    NSMutableArray *mutableMarkers = [[NSMutableArray alloc] initWithArray:appDelegate.markers];
    [mutableMarkers addObject:self];
    appDelegate.markers = [mutableMarkers copy];
  }
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSMarker"]
             replaceMethod:@selector(setMap:)
        withImplementation:(IMP)CustomSetMap
                   storeIn:(IMP *)&CustomSetMapIMP];
}

@end
