//
//  TruckMapVC+Swizzles.m
//  Level6-2-StreetViewSetup
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
             replaceMethod:@selector(setDirectionsLine:)
                withMethod:@selector(cs_setDirectionsLine:)];
  
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(mapView:didTapMarker:)
                withMethod:@selector(cs_mapView:didTapMarker:)];

  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(showStreetView:)
                withMethod:@selector(cs_showStreetView:)];

  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(setActiveMarkerCoordinate:)
                withMethod:@selector(cs_setActiveMarkerCoordinate:)];
#pragma clang diagnostic pop
}

- (NSOperationQueue *)calledQueue
{
  return objc_getAssociatedObject(self, @selector(calledQueue));
}

- (void)setCalledQueue:(NSOperationQueue *)calledQueue
{
  objc_setAssociatedObject(self, @selector(calledQueue), calledQueue, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)downloadedMarkers
{
  return objc_getAssociatedObject(self, @selector(downloadedMarkers));
}

- (void)setDownloadedMarkers:(NSArray *)downloadedMarkers
{
  objc_setAssociatedObject(self, @selector(downloadedMarkers), downloadedMarkers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}



- (void)setCalledUpdateMarkers:(NSNumber *)calledUpdateMarkers
{
  objc_setAssociatedObject(self, @selector(calledUpdateMarkers), calledUpdateMarkers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)calledUpdateMarkers
{
  return objc_getAssociatedObject(self, @selector(calledUpdateMarkers));
}

- (void)setMarkerToUpdate:(TruckMarker *)markerToUpdate
{
  objc_setAssociatedObject(self, @selector(markerToUpdate), markerToUpdate, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (TruckMarker *)markerToUpdate
{
  return objc_getAssociatedObject(self, @selector(markerToUpdate));
}

- (void)setSteps:(NSArray *)steps
{
  objc_setAssociatedObject(self, @selector(steps), steps, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSArray *)steps
{
  return objc_getAssociatedObject(self, @selector(steps));
}

- (void)setDirectionsLine:(GMSPolyline *)directionsLine
{
  objc_setAssociatedObject(self, @selector(directionsLine), directionsLine, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (GMSPolyline *)directionsLine
{
  return objc_getAssociatedObject(self, @selector(directionsLine));
}

- (void)cs_createMarkerObjectsWithJson:(NSArray *)markers
{
  
  self.downloadedMarkers = markers;
  
  [self cs_createMarkerObjectsWithJson:markers];
}

- (void)setStreetViewSender:(id)streetViewSender
{
  objc_setAssociatedObject(self, @selector(streetViewSender), streetViewSender, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (id)streetViewSender
{
  return objc_getAssociatedObject(self, @selector(streetViewSender));
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


- (void)cs_updateMarkerData:(TruckMarker *)marker
{
  self.calledUpdateMarkers = @YES;
  self.markerToUpdate = marker;
  [self cs_updateMarkerData:marker];
}


- (void)cs_setDirectionsLine:(GMSPolyline *)directionsLine
{
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.polyline = directionsLine;
  [self cs_setDirectionsLine:directionsLine];
}

- (void)cs_mapView:(GMSMapView *)mapView didTapMarker:(GMSMarker *)marker
{
  self.calledQueue = [NSOperationQueue currentQueue];

  [self cs_mapView:mapView didTapMarker:marker];
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
