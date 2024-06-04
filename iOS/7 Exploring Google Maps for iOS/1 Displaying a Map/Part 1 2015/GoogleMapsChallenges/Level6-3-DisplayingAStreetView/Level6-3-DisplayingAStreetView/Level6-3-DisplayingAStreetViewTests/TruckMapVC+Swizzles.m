//
//  TruckMapVC+Swizzles.m
//  Level6-3-DisplayingAStreetView
//
//  Created by Eric Allam on 18/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMapVC+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "TruckMarker.h"
#import "AppDelegate+TestAdditions.h"

@implementation TruckMapVC (Swizzles)

+ (void)load
{
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wundeclared-selector"

  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(createMarkerObjectsWithJson:)
                withMethod:@selector(cs_createMarkerObjectsWithJson:)];
  
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(updateMarkerData:)
                withMethod:@selector(cs_updateMarkerData:)];

  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(mapView:didTapMarker:)
                withMethod:@selector(cs_mapView:didTapMarker:)];

  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(setActiveMarkerCoordinate:)
                withMethod:@selector(cs_setActiveMarkerCoordinate:)];
#pragma clang diagnostic pop
}

- (NSArray *)downloadedMarkers
{
  return objc_getAssociatedObject(self, @selector(downloadedMarkers));
}

- (void)setDownloadedMarkers:(NSArray *)downloadedMarkers
{
  objc_setAssociatedObject(self, @selector(downloadedMarkers), downloadedMarkers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (void)cs_createMarkerObjectsWithJson:(NSArray *)markers
{
  
  self.downloadedMarkers = markers;
  
  [self cs_createMarkerObjectsWithJson:markers];
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

- (void)cs_showStreetView:(id)sender
{
  [self cs_showStreetView:sender];
}

- (void)cs_setActiveMarkerCoordinate:(CLLocationCoordinate2D)coordinate
{
  self.latitude = @(coordinate.latitude);
  self.longitude = @(coordinate.longitude);
  
  [self cs_setActiveMarkerCoordinate:coordinate];
}

@end
