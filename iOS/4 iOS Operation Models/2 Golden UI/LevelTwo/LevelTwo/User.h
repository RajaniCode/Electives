//
//  User.h
//  UserModel
//
//  Created by Eric Allam on 2/28/13.
//  Copyright (c) 2013 Code School. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface User : NSObject
@property (strong, nonatomic) NSString *firstName;
@property (strong, nonatomic) NSString *lastName;
@property (strong, nonatomic) NSString *city;
@property (strong, nonatomic) NSString *profilePhoto;
@property (strong, nonatomic) NSString *profilePhotoThumbnail;
@property (strong, nonatomic) NSString *biography;
@property (strong, nonatomic) NSString *memberSince;
@end
