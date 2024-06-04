//
//  GMSPanoramaCamera+Swizzles.m
//  Level6-3-DisplayingAStreetView
//
//  Created by Jon Friskics on 4/6/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSPanoramaCamera+Swizzles.h"
#import "CSSwizzler.h"
#import "AppDelegate+TestAdditions.h"

@implementation GMSPanoramaCamera (Swizzles)

static id CustomCameraWithHeading(id, SEL, CLLocationDirection, double, float, double);

static id (*CustomCameraWithHeadingIMP)(id, SEL, CLLocationDirection, double, float, double);

static id CustomCameraWithHeading(id self, SEL _cmd, CLLocationDirection direction, double pitch, float zoom, double fov) {
  GMSPanoramaCamera *camera = CustomCameraWithHeadingIMP(self, _cmd, direction, pitch, zoom, fov);
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.camera = camera;
  
  return camera;
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSPanoramaCamera"]
        replaceClassMethod:@selector(cameraWithHeading:pitch:zoom:FOV:)
        withImplementation:(IMP)CustomCameraWithHeading
                   storeIn:(IMP *)&CustomCameraWithHeadingIMP];
  
}

@end
