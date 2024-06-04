#import "AppDelegate.h"
#import <GoogleMaps/GoogleMaps.h>

#define GOOGLE_MAPS_API_KEY @"AIzaSyCasUya06b2sRXFl0o0yUKXn5P04oRcZTU"

@implementation AppDelegate

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
  [GMSServices provideAPIKey:GOOGLE_MAPS_API_KEY];
  
  self.window = [[UIWindow alloc] initWithFrame:[[UIScreen mainScreen] bounds]];
  self.window.backgroundColor = [UIColor whiteColor];
  
  UIViewController *vc = [[UIViewController alloc] init];
  
  UILabel *versionLabel = [[UILabel alloc] init];
  versionLabel.font = [UIFont fontWithDescriptor:[UIFontDescriptor preferredFontDescriptorWithTextStyle:UIFontTextStyleBody] size:16];
  versionLabel.numberOfLines = 0;
  versionLabel.lineBreakMode = NSLineBreakByWordWrapping;
  versionLabel.text = [NSString stringWithFormat:@"The version of the Google Maps SDK for iOS that's been added to this project is %@.  Now run the tests by choosing Product -> Test from the Xcode menu bar (or command-U on the keyboard) and see if everything is connected properly before starting the rest of the challenges!",[GMSServices SDKVersion]];
  versionLabel.frame = CGRectMake(20, 200, 280, 200);
  [versionLabel sizeToFit];
  versionLabel.frame = CGRectMake(20, CGRectGetMidY(vc.view.frame) - CGRectGetHeight(versionLabel.frame)/2, CGRectGetWidth(versionLabel.frame), CGRectGetHeight(versionLabel.frame));
  [vc.view addSubview:versionLabel];
  
  self.window.rootViewController = vc;
  
  [self.window makeKeyAndVisible];
  return YES;
}

@end
