//
//  NSOperation+Swizzles.m
//  Level5-3-DirectionsLine
//
//  Created by Jon Friskics on 2/28/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "NSOperationQueue+Swizzles.h"
#import "CSSwizzler.h"
#import "AppDelegate+TestAdditions.h"

@implementation NSOperationQueue (Swizzles)

+ (void)load
{
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(addOperationWithBlock:)
                withMethod:@selector(cs_addOperationWithBlock:)];
}

- (void)cs_addOperationWithBlock:(void (^)(void))blockName
{
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.blockName = blockName;
  [self cs_addOperationWithBlock:blockName];
}

@end
