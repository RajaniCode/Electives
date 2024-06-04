//
//  User.h
//  UserModel
//
//  Created by Eric Allam on 2/28/13.
//  Copyright (c) 2013 Code School. All rights reserved.
//

#import <Foundation/Foundation.h>

@class Photo;

@interface User : NSObject <NSCoding>

@property (strong, nonatomic) NSString *firstName;
@property (strong, nonatomic) NSString *lastName;
@property (strong, nonatomic) NSString *city;
@property (strong, nonatomic) Photo *profilePhoto;
@property (strong, nonatomic) NSString *biography;
@property (strong, nonatomic) NSString *memberSince;
@property (strong, nonatomic) NSString *location;
@property (strong, nonatomic) NSArray *favoritePhotos;

-(id)initWithJSON;
+(NSString *)getPathToArchive;

+(User *)getUser;
+(void)saveUser:(User *)aUser;

@end
