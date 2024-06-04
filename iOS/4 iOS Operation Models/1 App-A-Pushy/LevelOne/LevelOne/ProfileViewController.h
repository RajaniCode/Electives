//
//  ProfileViewController.h
//  Challenge3-2
//
//  Created by Eric Allam on 10/26/12.
//  Copyright (c) 2012 Code School. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ProfileViewController : UIViewController
@property (strong, nonatomic) NSDictionary *userProfile;
@property (strong, nonatomic) UIScrollView *scrollView;

- (void) requestSuccessful;
@end
