//
//  GMSMapView+Swizzles.m
//  Level3-5-UserCreatedMarker
//
//  Created by Jon Friskics on 3/19/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSMapView+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSMapView (Swizzles)

static void CustomAnimateWithCameraUpdate(id, SEL, GMSCameraUpdate *);

static void (*CustomAnimateWithCameraUpdateIMP)(id, SEL, GMSCameraUpdate *);

static void CustomAnimateWithCameraUpdate(id self, SEL _cmd, GMSCameraUpdate *cameraUpdate) {
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  
  appDelegate.animateWithCameraUpdateCalled = @(YES);
  appDelegate.moveCameraArg = cameraUpdate;
  
  CustomAnimateWithCameraUpdateIMP(self, _cmd, cameraUpdate);
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]
             replaceMethod:@selector(animateWithCameraUpdate:)
        withImplementation:(IMP)CustomAnimateWithCameraUpdate
                   storeIn:(IMP *)&CustomAnimateWithCameraUpdateIMP];
}

@end
