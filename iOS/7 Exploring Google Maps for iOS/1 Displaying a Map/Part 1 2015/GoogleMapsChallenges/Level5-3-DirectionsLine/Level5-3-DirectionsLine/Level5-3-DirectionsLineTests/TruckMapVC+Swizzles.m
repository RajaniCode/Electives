//
//  TruckMapVC+Swizzles.m
//  Level5-3-DirectionsLine
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

static void CustomMapTap(id, SEL, GMSMapView *, CLLocationCoordinate2D);

static void (*CustomMapTapIMP)(id, SEL, GMSMapView *, CLLocationCoordinate2D);

static void CustomMapTap(id self, SEL _cmd, GMSMapView *mapView, CLLocationCoordinate2D coordinate) {
  CustomMapTapIMP(self, _cmd, mapView, coordinate);
}

+ (void)load
{
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wundeclared-selector"
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(createMarkerObjectsWithJson:)
                withMethod:@selector(cs_createMarkerObjectsWithJson:)];
#pragma clang diagnostic pop
  
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wundeclared-selector"
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(updateMarkerData:)
                withMethod:@selector(cs_updateMarkerData:)];
#pragma clang diagnostic pop
 
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(setDirectionsLine:)
                withMethod:@selector(cs_setDirectionsLine:)];
  
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(mapView:didTapMarker:)
                withMethod:@selector(cs_mapView:didTapMarker:)];

  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(mapView:didTapAtCoordinate:)
                withMethod:@selector(cs_mapView:didTapAtCoordinate:)];
  
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]
             replaceMethod:@selector(mapView:didTapAtCoordinate:)
        withImplementation:(IMP)CustomMapTap
                   storeIn:(IMP *)&CustomMapTapIMP];
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

- (void)cs_mapView:(GMSMapView *)mapView didTapAtCoordinate:(CLLocationCoordinate2D)coordinate
{
  [self cs_mapView:mapView didTapAtCoordinate:coordinate];
}

@end
