//
//  GMSMapView+ZSwizzles.m
//  Level1-3-DisplayingAMap
//
//  Created by Eric Allam on 29/01/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSMapView+ZSwizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSMapView (ZSwizzles)

// Define the interface for our custom implementation of mapWithFrame:camera:
static GMSMapView * CustomMapWithFrameCamera(id, SEL, CGRect, GMSCameraPosition *);

// Create a function pointer for the original mapWithFrame:camera: to be stored in
static GMSMapView * (*CustomMapWithFrameCameraIMP)(id, SEL, CGRect, GMSCameraPosition *);

// Define our custom implementation of mapWithFrame:camera:, calling CustomMapWithFrameCameraIMP
// to call the original method
static GMSMapView * CustomMapWithFrameCamera(id self, SEL _cmd, CGRect frame, GMSCameraPosition *camera){
    
    GMSMapView *mapView = CustomMapWithFrameCameraIMP(self, _cmd, frame, camera);
  
    AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
    appDelegate.mapView = mapView;
  
    return mapView;
}

+ (void)load
{
    [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]
          replaceClassMethod:@selector(mapWithFrame:camera:)
          withImplementation:(IMP)CustomMapWithFrameCamera
                     storeIn:(IMP *)&CustomMapWithFrameCameraIMP];
}

@end
