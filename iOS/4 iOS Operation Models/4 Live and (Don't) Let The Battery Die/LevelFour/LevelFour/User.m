#import "User.h"
#import "AFJSONRequestOperation.h"
#import "Photo.h"

@implementation User

- (id) init;
{
    return [self initWithJSON];
}

- (id)initWithJSON {
    self = [super init];
    if(self) {        
        NSURL *url = [[NSURL alloc] initWithString:@"http://operation-models.codeschool.com/userProfile.json"];
        NSURLRequest *request = [[NSURLRequest alloc] initWithURL:url];
        
        AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:request success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
            self.firstName = JSON[@"firstName"];
            self.lastName = JSON[@"lastName"];
            self.city = JSON[@"city"];
            self.profilePhoto = [[Photo alloc] initWithTitle:@"Profile Photo" detail:@"defail" filename:JSON[@"profilePhoto"] thumbnail:JSON[@"profilePhotoThumbnail"]];
            self.biography = JSON[@"biography"];
            self.memberSince = JSON[@"memberSince"];
            
            self.location = @"no location yet";
            
            [[NSNotificationCenter defaultCenter] postNotificationName:@"initWithJSONFinishedLoading" object:nil];
        } failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error, id JSON) {
            NSLog(@"NSError: %@",[error localizedDescription]);
        }];
        
        [operation start];
        
        
    }
    return self;
}

@end
