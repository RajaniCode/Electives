//
//  TruckMarker.m
//  Level6-3-DisplayingAStreetView
//
//  Created by Eric Allam on 18/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMarker.h"

@implementation TruckMarker

- (BOOL)isEqual:(id)object {
  TruckMarker *otherMarker = (TruckMarker *)object;
  
  if ([otherMarker isKindOfClass:[TruckMarker class]]) {
    
    if(self.objectID == otherMarker.objectID) {
      return YES;
    }
    
  }
  
  return NO;
}

- (NSUInteger)hash {
  return [self.objectID hash];
}

@end
