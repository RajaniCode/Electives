//
//  GMSPolyline+Swizzles.m
//  Level6-2-StreetViewSetup
//
//  Created by Jon Friskics on 2/28/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSPolyline+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSPolyline (Swizzles)

static void CustomSetMap(id, SEL, GMSMapView *);

static void (*CustomSetMapIMP)(id, SEL, GMSMapView *);

static void CustomSetMap(id self, SEL _cmd, GMSMapView *mapView) {
  CustomSetMapIMP(self, _cmd, mapView);
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  
  appDelegate.polyline = self;
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSPolyline"]
             replaceMethod:@selector(setMap:)
        withImplementation:(IMP)CustomSetMap
                   storeIn:(IMP *)&CustomSetMapIMP];
}

@end
