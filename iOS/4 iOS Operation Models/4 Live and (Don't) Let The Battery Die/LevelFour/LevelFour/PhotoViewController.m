#import "PhotoViewController.h"
#import "UIImageView+AFNetworking.h"
#import "Photo.h"

@implementation PhotoViewController

-(void)viewDidLoad {
    UIImageView *imageView = [[UIImageView alloc] init];
    
    [imageView setImageWithURL:[NSURL URLWithString:self.photo.filename]];
    imageView.frame = CGRectMake(10,10,300,300);
    
    [self.view addSubview:imageView];
    
    UILabel *imageTitleLabel = [[UILabel alloc] init];
    imageTitleLabel.text = self.photo.title;
    imageTitleLabel.frame = CGRectMake(11,320,300,40);
    
    [self.view addSubview:imageTitleLabel];
}

@end