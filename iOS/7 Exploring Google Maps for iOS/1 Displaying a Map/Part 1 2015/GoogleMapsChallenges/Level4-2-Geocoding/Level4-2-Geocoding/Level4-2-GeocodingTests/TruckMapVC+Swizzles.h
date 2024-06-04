//
//  TruckMapVC+Swizzles.h
//  Level4-2-Geocoding
//
//  Created by Eric Allam on 18/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMapVC.h"

@class TruckMarker;

@interface TruckMapVC (Swizzles)
@property (strong, nonatomic) NSArray *downloadedMarkers;
@property (strong, nonatomic) NSOperationQueue *calledQueue;
@property (strong, nonatomic) NSNumber *calledUpdateMarkers;
@property (strong, nonatomic) TruckMarker *markerToUpdate;
@end
