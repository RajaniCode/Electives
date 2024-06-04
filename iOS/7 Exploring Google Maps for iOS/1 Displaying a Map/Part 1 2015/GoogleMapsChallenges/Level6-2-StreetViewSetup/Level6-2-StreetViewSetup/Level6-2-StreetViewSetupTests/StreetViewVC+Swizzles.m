//
//  StreetViewVC+Swizzles.m
//  Level6-2-StreetViewSetup
//
//  Created by Jon Friskics on 3/5/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "StreetViewVC+Swizzles.h"
#import "CSSwizzler.h"

#import <GoogleMaps/GoogleMaps.h>
#import <objc/runtime.h>

@implementation StreetViewVC (Swizzles)

+ (void)load
{
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(setCoordinate:)
                withMethod:@selector(cs_setCoordinate:)];
}

- (void)setLatitude:(NSNumber *)latitude
{
  objc_setAssociatedObject(self, @selector(latitude), latitude, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)latitude
{
  return objc_getAssociatedObject(self, @selector(latitude));
}

- (void)setLongitude:(NSNumber *)longitude
{
  objc_setAssociatedObject(self, @selector(longitude), longitude, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)longitude
{
  return objc_getAssociatedObject(self, @selector(longitude));
}

- (void)cs_setCoordinate:(CLLocationCoordinate2D)coordinate
{
  self.latitude = @(coordinate.latitude);
  self.longitude = @(coordinate.longitude);
  
  [self cs_setCoordinate:coordinate];
}

@end
