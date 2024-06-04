#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>

#import "CSRecordingTestCase.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"
#import "TruckMapVC.h"

#import "UIImage+ZSwizzles.h"

#define kDoubleEpsilon (0.01)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}

@interface Level2_3_CustomInfoWindowTests : CSRecordingTestCase {
  AppDelegate *_appDel;
}

@end

@implementation Level2_3_CustomInfoWindowTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  [super tearDown];
}

- (void)testInfoWindowBackgroundImage
{
  _appDel = [[UIApplication sharedApplication] delegate];
  UINavigationController *navVC = (UINavigationController *)_appDel.window.rootViewController;
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
  
  if(_appDel.markers.count == 2) {
    GMSMarker *meltHouseMarker = _appDel.markers[0];
    UIView *infoWindow1 = [mapView.delegate mapView:mapView markerInfoWindow:meltHouseMarker];
    
    __block UIImageView *backgroundImageView;
    __block NSUInteger *backgroundImageViewIdx;
    __block UIImageView *logoImageView;
    __block NSUInteger *logoImageViewIdx;
    __block UILabel *nameLabel;
    
    [infoWindow1.subviews enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
      if([obj isKindOfClass:[UIImageView class]]) {
        if([obj frame].size.width > 100) {
          backgroundImageView = obj;
          backgroundImageViewIdx = &idx;
        } else {
          logoImageView = obj;
          logoImageViewIdx = &idx;
        }
      } else if([obj isKindOfClass:[UILabel class]]) {
        nameLabel = obj;
      }
    }];
    
    XCTAssert(infoWindow1.subviews[0] == backgroundImageView, @"Did not set a UIImageView for the background image as the first subview of infoWindow");
    if(backgroundImageView) {
      XCTAssert(doubleCloseTo(backgroundImageView.alpha, 0.85), @"Did not set the correct alpha for the UIImageView that holds the background image");
      __block NSInteger infoWindowIndex = 50;
      
      [_appDel.imageNames enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
        if([obj isEqualToString:@"info-window"]) {
          infoWindowIndex = idx;
        }
      }];
      
      if(infoWindowIndex != 50) {
        XCTAssert([_appDel.imageNames[infoWindowIndex] isEqualToString:@"info-window"], @"Did not set a UIImageView with the correct image as the first subview of the infoWindow");
      } else {
        XCTFail(@"Did not set the info window background image to the correct image name");
      }
    }

  } else {
    XCTFail(@"Did not create markers for Melt House and Taco Gogo.  When you opened this project, the code to create these markers was there, so did you accidentally delete them?");
  }
}

- (void)testInfoWindowLogo
{
  _appDel = [[UIApplication sharedApplication] delegate];
  UINavigationController *navVC = (UINavigationController *)_appDel.window.rootViewController;
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
  
  if(_appDel.markers.count == 2) {
    GMSMarker *meltHouseMarker = _appDel.markers[0];
    
    UIView *infoWindow1 = [mapView.delegate mapView:mapView markerInfoWindow:meltHouseMarker];
    
    __block UIImageView *backgroundImageView;
    __block NSUInteger *backgroundImageViewIdx;
    __block UIImageView *logoImageView;
    __block NSUInteger *logoImageViewIdx;
    __block UILabel *nameLabel;
    
    [infoWindow1.subviews enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
      if([obj isKindOfClass:[UIImageView class]]) {
        if([obj frame].size.width > 100) {
          backgroundImageView = obj;
          backgroundImageViewIdx = &idx;
        } else {
          logoImageView = obj;
          logoImageViewIdx = &idx;
        }
      } else if([obj isKindOfClass:[UILabel class]]) {
        nameLabel = obj;
      }
    }];
    
    XCTAssert(infoWindow1.subviews[1] == logoImageView, @"Did not set a UIImageView for the Melt House logo as the second subview of infoWindow");
    if(logoImageView) {
      __block NSInteger logoImageIndex = 50;
      
      [_appDel.imageNames enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
        if([obj isEqualToString:@"melt-house"]) {
          logoImageIndex = idx;
        }
      }];
      
      XCTAssert(logoImageIndex != 50, @"You didn't use the melt-house image in the logoImageView");
      
      XCTAssert(meltHouseMarker.userData != nil, @"Did not set the Melt House marker's userData property to a UIImage");
      if(meltHouseMarker.userData != nil) {
        XCTAssert(logoImageView.image != nil, @"Did not set the logoImageView's image equal to the Melt House marker's userData property");
        if(logoImageView.image != nil) {
          XCTAssert(logoImageView.image == meltHouseMarker.userData && logoImageView.image != nil && meltHouseMarker.userData != nil, @"You set the Melt House marker's userData property, but you're not using it to set the logoImageView's image property!");
        }
      }
    }
    
    GMSMarker *tacoGogoMarker = _appDel.markers[1];
    
    UIView *infoWindow2 = [mapView.delegate mapView:mapView markerInfoWindow:tacoGogoMarker];
    
    backgroundImageView = nil;
    backgroundImageViewIdx = nil;
    logoImageView = nil;
    logoImageViewIdx = nil;
    nameLabel = nil;
    
    [infoWindow2.subviews enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
      if([obj isKindOfClass:[UIImageView class]]) {
        if([obj frame].size.width > 100) {
          backgroundImageView = obj;
          backgroundImageViewIdx = &idx;
        } else {
          logoImageView = obj;
          logoImageViewIdx = &idx;
        }
      } else if([obj isKindOfClass:[UILabel class]]) {
        nameLabel = obj;
      }
    }];
    
    XCTAssert(infoWindow2.subviews[1] == logoImageView, @"Did not set a UIImageView for the Taco Gogo truck logo as the second subview of infoWindow");
    if(logoImageView) {
      __block NSInteger logoImageIndex = 50;
      
      [_appDel.imageNames enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
        if([obj isEqualToString:@"taco-gogo"]) {
          logoImageIndex = idx;
        }
      }];
      
      XCTAssert(logoImageIndex != 50, @"You didn't use the taco-gogo image in the logoImageView");
      
      XCTAssert(tacoGogoMarker.userData != nil, @"Did not set the Taco Gogo marker's userData property to a UIImage");
      if(tacoGogoMarker.userData != nil) {
        XCTAssert(logoImageView.image != nil, @"Did not set the logoImageView's image equal to the Taco Gogo marker's userData property");
        if(logoImageView.image != nil) {
          XCTAssert(logoImageView.image == tacoGogoMarker.userData && logoImageView.image != nil && tacoGogoMarker.userData != nil, @"You set the Taco Gogo marker's userData property, but you're not using it to set the logoImageView's image property!");
        }
      }
    }

  } else {
    XCTFail(@"Did not create markers for Melt House and Taco Gogo.  When you opened this project, the code to create these markers was there, so did you accidentally delete them?");
  }
}

