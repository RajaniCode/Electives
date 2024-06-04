//
//  NSObject+StringClassComparison.h
//  Level1-MapsExample
//
//  Created by Eric Allam on 24/01/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NSObject (StringClassComparison)
- (BOOL)cs_isSameClassAs:(Class)cls;
@end
