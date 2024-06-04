//
//  Photo.h
//  ChallengePhotoModel
//
//  Created by Eric Allam on 2/20/13.
//  Copyright (c) 2013 Code School. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Photo : NSObject
@property (weak, atomic) NSString *title;
@property (strong, nonatomic) NSString *detail;
@property (strong, nonatomic) NSString *filename;
@property (strong, nonatomic) NSString *thumbnail;
@end
