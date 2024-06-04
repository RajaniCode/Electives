//
//  DirectionsVC+Swizzles.m
//  Level4-3-GettingDirections
//
//  Created by Jon Friskics on 2/27/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "DirectionsVC+Swizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation DirectionsVC (Swizzles)

+ (void)load
{
  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(viewWillAppear:)
                withMethod:@selector(cs_viewWillAppear:)];

  [CSSwizzler swizzleClass:self
             replaceMethod:@selector(setSteps:)
                withMethod:@selector(cs_setSteps:)];
}

- (void)cs_setSteps:(NSArray *)steps
{
  [self cs_setSteps:steps];
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.stepsInDirectionsVC = self.steps;
}

- (void)cs_viewWillAppear:(BOOL)animated
{
  [self cs_viewWillAppear:animated];
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.directionsViewAppeared = @YES;
}

@end
