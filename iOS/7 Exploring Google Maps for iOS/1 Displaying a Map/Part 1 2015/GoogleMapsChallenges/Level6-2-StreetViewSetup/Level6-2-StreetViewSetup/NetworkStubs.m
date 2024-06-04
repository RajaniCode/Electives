//
//  NetworkStubs.m
//  Level3-MapsExample
//
//  Created by Eric Allam on 06/02/2014.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "NetworkStubs.h"
#import "OHHTTPStubs/OHHTTPStubs.h"

@implementation NetworkStubs

+ (void)load
{
    [OHHTTPStubs stubRequestsPassingTest:^BOOL(NSURLRequest *request) {
        return [request.URL.host isEqualToString:@"googlemaps.codeschool.com"];
    } withStubResponse:^OHHTTPStubsResponse*(NSURLRequest *request) {
        return [OHHTTPStubsResponse responseWithFileAtPath:OHPathForFileInBundle(@"trucks.json",nil)
                                                statusCode:200 headers:@{@"Content-Type":@"text/json"}];
    }];
}

@end
