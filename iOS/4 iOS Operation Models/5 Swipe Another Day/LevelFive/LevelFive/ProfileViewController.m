//
//  ProfileViewController.m
//  ios-models-challenges
//
//  Created by Jon Friskics on 2/19/13.
//  Copyright (c) 2013 Code School. All rights reserved.
//

#import "ProfileViewController.h"
#import "AFJSONRequestOperation.h"
#import "UIImageView+AFNetworking.h"
#import "User.h"
#import "Photo.h"
#import "ProfileEditViewController.h"

@implementation ProfileViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.title = @"Profile";
        self.tabBarItem.image = [UIImage imageNamed:@"tab_icon_profile"];
        UIBarButtonItem *editLocationButton = [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemEdit target:self action:@selector(editLocation)];
        self.navigationItem.rightBarButtonItem = editLocationButton;
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    self.view.backgroundColor = [UIColor whiteColor];
    
    self.scrollView = [[UIScrollView alloc] initWithFrame:self.view.bounds];
    self.scrollView.autoresizingMask = UIViewAutoresizingFlexibleHeight;
    self.scrollView.contentSize = CGSizeMake(320,540);
    
    [self.view addSubview:self.scrollView];
}

- (void) editLocation {
    ProfileEditViewController *profileEditVC = [[ProfileEditViewController alloc] init];
    profileEditVC.user = self.user;
    [self presentViewController:profileEditVC animated:YES completion:nil];
}

- (void) fillProfileViews;
{
    UIImageView *profileImageView = [[UIImageView alloc] init];
    profileImageView.frame = CGRectMake(20, 20, 100, 114);
    
    UIImage *placeholder = [UIImage imageNamed:@"placeholder.jpg"];
    
    NSURL *imageURL;
    if ([self.user.profilePhoto isMemberOfClass:[NSString class]]) {
        imageURL = [NSURL URLWithString:[self.user performSelector:@selector(profilePhoto)]];
    }else{
        imageURL = [NSURL URLWithString:[[self.user performSelector:@selector(profilePhoto)] performSelector:@selector(filename)]];
    }
    
    
    [profileImageView setImageWithURL:imageURL placeholderImage:placeholder];
    profileImageView.image = placeholder;
    
    [self.scrollView addSubview:profileImageView];
    
    UILabel *nameLabel = [[UILabel alloc] init];
    nameLabel.frame = CGRectMake(20,140,280,40);
    
    nameLabel.text = [NSString stringWithFormat:@"Name: %@ %@", self.user.firstName, self.user.lastName];
    
    [self.scrollView addSubview:nameLabel];
    
    UILabel *cityLabel = [[UILabel alloc] init];
    cityLabel.frame = CGRectMake(20,200,280,40);
    cityLabel.text = self.user.city;
    
    [self.scrollView addSubview:cityLabel];
    
    UITextView *biography = [[UITextView alloc] init];
    biography.frame = CGRectMake(12,260,300,180);
    biography.font = [UIFont fontWithName:@"Helvetica" size:17];
    biography.editable = NO;
    
    biography.text = self.user.biography;
    
    [self.scrollView addSubview:biography];
    
    UILabel *memberSinceLabel = [[UILabel alloc] init];
    memberSinceLabel.frame = CGRectMake(20,440,280,40);
    memberSinceLabel.text = self.user.memberSince;
    [self.scrollView addSubview:memberSinceLabel];
    
    self.currentLocation = [[UILabel alloc] init];
    self.currentLocation.frame = CGRectMake(20,500,280,40);
    self.currentLocation.text = self.user.location;
    [self.scrollView addSubview:self.currentLocation];
    
    
}

- (void)viewWillAppear:(BOOL)animated
{
    if (!self.user) {
        self.user = [[User alloc] init];
        
        [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(fillProfileViews) name:@"initWithJSONFinishedLoading" object:nil];
    }else{
        self.currentLocation.text = self.user.location;
    }

}

@end
