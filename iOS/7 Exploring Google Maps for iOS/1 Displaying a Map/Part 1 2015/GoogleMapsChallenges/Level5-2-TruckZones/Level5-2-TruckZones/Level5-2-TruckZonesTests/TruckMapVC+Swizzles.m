//
//  TruckMapVC+Swizzles.m
//  Level5-2-TruckZones
//
//  Created by Eric Allam on 18/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMapVC+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "TruckMarker.h"

@implementation TruckMapVC (Swizzles)

+ (void)load
{
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(createMarkerObjectsWithJson:)
                withMethod:@selector(cs_createMarkerObjectsWithJson:)];
  
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(updateMarkerData:)
                withMethod:@selector(cs_updateMarkerData:)];
  
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


- (void)cs_createMarkerObjectsWithJson:(NSArray *)markers
{
  
  self.downloadedMarkers = markers;
  self.calledQueue = [NSOperationQueue currentQueue];
  
  [self cs_createMarkerObjectsWithJson:markers];
}



- (void)cs_updateMarkerData:(TruckMarker *)marker
{
  self.calledUpdateMarkers = @YES;
  self.markerToUpdate = marker;
  [self cs_updateMarkerData:marker];
}

@end
