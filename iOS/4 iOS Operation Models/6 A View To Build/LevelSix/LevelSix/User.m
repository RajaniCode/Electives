#import "User.h"
#import "AFJSONRequestOperation.h"
#import "Photo.h"

@implementation User

- (id)init;
{
    self = [self initWithJSON];
    return self;
}

- (id)initWithJSON
{
    self = [super init];
    if(self) {        
        NSURL *url = [[NSURL alloc] initWithString:@"http://operation-models.codeschool.com/userProfile.json"];
        NSURLRequest *request = [[NSURLRequest alloc] initWithURL:url];
        
        AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:request success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
            self.firstName = JSON[@"firstName"];
            self.lastName = JSON[@"lastName"];
            self.city = JSON[@"city"];
            self.profilePhoto = [[Photo alloc] initWithTitle:@"Profile Photo"
                                                      detail:@"detail"
                                                    filename:JSON[@"profilePhoto"]
                                                   thumbnail:JSON[@"profilePhotoThumbnail"]];
            self.biography = JSON[@"biography"];
            self.memberSince = JSON[@"memberSince"];
            
            self.location = @"no location yet";
            self.favoritePhotos = nil;
            
            [[NSNotificationCenter defaultCenter] postNotificationName:@"initWithJSONFinishedLoading" object:nil];
        } failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error, id JSON) {
            NSLog(@"NSError: %@",[error localizedDescription]);
        }];
        
        [operation start];
        
    }
    return self;
}

+(NSString *)getPathToArchive {
    NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *docsDir = [paths objectAtIndex:0];
    return [docsDir stringByAppendingPathComponent:@"user.model"];
}

+(User *)getUser {
	return [NSKeyedUnarchiver unarchiveObjectWithFile:[User getPathToArchive]];
}

+(void)saveUser:(User *)aUser {
	[NSKeyedArchiver archiveRootObject:aUser toFile:[User getPathToArchive]];
}

-(void)encodeWithCoder:(NSCoder *)aCoder {
    [aCoder encodeObject:self.firstName forKey:@"firstName"];
    [aCoder encodeObject:self.lastName forKey:@"lastName"];
    [aCoder encodeObject:self.city forKey:@"city"];
    [aCoder encodeObject:self.profilePhoto forKey:@"profilePhoto"];
    [aCoder encodeObject:self.memberSince forKey:@"memberSince"];
    [aCoder encodeObject:self.biography forKey:@"biography"];
    [aCoder encodeObject:self.location forKey:@"location"];
    [aCoder encodeObject:self.favoritePhotos forKey:@"favoritePhotos"];
}

-(id)initWithCoder:(NSCoder *)aDecoder {
    self = [super init];
    if(self) {
        self.firstName = [aDecoder decodeObjectForKey:@"firstName"];
        self.lastName = [aDecoder decodeObjectForKey:@"lastName"];
        self.city = [aDecoder decodeObjectForKey:@"city"];
        self.profilePhoto = [aDecoder decodeObjectForKey:@"profilePhoto"];
        self.memberSince = [aDecoder decodeObjectForKey:@"memberSince"];
        self.biography = [aDecoder decodeObjectForKey:@"biography"];
        self.location = [aDecoder decodeObjectForKey:@"location"];
        self.favoritePhotos = [aDecoder decodeObjectForKey:@"favoritePhotos"];
    }
    return self;
}

-(NSString *)description;
{
    return [NSString stringWithFormat:@"[User: \n\tfirstName: %@ \n\tlastName: %@ \n\tcity: %@ \n\tprofilePhoto: %@ \n\tmemberSince: %@ \n\tbiography: %@ \n\tlocation:%@\n]", self.firstName, self.lastName, self.city, self.profilePhoto, self.memberSince, self.biography, self.location];
}

@end
