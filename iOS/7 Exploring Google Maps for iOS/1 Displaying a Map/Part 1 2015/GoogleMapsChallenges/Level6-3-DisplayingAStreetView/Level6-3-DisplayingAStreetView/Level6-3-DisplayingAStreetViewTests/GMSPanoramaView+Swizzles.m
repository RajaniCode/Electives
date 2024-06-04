//
//  GMSPanoramaView+Swizzles.m
//  Level6-3-DisplayingAStreetView
//
//  Created by Jon Friskics on 3/5/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSPanoramaView+Swizzles.h"
#import "CSSwizzler.h"
#import "AppDelegate+TestAdditions.h"

@implementation GMSPanoramaView (Swizzles)

static void CustomSetCamera(id, SEL, GMSPanoramaCamera *);

static void (*CustomSetCameraIMP)(id, SEL, GMSPanoramaCamera *);

static void CustomSetCamera(id self, SEL _cmd, GMSPanoramaCamera *camera) {
  CustomSetCameraIMP(self, _cmd, camera);
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.camera = camera;

  appDelegate.panoramaView = self;
}

static void CustomSetPanorama(id, SEL, GMSPanorama *);

static void (*CustomSetPanoramaIMP)(id, SEL, GMSPanorama *);

static void CustomSetPanorama(id self, SEL _cmd, GMSPanorama *panorama) {
  CustomSetPanoramaIMP(self, _cmd, panorama);
  
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.panorama = panorama;
  
  appDelegate.panoramaView = self;
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSPanoramaView"]
             replaceMethod:@selector(setCamera:)
        withImplementation:(IMP)CustomSetCamera
                   storeIn:(IMP *)&CustomSetCameraIMP];

  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSPanoramaView"]
             replaceMethod:@selector(setPanorama:)
        withImplementation:(IMP)CustomSetPanorama
                   storeIn:(IMP *)&CustomSetPanoramaIMP];
}

@end
