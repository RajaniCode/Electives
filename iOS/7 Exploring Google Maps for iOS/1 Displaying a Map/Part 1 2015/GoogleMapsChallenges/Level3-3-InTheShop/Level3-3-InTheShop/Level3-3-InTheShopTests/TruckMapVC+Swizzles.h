//
//  TruckMapVC+Swizzles.h
//  Level3-3-InTheShop
//
//  Created by Eric Allam on 18/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMapVC.h"

@interface TruckMapVC (Swizzles)
@property (strong, nonatomic) NSArray *downloadedMarkers;
@property (strong, nonatomic) NSOperationQueue *calledQueue;
@end