- (void)testInfoWindowLabel
{
  _appDel = [[UIApplication sharedApplication] delegate];
  UINavigationController *navVC = (UINavigationController *)_appDel.window.rootViewController;
  TruckMapVC *mapVC = (TruckMapVC *)[navVC topViewController];
  GMSMapView *mapView = (GMSMapView *)[mapVC.view subviews][0];
  
  if(_appDel.markers.count == 2) {
    GMSMarker *meltHouseMarker = _appDel.markers[0];
    
    UIView *infoWindow1 = [mapView.delegate mapView:mapView markerInfoWindow:meltHouseMarker];
    
    __block UIImageView *backgroundImageView;
    __block NSUInteger *backgroundImageViewIdx;
    __block UIImageView *logoImageView;
    __block NSUInteger *logoImageViewIdx;
    __block UILabel *nameLabel;
    
    [infoWindow1.subviews enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
      if([obj isKindOfClass:[UIImageView class]]) {
        if([obj frame].size.width > 100) {
          backgroundImageView = obj;
          backgroundImageViewIdx = &idx;
        } else {
          logoImageView = obj;
          logoImageViewIdx = &idx;
        }
      } else if([obj isKindOfClass:[UILabel class]]) {
        nameLabel = obj;
      }
    }];
    
    XCTAssert(infoWindow1.subviews[2] == nameLabel, @"Did not set a UILabel for the Melt House truck as the third subview of infoWindow");
    if(nameLabel) {
      XCTAssert([nameLabel.text isEqualToString:meltHouseMarker.title], @"Did not set the nameLabel's text equal to the title of the Melt House marker object.");
    }
    
    GMSMarker *tacoGogoMarker = _appDel.markers[1];
    
    UIView *infoWindow2 = [mapView.delegate mapView:mapView markerInfoWindow:tacoGogoMarker];
    
    backgroundImageView = nil;
    backgroundImageViewIdx = nil;
    logoImageView = nil;
    logoImageViewIdx = nil;
    nameLabel = nil;
    
    [infoWindow2.subviews enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
      if([obj isKindOfClass:[UIImageView class]]) {
        if([obj frame].size.width > 100) {
          backgroundImageView = obj;
          backgroundImageViewIdx = &idx;
        } else {
          logoImageView = obj;
          logoImageViewIdx = &idx;
        }
      } else if([obj isKindOfClass:[UILabel class]]) {
        nameLabel = obj;
      }
    }];
    
    XCTAssert(infoWindow2.subviews[2] == nameLabel, @"Did not set a UILabel for the Taco Gogo truck as the third subview of infoWindow");
    if(nameLabel) {
      XCTAssert([nameLabel.text isEqualToString:tacoGogoMarker.title], @"Did not set the nameLabel's text equal to the title of the Taco Gogo marker object.");
    }
    
  } else {
    XCTFail(@"Did not create markers for Melt House and Taco Gogo.  When you opened this project, the code to create these markers was there, so did you accidentally delete them?");
  }
}

@end
