//
//  ProfileViewController.h
//  Challenge3-2
//
//  Created by Eric Allam on 10/26/12.
//  Copyright (c) 2012 Code School. All rights reserved.
//

#import <UIKit/UIKit.h>

@class User;

@interface ProfileViewController : UIViewController

@property (strong, nonatomic) User *user;
@property (strong, nonatomic) UIScrollView *scrollView;

- (void) fillProfileViews;

@end
