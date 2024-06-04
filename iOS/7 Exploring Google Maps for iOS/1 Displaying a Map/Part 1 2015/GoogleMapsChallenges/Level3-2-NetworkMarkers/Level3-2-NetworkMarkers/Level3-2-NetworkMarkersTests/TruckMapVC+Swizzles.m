//
//  TruckMapVC+Swizzles.m
//  Level3-2-NetworkMarkers
//
//  Created by Eric Allam on 18/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMapVC+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>

@implementation TruckMapVC (Swizzles)

+ (void)load
{
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wundeclared-selector"
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(createMarkerObjectsWithJson:)
                withMethod:@selector(cs_createMarkerObjectsWithJson:)];
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

- (void)cs_createMarkerObjectsWithJson:(NSArray *)markers
{
  self.downloadedMarkers = markers;
  self.calledQueue = [NSOperationQueue currentQueue];
  
  [self cs_createMarkerObjectsWithJson:markers];
}

@end
