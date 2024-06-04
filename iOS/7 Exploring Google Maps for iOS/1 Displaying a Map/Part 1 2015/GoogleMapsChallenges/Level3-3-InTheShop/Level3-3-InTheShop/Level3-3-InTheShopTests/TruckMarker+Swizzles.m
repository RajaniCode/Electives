//
//  TruckMarker+Swizzles.m
//  Level3-3-InTheShop
//
//  Created by Jon Friskics on 3/24/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMarker+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation TruckMarker (Swizzles)

+ (void)load
{
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wundeclared-selector"
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(setInTheShop:)
                withMethod:@selector(cs_setInTheShop:)];
#pragma clang diagnostic pop
}

- (void)cs_setInTheShop:(BOOL)isInTheShop
{
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.inTheShopCount = @([appDelegate.inTheShopCount intValue] + 1);
    
  [self cs_setInTheShop:isInTheShop];
}

@end
