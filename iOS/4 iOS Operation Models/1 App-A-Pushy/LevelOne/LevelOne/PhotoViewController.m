#import "PhotoViewController.h"
#import "UIImageView+AFNetworking.h"

@implementation PhotoViewController

-(void)viewDidLoad {
//    self.title = self.imageTitle;
    UIImageView *imageView = [[UIImageView alloc] init];

    [imageView setImageWithURL:[NSURL URLWithString:self.imageFileName]];
    imageView.frame = CGRectMake(10,10,300,300);
    
    [self.view addSubview:imageView];
    
    UILabel *imageTitleLabel = [[UILabel alloc] init];
    imageTitleLabel.text = self.imageTitle;
    imageTitleLabel.frame = CGRectMake(11,320,300,40);
    
    [self.view addSubview:imageTitleLabel];
}

@end