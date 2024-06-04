//
//  UIImage+Swizzles.m
//  Level2-2-CustomInfoWindow
//
//  Created by Jon Friskics on 2/28/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "UIImage+ZSwizzles.h"

#import <objc/runtime.h>

#import "CSSwizzler.h"

#import "AppDelegate+TestAdditions.h"

@implementation UIImage (ZSwizzles)

+ (void)load
{
  [CSSwizzler swizzleClass:[UIImage class] replaceClassMethod:@selector(imageNamed:) withMethod:@selector(cs_imageNamed:)];
}

+ (UIImage *)cs_imageNamed:(NSString *)imageName
{
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  
  if([imageName compare:@"marker" options:NSCaseInsensitiveSearch range:NSMakeRange(0, 6)] == 0) {
    if([imageName compare:@"melt" options:NSCaseInsensitiveSearch range:NSMakeRange(7, 4)] == 0 || [imageName compare:@"taco" options:NSCaseInsensitiveSearch range:NSMakeRange(7, 4)] == 0) {
      NSMutableArray *mutableArray = [[NSMutableArray alloc] initWithArray:appDelegate.imageNames];
      [mutableArray addObject:imageName];
      appDelegate.imageNames = [mutableArray copy];
    }
  }
    
  return [self cs_imageNamed:imageName];
}

@end
