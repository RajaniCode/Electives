#import "AppDelegate.h"
#import "FeedTableViewController.h"
#import "FavoritesTableViewController.h"
#import "ProfileViewController.h"
#import "User.h"
#import "Photo.h"

@implementation AppDelegate

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
    FeedTableViewController *feedTableViewController = [[FeedTableViewController alloc] initWithStyle:UITableViewStylePlain];
    UINavigationController *feedNavController = [[UINavigationController alloc] initWithRootViewController:feedTableViewController];
    
    FavoritesTableViewController *favoritesTableViewController = [[FavoritesTableViewController alloc] initWithStyle:UITableViewStyleGrouped];
    UINavigationController *favoritesNavController = [[UINavigationController alloc] initWithRootViewController:favoritesTableViewController];
    
    ProfileViewController *profileViewController = [[ProfileViewController alloc] init];
    UINavigationController *profileNavController = [[UINavigationController alloc] initWithRootViewController:profileViewController];
    
    UITabBarController *tabBarController = [[UITabBarController alloc] init];
    tabBarController.viewControllers = @[feedNavController, favoritesNavController, profileNavController];
    
    self.window = [[UIWindow alloc] initWithFrame:[[UIScreen mainScreen] bounds]];
    
    self.window.rootViewController = tabBarController;
    [self.window makeKeyAndVisible];
    
    return YES;
}
@end
