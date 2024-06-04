#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>

#import "CSRecordingTestCase.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"

#import "XCTestCase+AsyncTesting.h"

@interface Level1_2_SettingUpAnApiKeyTests : CSRecordingTestCase {
    AppDelegate *_appDel;
}

@end

@implementation Level1_2_SettingUpAnApiKeyTests

- (void)setUp
{
    [super setUp];
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  appDelegate.apiKeySuccess = @(0);
}

- (void)tearDown
{
    [super tearDown];
}

- (void)testConfig
{
  _appDel = (AppDelegate *)[UIApplication sharedApplication].delegate;
  [GMSServices provideAPIKey:_appDel.apiKey];
  
  __block NSError *anError;
  
  GMSGeocoder *geocoder = [GMSGeocoder geocoder];
  [geocoder reverseGeocodeCoordinate:CLLocationCoordinate2DMake(28.3526, -81.3456) completionHandler:^(GMSReverseGeocodeResponse *response, NSError *error) {
    anError = error;
    [self notify:XCTAsyncTestCaseStatusSucceeded];
  }];
  
  [self waitForStatus:XCTAsyncTestCaseStatusSucceeded timeout:5.0];
  
  XCTAssertNil(anError, @"Something went wrong and your API Key didn't enable access to the Google Maps SDK.  Are you sure you entered your API Key and Bundle ID in the Exploring Google Maps for iOS Course web interface?  Or, is it possible you accidentally deleted your API Key from the Google Developer Console?");
}

@end
