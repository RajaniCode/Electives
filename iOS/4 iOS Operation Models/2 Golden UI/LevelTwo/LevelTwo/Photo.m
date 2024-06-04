#import "Photo.h"

@implementation Photo

-(id)init;
{
    self = [self initWithTitle:@"Title" detail:@"Detail" filename:@"placeholder.png" thumbnail:@"placeholder-thumb.png"];
    return self;
}

-(id)initWithTitle:(NSString *)aTitle
            detail:(NSString *)aDetail
          filename:(NSString *)aFilename
         thumbnail:(NSString *)aThumbnail;
{
    self = [super init];
    if (self) {
        self.title = aTitle;
        self.detail = aDetail;
        self.filename = aFilename;
        self.thumbnail = aThumbnail;
    }
    return self;
}
@end