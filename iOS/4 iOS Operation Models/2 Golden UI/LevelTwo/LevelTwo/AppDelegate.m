#import "AppDelegate.h"
#import "PhotoViewController.h"

@implementation AppDelegate

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
    PhotoViewController *photoVC = [[PhotoViewController alloc] init];
    
    self.window = [[UIWindow alloc] initWithFrame:[[UIScreen mainScreen] bounds]];
    self.window.rootViewController = photoVC;
    [self.window makeKeyAndVisible];
    return YES;
}
@end
