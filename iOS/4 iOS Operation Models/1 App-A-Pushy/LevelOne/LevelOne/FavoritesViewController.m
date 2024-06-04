//
//  FavoritesViewController.m
//  Challenge3-2
//
//  Created by Eric Allam on 10/26/12.
//  Copyright (c) 2012 Code School. All rights reserved.
//

#import "FavoritesViewController.h"
#import "ProfileViewController.h"

@interface FavoritesViewController ()

@end

@implementation FavoritesViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.title = @"Favorites";
        self.tabBarItem.image = [UIImage imageNamed:@"tab_icon_favorites"];
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    self.view.backgroundColor = [UIColor brownColor];
    
//    UIButton *profileButton = [UIButton buttonWithType:UIButtonTypeRoundedRect];
//    [profileButton setImage:[UIImage imageNamed:@"logo.jpg"] forState:UIControlStateNormal];
//    [profileButton setImage:[UIImage imageNamed:@"logo.jpg"] forState:UIControlStateHighlighted];
//    profileButton.frame = CGRectMake(15, 15, 100, 100);
//
//    [self.view addSubview:profileButton];
//    [profileButton addTarget:self action:@selector(showZoomedProfile:) forControlEvents:UIControlEventTouchUpInside];
}

- (void) showZoomedProfile: (UIButton *) sender
{
    UIViewController *imageController = [[UIViewController alloc] init];
    imageController.view.frame = self.view.frame;
    imageController.title = @"Try iOS Logo";
    
    UIImage *image = [sender imageForState:UIControlStateNormal];
    UIImageView *imageView = [[UIImageView alloc] initWithImage:image];
    imageView.frame = imageController.view.frame;
    imageView.contentMode = UIViewContentModeScaleAspectFill;
    [imageController.view addSubview:imageView];
    
    [self.navigationController pushViewController:imageController animated:YES];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
