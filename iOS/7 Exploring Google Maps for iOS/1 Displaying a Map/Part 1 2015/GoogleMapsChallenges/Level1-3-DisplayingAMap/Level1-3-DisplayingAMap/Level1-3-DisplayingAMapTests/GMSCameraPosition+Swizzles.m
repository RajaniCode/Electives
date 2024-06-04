//
//  GMSCameraPosition+Swizzles.m
//  Level1-3-DisplayingAMap
//
//  Created by Jon Friskics on 4/6/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSCameraPosition+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSCameraPosition (Swizzles)

static id CustomCameraPosition(id, SEL, CLLocationDegrees, CLLocationDegrees, float, CLLocationDirection, double);

static id (*CustomCameraPositionIMP)(id, SEL, CLLocationDegrees, CLLocationDegrees, float, CLLocationDirection, double);

static id CustomCameraPosition(id self, SEL _cmd, CLLocationDegrees latDegrees, CLLocationDegrees lngDegrees, float zoom, CLLocationDirection bearing, double viewingAngle){
  
  GMSCameraPosition *cameraPosition = CustomCameraPositionIMP(self, _cmd, latDegrees, lngDegrees, zoom, bearing, viewingAngle);
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.cameraPositionObject = cameraPosition;
  
  return cameraPosition;
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSCameraPosition"]
        replaceClassMethod:@selector(cameraWithLatitude:longitude:zoom:bearing:viewingAngle:)
        withImplementation:(IMP)CustomCameraPosition
                   storeIn:(IMP *)&CustomCameraPositionIMP];
}

@end
