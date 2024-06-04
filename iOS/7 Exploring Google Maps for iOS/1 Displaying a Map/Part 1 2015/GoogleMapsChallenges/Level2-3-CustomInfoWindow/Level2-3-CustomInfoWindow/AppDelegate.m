#import "AppDelegate.h"
#import "TruckMapVC.h"
#import <GoogleMaps/GoogleMaps.h>

#define GOOGLE_MAPS_API_KEY @"AIzaSyCasUya06b2sRXFl0o0yUKXn5P04oRcZTU"

@implementation AppDelegate

- (BOOL)application:(UIApplication *)application
    didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
  [GMSServices provideAPIKey:GOOGLE_MAPS_API_KEY];

  self.window = [[UIWindow alloc] initWithFrame:[[UIScreen mainScreen] bounds]];
  self.window.backgroundColor = [UIColor whiteColor];

  TruckMapVC *truckMapVC = [[TruckMapVC alloc] init];

  UINavigationController *navController =
      [[UINavigationController alloc] initWithRootViewController:truckMapVC];
  
  navController.navigationBar.barStyle = UIBarStyleBlack;

  self.window.rootViewController = navController;

  [self.window makeKeyAndVisible];
  return YES;
}

@end
