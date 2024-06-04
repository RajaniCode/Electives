//
//  StreetViewVC+Swizzles.h
//  Level6-2-StreetViewSetup
//
//  Created by Jon Friskics on 3/5/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "StreetViewVC.h"

@interface StreetViewVC (Swizzles)

@property (strong, nonatomic) NSNumber *latitude;
@property (strong, nonatomic) NSNumber *longitude;

@end
