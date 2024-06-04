//
//  NSObject+StringClassComparison.h
//  Level3-2-NetworkMarkers
//
//  Created by Eric Allam on 24/01/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NSObject (StringClassComparison)
- (BOOL)cs_isSameClassAs:(Class)cls;
@end
