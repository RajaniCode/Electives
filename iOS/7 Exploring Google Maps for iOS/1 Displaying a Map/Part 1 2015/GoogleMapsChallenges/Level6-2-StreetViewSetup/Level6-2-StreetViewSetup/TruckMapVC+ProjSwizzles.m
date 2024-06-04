//
//  TruckMapVC+ProjSwizzles.m
//  Level6-2-StreetViewSetup
//
//  Created by Jon Friskics on 2/27/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "TruckMapVC+ProjSwizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import <GoogleMaps/GoogleMaps.h>

@interface TruckMapVC ()
@property (strong, nonatomic) GMSMapView *mapView;
@end

@implementation TruckMapVC (ProjSwizzles)

+ (void) load
{
  [CSSwizzler swizzleClass:[TruckMapVC class]
             replaceMethod:@selector(viewDidLoad)
                withMethod:@selector(cs_viewDidLoad)];
}

- (void)cs_viewDidLoad
{
  [self cs_viewDidLoad];
  
  UIColor *brooklynBowlBuggyStrokeColor = [UIColor colorWithRed:216.0/255.0 green:49.0/255.0 blue:43.0/255.0 alpha:1.0];
  UIColor *brooklynBowlBuggyFillColor = [UIColor colorWithRed:216.0/255.0 green:49.0/255.0 blue:43.0/255.0 alpha:0.5];
  
  UIColor *letsRollStrokeColor = [UIColor colorWithRed:159.0/255.0 green:209.0/255.0 blue:137.0/255.0 alpha:1.0];
  UIColor *letsRollFillColor = [UIColor colorWithRed:159.0/255.0 green:209.0/255.0 blue:137.0/255.0 alpha:0.5];
  
  UIColor *burgerBrosStrokeColor = [UIColor colorWithRed:244.0/255.0 green:128.0/255.0 blue:39.0/255.0 alpha:1.0];
  UIColor *burgerBrosFillColor = [UIColor colorWithRed:244.0/255.0 green:128.0/255.0 blue:39.0/255.0 alpha:0.5];
  
  UIColor *kingCupcakeStrokeColor = [UIColor colorWithRed:228.0/255.0 green:72/255.0 blue:109.0/255.0 alpha:1.0];
  UIColor *kingCupcakeFillColor = [UIColor colorWithRed:228.0/255.0 green:72/255.0 blue:109.0/255.0 alpha:0.5];

  GMSPolygon *truck3 = [GMSPolygon polygonWithPath:[self getPathForTruck:@"Presidio Heights"]];
  truck3.strokeColor = brooklynBowlBuggyStrokeColor;
  truck3.strokeWidth = 2;
  truck3.fillColor = brooklynBowlBuggyFillColor;
  truck3.title = @"Brooklyn Bowl Buggy";
  truck3.map = self.mapView;
  
  GMSPolygon *truck4 = [GMSPolygon polygonWithPath:[self getPathForTruck:@"Western Addition"]];
  truck4.strokeColor = letsRollStrokeColor;
  truck4.strokeWidth = 2;
  truck4.fillColor = letsRollFillColor;
  truck4.title = @"Let's Roll";
  truck4.map = self.mapView;
  
  GMSPolygon *truck5 = [GMSPolygon polygonWithPath:[self getPathForTruck:@"Nob Hill"]];
  truck5.strokeColor = burgerBrosStrokeColor;
  truck5.strokeWidth = 2;
  truck5.fillColor = burgerBrosFillColor;
  truck5.title = @"Burger Bros";
  truck5.map = self.mapView;
  
  GMSPolygon *truck6 = [GMSPolygon polygonWithPath:[self getPathForTruck:@"Russian Hill"]];
  truck6.strokeColor = kingCupcakeStrokeColor;
  truck6.strokeWidth = 2;
  truck6.fillColor = kingCupcakeFillColor;
  truck6.title = @"King Cupcake";
  truck6.map = self.mapView;
}

/**
 * This method generates a GMSPath for the specified food truck.
 *
 * @param truckName \@"Marina", \@"Pacific Heights", \@"Presidio Heights", \@"Western Addition", \@"Nob Hill", or \@"Russian Hill"
 *
 * @return a GMSPath object that can be used to draw a GMSPolygon
 */
- (GMSPath *)getPathForTruck:(NSString *)truckName {
  
  NSData *jsonData = [NSData dataWithContentsOfFile:[[NSBundle mainBundle] pathForResource:@"zones" ofType:@"json"]];
  NSArray *json = [NSJSONSerialization JSONObjectWithData:jsonData options:0 error:nil];
  NSArray *filteredJson = [json filteredArrayUsingPredicate:[NSPredicate predicateWithFormat:@"(zone == %@)", truckName]];
  
  NSArray *coordinates = [filteredJson[0][@"coordinates"] componentsSeparatedByString:@" "];
  
  GMSMutablePath *mutablePath = [[GMSMutablePath alloc] init];
  for(NSString *latLngString in coordinates) {
    NSArray *singleCoordinate = [latLngString componentsSeparatedByString:@","];
    [mutablePath addLatitude:[singleCoordinate[1] doubleValue] longitude:[singleCoordinate[0] doubleValue]];
  }
  return [mutablePath copy];
}


@end
