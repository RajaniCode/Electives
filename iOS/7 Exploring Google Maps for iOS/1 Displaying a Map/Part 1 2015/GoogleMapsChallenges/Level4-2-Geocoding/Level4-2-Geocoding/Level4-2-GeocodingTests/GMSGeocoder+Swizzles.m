//
//  GMSGeocoder+Swizzles.m
//  Level3-NetworkMarkers
//
//  Created by Jon Friskics on 2/24/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSGeocoder+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSGeocoder (Swizzles)


// Define the interface for our custom implementation of mapWithFrame:camera:
static GMSGeocoder * Geocoder(id, SEL);

// Create a function pointer for the original mapWithFrame:camera: to be stored in
static GMSGeocoder * (*GeocoderIMP)(id, SEL);

// Define our custom implementation of mapWithFrame:camera:, calling CustomMapWithFrameCameraIMP
// to call the original method
static GMSGeocoder * Geocoder(id self, SEL _cmd){
  GMSGeocoder *geocoder = GeocoderIMP(self, _cmd);
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.geocoderCalled = @YES;
  appDelegate.theGeocoder = geocoder;
    
  return geocoder;
}

static void ReverseGeocodeLocation(id, SEL, CLLocationCoordinate2D, GMSReverseGeocodeCallback);

static void (*ReverseGeocodeLocationIMP)(id, SEL, CLLocationCoordinate2D, GMSReverseGeocodeCallback);
               
static void ReverseGeocodeLocation(id self, SEL _cmd, CLLocationCoordinate2D coordinate, GMSReverseGeocodeCallback handler) {
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.reverseGeocodeCalled = @YES;
  appDelegate.latCoordinate = @(coordinate.latitude);
  appDelegate.lngCoordinate = @(coordinate.longitude);
  ReverseGeocodeLocationIMP(self, _cmd, coordinate, handler);
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSGeocoder"]
        replaceClassMethod:@selector(geocoder)
        withImplementation:(IMP)Geocoder
                   storeIn:(IMP *)&GeocoderIMP];

  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSGeocoder"]
             replaceMethod:@selector(reverseGeocodeCoordinate:completionHandler:)
        withImplementation:(IMP)ReverseGeocodeLocation
                   storeIn:(IMP *)&ReverseGeocodeLocationIMP];
}

@end
