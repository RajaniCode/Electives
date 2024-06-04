//
//  TruckMapVC+Swizzles.h
//  Level6-2-StreetViewSetup
//
//  Created by Eric Allam on 18/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMapVC.h"
#import <GoogleMaps/GoogleMaps.h>

@class TruckMarker;

@interface TruckMapVC (Swizzles)
@property (strong, nonatomic) NSArray *downloadedMarkers;
@property (strong, nonatomic) NSOperationQueue *calledQueue;
@property (strong, nonatomic) NSNumber *calledUpdateMarkers;
@property (strong, nonatomic) TruckMarker *markerToUpdate;
@property (strong, nonatomic) NSArray *steps;
@property (strong, nonatomic) GMSPolyline *directionsLine;
@property (strong, nonatomic) NSNumber *latitude;
@property (strong, nonatomic) NSNumber *longitude;

@end
