//
//  NSObject+StringClassComparison.m
//  Level1-MapsExample
//
//  Created by Eric Allam on 24/01/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "NSObject+StringClassComparison.h"

@implementation NSObject (StringClassComparison)

- (BOOL)cs_isSameClassAs:(Class)cls
{
    return [NSStringFromClass(self.class) isEqualToString:NSStringFromClass(cls)];
}

@end
