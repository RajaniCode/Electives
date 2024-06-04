//
//  GMSMapView+Swizzles.m
//  Level5-3-DirectionsLine
//
//  Created by Jon Friskics on 2/27/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSMapView+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>

@implementation GMSMapView (Swizzles)

static CLLocation * MyLocation(id, SEL);

static CLLocation * (*MyLocationIMP)(id, SEL);

static CLLocation * MyLocation(id self, SEL _cmd){
  CLLocation *loc = [[CLLocation alloc] initWithLatitude:37.790706 longitude:-122.434167];
  return loc;
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSMapView"]
             replaceMethod:@selector(myLocation)
        withImplementation:(IMP)MyLocation
                   storeIn:(IMP *)&MyLocationIMP];
}

+(void)swizzleClass:(id)cls
      replaceMethod:(SEL)origMethodSelector
         withMethod:(SEL)replacementMethodSelector;
{
  Method origMethod = nil, altMethod = nil;
  origMethod = class_getInstanceMethod(cls, origMethodSelector);
  altMethod = class_getInstanceMethod(cls, replacementMethodSelector);
  method_exchangeImplementations(origMethod, altMethod);
}


@end
