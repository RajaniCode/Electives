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
