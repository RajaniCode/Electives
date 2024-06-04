//
//  Photo.h
//  ChallengePhotoModel
//
//  Created by Eric Allam on 2/20/13.
//  Copyright (c) 2013 Code School. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Photo : NSObject
@property (strong, nonatomic) NSString *title;
@property (strong, nonatomic) NSString *detail;
@property (strong, nonatomic) NSString *filename;
@property (strong, nonatomic) NSString *thumbnail;

-(id)initWithTitle:(NSString *)aTitle
            detail:(NSString *)aDetail
          filename:(NSString *)aFilename
         thumbnail:(NSString *)aThumbnail;
-(BOOL)isEqualToPhoto:(Photo *)otherPhoto;
@end
