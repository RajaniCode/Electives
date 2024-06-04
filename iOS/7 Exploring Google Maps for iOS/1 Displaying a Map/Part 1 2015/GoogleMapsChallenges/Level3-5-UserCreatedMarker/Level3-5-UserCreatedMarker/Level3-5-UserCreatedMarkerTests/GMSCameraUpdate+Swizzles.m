//
//  GMSCameraUpdate+Swizzles.m
//  Level3-5-UserCreatedMarker
//
//  Created by Jon Friskics on 3/19/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSCameraUpdate+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSCameraUpdate (Swizzles)

static GMSCameraUpdate * CustomSetTarget(id, SEL, CLLocationCoordinate2D);

static GMSCameraUpdate * (*CustomSetTargetIMP)(id, SEL, CLLocationCoordinate2D);

static GMSCameraUpdate * CustomSetTarget(id self, SEL _cmd, CLLocationCoordinate2D coordinate) {
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  
  appDelegate.camUpdateLat = @(coordinate.latitude);
  appDelegate.camUpdateLng = @(coordinate.longitude);
  
  return CustomSetTargetIMP(self, _cmd, coordinate);
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSCameraUpdate"]
        replaceClassMethod:@selector(setTarget:)
        withImplementation:(IMP)CustomSetTarget
                   storeIn:(IMP *)&CustomSetTargetIMP];
}

@end
