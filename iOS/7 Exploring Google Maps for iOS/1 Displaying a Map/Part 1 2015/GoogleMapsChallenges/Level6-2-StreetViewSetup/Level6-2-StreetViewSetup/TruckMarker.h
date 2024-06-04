//
//  TruckMarker.h
//  Level6-2-StreetViewSetup
//
//  Created by Eric Allam on 18/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import <GoogleMaps/GoogleMaps.h>

@interface TruckMarker : GMSMarker

@property (nonatomic, copy) NSString *objectID;
@property (nonatomic, assign) BOOL inTheShop;

@end
