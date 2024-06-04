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

-(BOOL)isEqualToPhoto:(Photo *)otherPhoto;
{
    return ([self.title isEqualToString:otherPhoto.title] && [self.detail isEqualToString:otherPhoto.detail] && [self.filename isEqualToString:otherPhoto.filename] && [self.thumbnail isEqualToString:otherPhoto.thumbnail]);
}

- (NSString *)description;
{
    return [NSString stringWithFormat:@"<Photo title:%@ detail:%@ filename:%@ thumbnail:%@>", self.title, self.detail, self.filename, self.thumbnail];
}
@end